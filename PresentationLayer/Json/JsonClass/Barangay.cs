using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Json.JsonClass
{
    public class Barangay
    {
        [JsonProperty("brgy_code")]
        public string BarangayCode { get; set; }

        [JsonProperty("brgy_name")]
        public string BarangayName { get; set; }

        [JsonProperty("city_code")]
        public string CityCode { get; set; }

        [JsonProperty("province_code")]
        public string ProvinceCode { get; set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; set; }
    }
}
