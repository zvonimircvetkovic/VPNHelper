using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPNHelperCommon.Models
{
    public class Server
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("ip_address")]
        public string IPAddress { get; set; }

        [JsonProperty("search_keywords")]
        public IEnumerable<string> SearchKeywords { get; set; }

        [JsonProperty("categories")]
        public IEnumerable<Category> Categories { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("load")]
        public int Load { get; set; }

        [JsonProperty("features")]
        public Features Features { get; set; }
    }
}
