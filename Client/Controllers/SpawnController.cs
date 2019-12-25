using CitizenFX.Core;
using CitizenFX.Core.UI;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models.Mapping;
using Client.Enums;

namespace Client.Controllers
{
    public class SpawnController : BaseController
    {
        private bool m_hasSpawned = true;
        private bool m_spawning;
        private bool m_firstSpawn = true;

        private List<GridSpawnPoint> m_gridSpawns = new List<GridSpawnPoint>();

        private GridSpawnPoint m_assignedGridSpawn;

        private class GridSpawnPoint
        {
            public Vector3 Position { get; }
            public float Heading { get; }

            public GridSpawnPoint(Vector3 vector, float heading)
            {
                Position = vector;
                Heading = heading;
            }
        }

        internal SpawnController() : base(nameof(SpawnController))
        {

        }

        [EventHandler("onClientGameTypeStart")]
        public void OnClientGameTypeStart()
        {
            TriggerServerEvent("onPlayerJoining");

            N_0xf7b79a50b905a30d(-8192.0f, -8192.0f, 8192.0f, 8192.0f);
        }

        [EventHandler("onClientMapStop")]
        public void OnMapStop()
        {
            Game.PlayerPed.Position = new Vector3(0.0f, 0.0f, 0.0f);

            DisplayRadar(false);

            if(GameController.GameState != GameState.INIT)
            {
                DoScreenFadeOut(0);
            }

            m_assignedGridSpawn = null;
            m_gridSpawns.Clear();
        }

        [EventHandler("onClientGameTypeStop")]
        public void OnGameTypeStop()
        {
            DoScreenFadeOut(0);
        }

        [EventHandler("onClientMapStart")]
        public async void MapStart()
        {
            Exports["spawnmanager"].setAutoSpawn(false);

            m_assignedGridSpawn = null;
            m_gridSpawns.Clear();

            while(Client.Instance.Game.CurrentMap == null)
            {
                await Delay(0);
            }

            var md = Client.Instance.Game.CurrentMap.mission;

            for (int i = 0; i < md.RaceData.GridLanes; i++)
            {
                var l = new Vector3(md.VehicleData.Locations[i].x, md.VehicleData.Locations[i].y, md.VehicleData.Locations[i].z);
                var gs = new GridSpawnPoint(l, md.VehicleData.Heading[i]);

                m_gridSpawns.Add(gs);
            }

            m_spawning = false;
            m_hasSpawned = false;
            m_firstSpawn = true;
        }

        [Tick]
        public async Task OnTick()
        {
            try
            {
                if (!m_hasSpawned && !m_spawning && m_gridSpawns.Count > 0)
                {
                    if(GameController.GameState == GameState.INIT || GameController.GameState == GameState.LOADING || m_assignedGridSpawn == null)
                    {
                        return;
                    }

                    m_spawning = true;

                    float x, y, z;
                    float heading = 0;

                    if(!m_firstSpawn)
                    {
                        var pos = Client.Instance.Checkpoints.GetRespawnPosition();

                        x = pos.X;
                        y = pos.Y;
                        z = pos.Z;
                        heading = pos.W;
                    }
                    else
                    {
                        x = m_assignedGridSpawn.Position.X;
                        y = m_assignedGridSpawn.Position.Y;
                        z = m_assignedGridSpawn.Position.Z;
                        heading = m_assignedGridSpawn.Heading;
                    }

                    RequestModel((uint)Game.GenerateHash("s_m_y_robber_01"));

                    Exports["spawnmanager"].forceRespawn();

                    Exports["spawnmanager"].spawnPlayer(new
                    {
                        x, y, z,
                        heading,
                        model = (uint)Game.GenerateHash("s_m_y_robber_01"),
                        skipFade = true
                    }, new Action(async () =>
                    {
                        Game.PlayerPed.Weapons.RemoveAll();

                        SetPedDefaultComponentVariation(Game.PlayerPed.Handle);

                        DisplayRadar(true);

                        SetMaxWantedLevel(0);

                        // debug vehicle for now. in future should be chosen vehicle
                        var model = new Model(VehicleHash.Bifta);

                        await model.Request(5000);

                        var veh = await World.CreateVehicle(model, new Vector3(x, y, z), heading);

                        if(veh != null)
                        {
                            veh.PlaceOnGround();
                            Game.PlayerPed.SetIntoVehicle(veh, VehicleSeat.Driver);
                            veh.PreviouslyOwnedByPlayer = true;
                            Game.PlayerPed.CanBeDraggedOutOfVehicle = false;
                            SetVehicleDoorsLockedForAllPlayers(veh.Handle, true);

                            veh.MarkAsNoLongerNeeded();
                        }

                        if (GetPlayerSwitchState() != 0 && GetPlayerSwitchState() != 12)
                        {
                            SwitchInPlayer(PlayerPedId());

                            while (GetPlayerSwitchState() != 12)
                            {
                                await Delay(0);
                            }
                        }

                        if (m_firstSpawn)
                        {
                            TriggerServerEvent("racing:announceSpawnedRaceStart");
                        }

                        m_spawning = false;
                        m_firstSpawn = false;

                        Logger.Info("Done spawning!");
                    }));

                    m_hasSpawned = true;
                }

                if(Game.PlayerPed.IsDead && !m_spawning)
                {
                    m_hasSpawned = false;
                }

                // Should go elsewhere
                if(GameController.GameState == GameState.ONGOING && Client.Instance.Game.CurrentMap.mission.VehicleData.col[0] != -1)
                {
                    var cV = Game.PlayerPed.CurrentVehicle;

                    if (cV != null)
                    {
                        foreach (var p in Players)
                        {
                            var pV = p.Character.CurrentVehicle;
                            if(pV != null)
                            {
                                SetEntityNoCollisionEntity(pV.Handle, cV.Handle, false);
                                SetEntityAlpha(pV.Handle, 180, 0);
                                SetEntityAlpha(p.Character.Handle, 180, 0);
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Logger.Exception(e, "SpawnController:OnTick");
                await Delay(5000);
            }
            await Task.FromResult(0);
        }

        [EventHandler("racing:gridSpot")]
        public async void ReceiveGridSpawn(int spotIdx)
        {
            try
            {
                while (m_gridSpawns == null || m_gridSpawns.Count == 0)
                    await Delay(0);

                m_assignedGridSpawn = m_gridSpawns.ElementAt(spotIdx);
            }
            catch (Exception e)
            {
                Logger.Exception(e, "Assigning last grid spot instead");
                m_assignedGridSpawn = m_gridSpawns.Last();
            }
        }

        [EventHandler("racing_firstLoad")]
        public void FirstLoad()
        {
            // Tick += OnFirstLoad;
        }

        [Tick]
        public async Task OnPopulationTick()
        {
            SetPedDensityMultiplierThisFrame(0);
            SetScenarioPedDensityMultiplierThisFrame(0, 0);
            SetVehicleDensityMultiplierThisFrame(0);
            SetRandomVehicleDensityMultiplierThisFrame(0);
            SetParkedVehicleDensityMultiplierThisFrame(0);

            await Task.FromResult(0);
        }

        public async Task OnFirstLoad()
        {
            try
            {
                if (Screen.Fading.IsFadedIn)
                {
                    Screen.Fading.FadeOut(0);
                    while (Screen.Fading.IsFadedIn)
                    {
                        await Delay(0);
                    }
                }

                await Game.Player.ChangeModel(new Model(PedHash.Skater01AMM));

                if (Game.PlayerPed.IsDead)
                {
                    NetworkResurrectLocalPlayer(228.1f, -1006.0f, 100.0f, 0.0f, true, true);
                }

                SetLoadingPromptTextEntry("FMMC_PLYLOAD");
                Screen.LoadingPrompt.Show();

                Game.PlayerPed.Position = new Vector3(-2406.319f, 2968.841f, 1182.948f);

                Game.PlayerPed.IsPositionFrozen = false;

                StopPlayerSwitch();

                Tick -= OnFirstLoad;
            }
            catch (Exception e)
            {
                Logger.Exception(e, "OnFirstLoad");
                await Delay(5000);
            }

            await Task.FromResult(0);
        }
    }
}
