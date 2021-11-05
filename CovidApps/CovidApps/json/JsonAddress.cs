using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.api.openstreetmap
{
    public class JsonAddress
    {
        [JsonProperty("country")]
        public string country { get; set; }
    }
}
