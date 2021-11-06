using CovidApps.api.covid19;
using CovidApps.api.openstreetmap;
using CovidApps.json.covid19;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CovidApps.contract
{
    public class RefitQuery
    {
        public static async Task<LocationInfo> getLocationFromCoordinates(Location location)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
            };
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://nominatim.openstreetmap.org")
            };

            var restAdapter = RestService.For<OpenStreetMapAPIServices>(httpClient);

            var response = await restAdapter.GetLocationInfo(location.Latitude.ToString(), location.Longitude.ToString());

            if (response == null)
                return null;

            LocationInfo locationInfo = new LocationInfo()
            {
                countryName = response.address.country,
                latitude = location.Latitude.ToString(),
                longitude = location.Longitude.ToString(),
                address = response.displayName
            };

            return locationInfo;
        }

        public static async Task<List<JsonCovidRecord>> getCovidRecord(string countryName,
            string previousWeekStart, string previousWeekEnd)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
            };

            var httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://api.covid19api.com") };

            var restAdapter = RestService.For<CovidAPIServices>(httpClient);

            var response = await restAdapter.GetCovidRecord(countryName, previousWeekStart, previousWeekEnd);

            if (response == null)
                return null;

            return response;
        }
    }
}
