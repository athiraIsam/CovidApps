using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApps.api.openstreetmap
{
    [Headers("User-Agent: :Mozilla/5.0 (Linux; Android 12) AppleWebKit/537.36 " +
        "(KHTML, like Gecko) Chrome/95.0.4638.50 Mobile Safari/537.36")]
    public interface OpenStreetMapAPIServices
    {
        [Get("/reverse?format=json&lat={lat}&lon={lon}")]
        Task<json.openstreetmap.JsonOpenStreetAPI> GetLocationInfo([AliasAs("lat")] string latitude,[AliasAs("lon")] string longitude);

    }
}
