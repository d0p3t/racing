using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Enums;
using Client.Models;
using Client.Models.Mapping;

namespace Client.Controllers
{
    public class GameController: BaseController
    {
        public static GameState GameState { get; set; }
        public GameInfo GameInfo { get; set; }
        public Map CurrentMap { get; private set; }

        public Action<GameState> GameStateListener;

        internal GameController(): base(nameof(GameController))
        {
            GameStateListener += (GameState state) => { Logger.Info($"GameState Changed [{GameState}] -> [{state}]"); GameState = state; };
            GameInfo = new GameInfo();

            var mc = MapController.Instance.Value;
            mc.RegisterKeyDirective("file_name");

            RequestModel((uint)Game.GenerateHash("prop_mp_boost_01"));
            RequestModel((uint)Game.GenerateHash("s_m_y_robber_01"));
        }

        [EventHandler("onClientMapStart")]
        public void OnClientMapStart()
        {
            try
            {
                GameStateListener.Invoke(GameState.INIT);

                SetLoadingPromptTextEntry("FMMC_PLYLOAD");
                ShowLoadingPrompt(1);

                GameInfo.MapFileName = MapController.Instance.Value.GetDirectives("file_name").FirstOrDefault();
                GameInfo.CurrentLap = 1;
                GameInfo.MyPosition = 1;
                GameInfo.PlayerReady = false;

                var loadedFile = LoadResourceFile(GetCurrentResourceName(), $"data/maps/{GameInfo.MapFileName}.json");

                if (!string.IsNullOrEmpty(loadedFile))
                {
                    try
                    {
                        CurrentMap = JsonConvert.DeserializeObject<Map>(loadedFile);
                        GC.Collect(); // Is loadedFile culprit of high memory usage?
                    }
                    catch (Exception e)
                    {
                        Logger.Exception(e, $"Could not parse {GameInfo.MapFileName}"); 
                        return;
                    }
                }
                else
                {
                    Logger.Info($"Could not find {GameInfo.MapFileName}");
                    CancelEvent();
                    return;
                }

                if (CurrentMap != null)
                {
                    var model = CurrentMap.mission.Generated.DefaultVehicleHash;
                    GameInfo.VehicleModel = new Model(model != 0 ? model : unchecked((int)VehicleHash.FMJ));

                    AddTextEntry("RACING_MAP_NAME", CurrentMap.mission.Generated.MissionName);
                    AddTextEntry("RACING_MAP_LAPS", CurrentMap.mission.RaceData.NumberOfLaps.ToString());

                    var raceData = CurrentMap.mission.RaceData;

                    List<bool> isRound = new List<bool>();
                    List<bool> isRoundSecondary = new List<bool>();

                    if (raceData.RoundCheckpoint?.Length > 0)
                        isRound = raceData.RoundCheckpoint.ToList();
                    else
                        raceData.CheckpointLocations.ToList().ForEach(cp => isRound.Add(false));


                    if (raceData.RoundCheckpointSecondary?.Length > 0)
                        isRoundSecondary = raceData.RoundCheckpointSecondary.ToList();
                    else
                        raceData.CheckpointLocations.ToList().ForEach(cp => isRoundSecondary.Add(false));


                    Client.Instance.Checkpoints.SetCheckPoints(raceData.CheckpointLocations.ToList(), isRound, raceData.CheckpointHeadings, raceData.CheckpointScale, raceData.SecondaryCheckPointPositions.ToList(), isRoundSecondary);
                    Client.Instance.Props.LoadMapProps(CurrentMap.mission.DeleteProps);
                    Client.Instance.Vehicle.MapStart();
                    Client.Instance.Spawn.MapStart();

                    GameStateListener.Invoke(GameState.LOADING);
                }
                else
                {
                    Logger.Info("Its null???");
                }
            }
            catch (Exception e)
            {
                Logger.Exception(e, "OnClientMapStart");
                CancelEvent();
            }
        }

        [EventHandler("onClientMapStop")]
        public void OnClientMapStop()
        {
            CurrentMap = null;
        }

        private async Task EndRound()
        {
            HideHudAndRadarThisFrame();

            if(GameState == GameState.POST)
            {
                return;
            }

            Client.Instance.Game.GameStateListener.Invoke(GameState.POST);
            await Delay(500);

            FreezeEntityPosition(PlayerPedId(), true);

            // scaleform stuff

            // spectate stuff

            TriggerServerEvent("racing:finished");
        }

        [EventHandler("racing:post")]
        public async void OnSetPost()
        {
            SwitchOutPlayer(PlayerPedId(), 0, 1);

            while (GetPlayerSwitchState() != 5)
            {
                await Delay(0);
            }

            SetLoadingPromptTextEntry("FM_IHELP_WAT2");
            ShowLoadingPrompt(1);

            await Delay(5000); // temp delay

            Client.Instance.Game.GameStateListener.Invoke(GameState.INIT);

            TriggerServerEvent("racing:changeState", (int)GameState);
        }

        [Tick]
        public async Task OnTick()
        {
            try
            {
                if(GameState == GameState.POST)
                {
                    return;
                }

                if(GameState == GameState.FINISHED)
                {
                    await EndRound();
                    return;
                }
            }
            catch (Exception e)
            {
                Logger.Exception(e, "GameController:OnTick");
                await Delay(5000);
            }
            await Task.FromResult(0);
        }
    }
}
