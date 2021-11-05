using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CovidApps.api.openstreetmap
{
    [Headers("User-Agent: :request")]
    public interface OpenStreetMapAPIServices
    {
        [Get("/reverse?lat=40.7127281&lon=-74.0060152&zoom=10&format=json")]
        Task<json.openstreetmap.JsonOpenStreetAPI> GetLocationInfo();

    }
}
