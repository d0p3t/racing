using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models.Hud;

namespace Client.Controllers
{
    public class TimerBarController : BaseController
    {
        private bool m_enabled = false;

        private TimerBarPool m_pool = new TimerBarPool();
        private TextTimerBar m_currentLap;
        private TextTimerBar m_time;

        private int m_startTime = 0;
        private int m_startLapTime = 0;

        internal TimerBarController() : base(nameof(TimerBarController))
        {
            m_currentLap = new TextTimerBar("CURRENT LAP", "00:00:00");
            m_time = new TextTimerBar("TIME", "00:00:00");

            m_pool.Add(m_currentLap);
            m_pool.Add(m_time);
        }

        public void Enabled(bool toggle, int laps = 1)
        {
            m_enabled = toggle;

            if(laps == 1)
            {
                m_pool.Remove(m_currentLap);
            } else
            {
                m_pool.Add(m_currentLap);
            }

            if(toggle)
            {
                m_startTime = GetGameTimer();
                m_startLapTime = GetGameTimer();
            } else
            {
                m_startTime = 0;
                m_startLapTime = 0;
            }
        }

        [Tick]
        public async Task OnTick()
        {
            try
            {
                if (!m_enabled)
                    return;

                if(!HasStreamedTextureDictLoaded("timerbars"))
                {
                    RequestStreamedTextureDict("timerbars",true);
                    while (!HasStreamedTextureDictLoaded("timerbars"))
                    {
                        await Delay(0);
                    }
                }

                m_pool.Draw();

                var elapsed = GetGameTimer() - m_startTime;
                m_time.Text = TimeSpan.FromMilliseconds(elapsed).ToString(@"mm\:ss\:ff");

                elapsed = GetGameTimer() - m_startLapTime;
                m_time.Text = TimeSpan.FromMilliseconds(elapsed).ToString(@"mm\:ss\:ff");
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                await Delay(2000);
            }
            await Task.FromResult(0);
        }
    }
}
