using CovidApps.api.openstreetmap;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.json.openstreetmap
{
    public class JsonOpenStreetAPI
    {
        [JsonProperty("place_id")]
        public int placeId { get; set; }

        [JsonProperty("licence")]
        public string license { get; set; }

    }
}
