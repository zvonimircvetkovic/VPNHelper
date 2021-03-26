using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPNHelperCommon.Models
{
    public class Location
    {
        [JsonProperty("lat")]
        public float Lat { get; set; }

        [JsonProperty("_long")]
        public float Long { get; set; }
    }
}
