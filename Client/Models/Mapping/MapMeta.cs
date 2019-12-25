using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Mapping
{
    public class MapMeta
    {
        public bool EnableEms { get; set; }
        public List<string> Locations { get; set; }
        public List<string> VehicleClass { get; set; }


        // unknown vars
        public List<dynamic> Mrule { get; set; }
        public List<dynamic> Stia { get; set; }
        public List<dynamic> Stia2 { get; set; }
        public List<dynamic> Stinv { get; set; }

    }
}
