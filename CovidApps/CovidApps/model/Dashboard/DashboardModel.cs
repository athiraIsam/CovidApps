using CovidApps.api.covid19;
using CovidApps.api.openstreetmap;
using CovidApps.contract;
using CovidApps.contract.DashboardPage;
using CovidApps.database;
using CovidApps.json.covid19;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CovidApps.model.Dashboard
{
    public class DashboardModel : IModel
    {
        List<JsonCovidRecord> records;
        IOnListerner onListerner;
        public DashboardModel()
        {
            records = new List<JsonCovidRecord>();
        }

        public void getCovidRecord(IOnListerner listerner)
        {
            this.onListerner = listerner;
            getCurrentLocation();
        }

        private async void getCurrentLocation()
        {

            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                getCountryFromCoordinates(location);

            }

            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }

        }

        private async void getCountryFromCoordinates(Location location)
        {
            try
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

                var response = await restAdapter.GetLocationInfo();

                if (response == null)
                {
                    // return; 
                }

                // Todo- Implement real value. for now unable to get respond. dont know why
                LocationInfo locationInfo = new LocationInfo()
                {
                    countryName = "Malaysia"
                };

                getCovidRecord(locationInfo);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.InnerException.Message);
            }
        }
        private async void getCovidRecord(LocationInfo locationInfo)
        {
            DayOfWeek weekStart = DayOfWeek.Sunday;
            DateTime startingDate = DateTime.Today;

            while (startingDate.DayOfWeek != weekStart)
                startingDate = startingDate.AddDays(-1);

            string previousWeekStart = startingDate.AddDays(-7).ToString("yyyy-MM-dd");
            string previousWeekEnd = startingDate.AddDays(-1).ToString("yyyy-MM-dd");

            try
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
                };
                
                var httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://api.covid19api.com") };

                var restAdapter = RestService.For<CovidAPIServices>(httpClient);
                
                var response = await restAdapter.GetCovidRecord(locationInfo.countryName, previousWeekStart, previousWeekEnd);
                onListerner.OnGetRecordSuccess(response);
            }
            catch (Exception e) { Console.WriteLine("Error:" + e.InnerException.Message); }
        }
    }


}
