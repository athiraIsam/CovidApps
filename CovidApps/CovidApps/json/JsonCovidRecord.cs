using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace CovidApps.json.covid19
{
    public class JsonCovidRecord
    {
      
        [JsonProperty("Country")]
        public string country { get; set; }

        [JsonProperty("Confirmed")]
        public int confirmed { get; set; }

        [JsonProperty("Deaths")]
        public int deaths { get; set; }

        [JsonProperty("Recovered")]
        public int recovered { get; set; }

        [JsonProperty("Active")]
        public int active { get; set; }

        [JsonProperty("Date")]
        public DateTime date { get; set; }
    }
}
