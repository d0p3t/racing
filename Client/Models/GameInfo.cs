using CitizenFX.Core;

namespace Client.Models
{
    public class GameInfo
    {
        public string MapFileName { get; set; }
        public int MyPosition { get; set; } = 1;
        public int CurrentLap { get; set; } = 1;
        public int GridSpot { get; set; } = -1;
        public Model VehicleModel { get; set; }
        public string PlayerModel { get; set; } = "s_m_y_robber_01";
        public bool PlayerReady { get; set; }
    }
}
