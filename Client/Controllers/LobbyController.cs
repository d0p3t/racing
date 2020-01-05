using CitizenFX.Core;
using CitizenFX.Core.UI;
using static CitizenFX.Core.Native.API;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Enums;
using Client.Models;
using Client.Models.Mapping;

namespace Client.Controllers
{
    public class LobbyController : BaseController
    {
        public static readonly Vector4 VotePosition = new Vector4(-672.5693f, 1305.127f, 387.0675f, 347.7116f);

        internal LobbyController() : base(nameof(LobbyController))
        {
        }

        [EventHandler("onClientGameTypeStart")]
        public void OnClientGameTypeStart()
        {

        }

        private Scaleform m_countdown = null;
        private int countdown = 3;
        private bool show = false;

        [Tick]
        public async Task ShowCountdown()
        {
            try
            {
                if (!show)
                {
                    if (m_countdown != null)
                    {
                        m_countdown.Dispose();
                        m_countdown = null;
                        countdown = 3;
                    }
                    return;
                }

                if (m_countdown == null)
                {
                    m_countdown = new Scaleform("COUNTDOWN");

                    while (!m_countdown.IsLoaded)
                    {
                        await Delay(0);
                    }
                    Logger.Info("Ok loaded");
                }

                var text = (countdown > 1) ? countdown.ToString() : (countdown == 1) ? "1" : "GO";
                if (countdown <= 0)
                {
                    int r = 0;
                    int g = 0;
                    int b = 0;
                    int a = 0;
                    GetHudColour(18, ref r, ref g, ref b, ref a);
                    m_countdown.CallFunction("SET_MESSAGE", "CNTDWN_GO", r, g, b, true);
                }
                else
                {
                    m_countdown.CallFunction("SET_MESSAGE", text, 240, 200, 80, true);
                    
                }

                HideHudAndRadarThisFrame();
                m_countdown.Render2D();
            }
            catch (Exception e)
            {
                Logger.Exception(e, "LobbyController");
                await Delay(5000);
            }
        }


        [Tick]
        public async Task OnLobbyTick()
        {
            try
            {
                if (GameController.GameState == GameState.LOADING)
                {
                    await Delay(2000);
                    Client.Instance.Game.GameStateListener.Invoke(GameState.VEHICLE_SELECT);
                    TriggerEvent("racing:spawn");

                    await Delay(3000);

                    while (!Client.Instance.Props.DoneSpawningProps)
                    {
                        // Logger.Info("nope");
                        await Delay(0);
                    }
                    Client.Instance.Game.GameStateListener.Invoke(GameState.PRE_COUNTDOWN);
                    TriggerEvent("racing:spawn");

                    await Delay(5000);
                    Client.Instance.Game.GameStateListener.Invoke(GameState.COUNTDOWN);

                    await Delay(2000);

                    show = true;

                    Client.Instance.Audio.PlaySound($"Countdown_{countdown}", "DLC_Stunt_Race_Frontend_Sounds");
                    await Delay(1000);
                    countdown--;
                    Client.Instance.Audio.PlaySound($"Countdown_{countdown}", "DLC_Stunt_Race_Frontend_Sounds");
                    await Delay(1000);
                    countdown--;
                    Client.Instance.Audio.PlaySound($"Countdown_{countdown}", "DLC_Stunt_Race_Frontend_Sounds");
                    await Delay(1000);
                    countdown--;
                    Client.Instance.Audio.PlaySound("Countdown_Go", "DLC_Stunt_Race_Frontend_Sounds");
                    Client.Instance.TimerBars.Enabled(true);
                    Client.Instance.Game.GameStateListener.Invoke(GameState.ONGOING);
                    await Delay(1000);
                    show = false;
                }
            }
            catch (Exception e)
            {
                Logger.Exception(e, "OnLobbyTick");
                await Delay(5000);
            }

        }
    }
}
