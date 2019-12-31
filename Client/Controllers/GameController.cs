using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        internal GameController(): base(nameof(GameController))
        {
            var mc = MapController.Instance.Value;
            mc.RegisterKeyDirective("file_name");

            GameInfo = new GameInfo();

            RequestModel((uint)Game.GenerateHash("prop_mp_boost_01"));
            RequestModel((uint)Game.GenerateHash("prop_mp_boost_0o1"));
            RequestModel((uint)Game.GenerateHash("s_m_y_robber_01"));
        }

        [EventHandler("onClientMapStart")]
        public void OnClientMapStart()
        {
            GameState = GameState.INIT;

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
                }
                catch { Logger.Info("Something went wrong in GameController"); }
            }

            if(CurrentMap != null)
            {
                var model = CurrentMap.mission.VehicleData.ModelHash[0];
                GameInfo.VehicleModel = new Model(model != 0 ? model : unchecked((int)VehicleHash.Adder));
                AddTextEntry("RACING_MAP_NAME", CurrentMap.mission.Generated.MissionName);
                AddTextEntry("RACING_MAP_LAPS", CurrentMap.mission.RaceData.NumberOfLaps.ToString());

                var raceData = CurrentMap.mission.RaceData;
                Client.Instance.Checkpoints.SetCheckPoints(raceData.CheckpointLocations.ToList(), raceData.CheckpointHeadings, raceData.CheckpointScale, raceData.SecondaryCheckPointPositions.ToList());
            }

            GameState = GameState.LOADING;
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

            GameState = GameState.POST;
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

            GameState = GameState.INIT;
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
