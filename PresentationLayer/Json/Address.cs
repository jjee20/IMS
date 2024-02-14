using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Json
{
    public class Address
    {
        public class Barangay
        {
            public List<string> barangay_list { get; set; }
        }

        public class Municipality
        {
            public Dictionary<string, Barangay> municipality_list { get; set; }
        }

        public class Province
        {
            public Dictionary<string, Municipality> province_list { get; set; }
        }

        public class Regions
        {
            public string region_name { get; set; }
            public Province province { get; set; }
        }

        public class Root
        {
            public Dictionary<string, Regions> Items { get; set; }
        }
    }
}
