using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Json.JsonClass
{
    public class Regions
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("psgc_code")]
        public string PsgcCode { get; set; }

        [JsonProperty("region_name")]
        public string RegionName { get; set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; set; }
        public List<Province> Provinces { get; set; }
    }
}
