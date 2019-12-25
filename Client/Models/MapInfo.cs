using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Enums;

namespace Client.Models
{
    public class MapSettings
    {
        public RaceType RaceType { get; set; }
        public int NumberOfLaps { get; set; }
        public int TimeOfDay { get; set; }
        public bool Traffic { get; set; }
        public bool WantedLevels { get; set; }
        public bool CustomVehicles { get; set; }
        public bool Catchup { get; set; }
        public bool Slipstream { get; set; }
        // public something CameraLock {get; set;}
        public bool DestroyLastPlace { get; set; }
        public bool AggregatePosition { get; set; }
        public RadioStation Radio { get; set; }
    }
}
