using CovidApps.api.openstreetmap;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.json.openstreetmap
{
    public class JsonOpenStreetAPI
    {
        [JsonProperty("display_name")]
        public string displayName { get; set; }

        [JsonProperty("address")]
        public JsonAddress address { get; set; }

    }
}
