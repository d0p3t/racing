using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class GameInfo
    {
        private bool m_playerReady = false;

        public string MapFileName { get; set; }
        public int MyPosition { get; set; } = 1;
        public int CurrentLap { get; set; } = 1;
        public int GridSpot { get; set; } = -1;

        public bool PlayerReady 
        {
            get
            {
                return m_playerReady; 
            }
            set
            {
                m_playerReady = value;
                CitizenFX.Core.BaseScript.TriggerServerEvent("racing_announceReadyState", value);
            }
        }
    }
}
