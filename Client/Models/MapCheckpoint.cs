using CitizenFX.Core;

namespace Client.Models
{
    public class MapCheckpoint
    {
        public Vector3 Position { get; set; }
        public float Heading { get; set; }
        public int Type { get; set; }
        public float Scale { get; set; }
        public bool HasSecondary { get; set; }
    }
}
