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
        private bool m_spawning = false;
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

        [EventHandler("onClientMapStop")]
        public void OnMapStop()
        {
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

        public void MapStart()
        {
            Exports["spawnmanager"].setAutoSpawn(false);

            RequestModel((uint)Game.GenerateHash("s_m_y_robber_01"));

            m_assignedGridSpawn = null;
            m_gridSpawns.Clear();

            var md = Client.Instance.Game.CurrentMap.mission;

            for (int i = 0; i < md.RaceData.GridLanes; i++)
            {
                var l = new Vector3(md.VehicleData.Locations[i].x, md.VehicleData.Locations[i].y, md.VehicleData.Locations[i].z);
                var gs = new GridSpawnPoint(l, md.VehicleData.Heading[i]);

                m_gridSpawns.Add(gs);
            }

            Logger.Info($"Added {m_gridSpawns.Count} gridspawns");
            m_spawning = false;
            m_hasSpawned = false;
            m_firstSpawn = true;
        }

        [EventHandler("racing:spawn")]
        public void ChangeState()
        {
            m_hasSpawned = false;
        }

        [Tick]
        public async Task OnTick()
        {
            try
            {
                if (!m_hasSpawned && !m_spawning)
                {
                    var state = GameController.GameState;

                    if (state != GameState.LOADING && state != GameState.VEHICLE_SELECT && state != GameState.PRE_COUNTDOWN && state != GameState.ONGOING)
                        return;

                    m_spawning = true;

                    SetLoadingPromptTextEntry("FMMC_PLYLOAD");
                    ShowLoadingPrompt(1);

                    var pos = GetSpawnPosition();

                    Logger.Info($"Spawning at {pos.X}, {pos.Y}, {pos.Z}, {pos.W}");

                    var modelHash = (uint)Game.GenerateHash(Client.Instance.Game.GameInfo.PlayerModel);

                    if (!IsModelValid(modelHash) || !IsModelInCdimage(modelHash))
                        return;

                    Exports["spawnmanager"].forceRespawn();

                    Exports["spawnmanager"].spawnPlayer(new
                    {
                        x = pos.X, y = pos.Y, z = pos.Z,
                        heading = pos.W,
                        model = modelHash,
                        skipFade = m_firstSpawn,
                        skipFadeIn = true
                    }, new Action(async () =>
                    {
                        PostSpawn(pos);

                        await Delay(2000);
                        RemoveLoadingPrompt();

                        if(Screen.Fading.IsFadedOut)
                        {
                            Screen.Fading.FadeIn(500);
                            while(!Screen.Fading.IsFadedIn)
                            {
                                await Delay(0);
                            }
                        }

                        if (GetPlayerSwitchState() != 0 && GetPlayerSwitchState() != 12)
                        {
                            SwitchInPlayer(PlayerPedId());

                            while (GetPlayerSwitchState() != 12)
                            {
                                await Delay(0);
                            }
                        }

                        Logger.Info("Done spawning");
                        m_spawning = false;
                        m_firstSpawn = false;
                    }));

                    m_hasSpawned = true;
                }

                if (Game.PlayerPed.IsDead && !m_spawning)
                {
                    m_hasSpawned = false;
                }

                // Should go elsewhere - This is for "no collission" maps
                // Client.Instance.Game.CurrentMap.mission.VehicleData.col[0] != -1
                //if (GameController.GameState == GameState.ONGOING)
                //{
                //    var cV = Game.PlayerPed.CurrentVehicle;

                //    if (cV != null)
                //    {
                //        foreach (var p in Players)
                //        {
                //            var pV = p.Character.CurrentVehicle;
                //            if(pV != null)
                //            {
                //                SetEntityNoCollisionEntity(pV.Handle, cV.Handle, false);
                //                SetEntityAlpha(pV.Handle, 180, 0);
                //                SetEntityAlpha(p.Character.Handle, 180, 0);
                //            }
                //        }
                //    }
                //}
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

                Logger.Info($"spotIdx {spotIdx} max index {m_gridSpawns.Count - 1}");
                m_assignedGridSpawn = m_gridSpawns.ElementAt(spotIdx);
            }
            catch (Exception e)
            {
                Logger.Exception(e, "Assigning last grid spot instead");
                m_assignedGridSpawn = m_gridSpawns.Last();
            }
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
    
        private Vector4 GetSpawnPosition()
        {
            Vector4 spawnPosition = Vector4.Zero;
            switch (GameController.GameState)
            {
                case GameState.LOADING:
                    spawnPosition = LobbyController.VotePosition;
                    break;
                case GameState.VEHICLE_SELECT:
                    var lobbyPos = Client.Instance.Game.CurrentMap.mission.Generated.LobbyStartLocation;
                    var heading = Client.Instance.Game.CurrentMap.mission.Generated.LobbyCamHeading;
                    spawnPosition = new Vector4(lobbyPos.x, lobbyPos.y, lobbyPos.z, heading);
                    break;
                case GameState.PRE_COUNTDOWN:
                    if(m_assignedGridSpawn != null)
                        spawnPosition = new Vector4(m_assignedGridSpawn.Position.X, m_assignedGridSpawn.Position.Y, m_assignedGridSpawn.Position.Z, m_assignedGridSpawn.Heading);
                    break;
                case GameState.ONGOING:
                    spawnPosition = Client.Instance.Checkpoints.GetRespawnPosition();
                    break;
                case GameState.INIT: // these cases will never happen
                case GameState.READY:
                case GameState.COUNTDOWN:
                case GameState.FINISHED:
                case GameState.SPECTATING:
                case GameState.POST:
                    break;
            }

            return spawnPosition;
        }

        private async void PostSpawn(Vector4 pos)
        {
            World.RenderingCamera = null;
            Game.PlayerPed.Weapons.RemoveAll();
            SetPedDefaultComponentVariation(Game.PlayerPed.Handle);
            SetMaxWantedLevel(0);

            switch (GameController.GameState)
            {
                case GameState.INIT:
                case GameState.READY:
                case GameState.COUNTDOWN:
                case GameState.FINISHED:
                case GameState.SPECTATING:
                case GameState.POST:
                    break;
                case GameState.LOADING:
                    Game.PlayerPed.IsPositionFrozen = true;
                    break;
                case GameState.VEHICLE_SELECT:
                    Game.PlayerPed.IsPositionFrozen = true;
                    break;
                case GameState.PRE_COUNTDOWN:
                    DisplayRadar(true);
                    var model = Client.Instance.Game.GameInfo.VehicleModel;
                    Logger.Info($"Going to spawn {model.Hash}");
                    await model.Request(5000);
                    var veh = await World.CreateVehicle(model, new Vector3(pos.X, pos.Y, pos.Z), pos.W);
                    Logger.Info("Spawned vehicle");
                    if (veh != null)
                    {
                        veh.PlaceOnGround();
                        Game.PlayerPed.SetIntoVehicle(veh, VehicleSeat.Driver);
                        veh.PreviouslyOwnedByPlayer = true;
                        Game.PlayerPed.CanBeDraggedOutOfVehicle = false;
                        SetVehicleDoorsLockedForAllPlayers(veh.Handle, true);
                        SetVehicleDoorsLocked(veh.Handle, 4);
                        veh.IsPositionFrozen = true;
                        veh.MarkAsNoLongerNeeded();
                    }
                    break;
            }
        }
    }
}
