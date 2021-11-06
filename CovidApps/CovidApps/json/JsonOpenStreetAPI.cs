using CovidApps.api.openstreetmap;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.json.openstreetmap
{
    public class JsonOpenStreetAPI
    {
        [JsonProperty("osm_type")]
        public string osmType { get; set; }

        [JsonProperty("licence")]
        public string license { get; set; }

    }
}
