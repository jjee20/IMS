using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Json.JsonClass
{
    public class Province
    {
        [JsonProperty("province_code")]
        public string ProvinceCode { get; set; }

        [JsonProperty("province_name")]
        public string ProvinceName { get; set; }

        [JsonProperty("psgc_code")]
        public string PsgcCode { get; set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; set; }
        public List<City> Cities { get; set; }
    }
}
