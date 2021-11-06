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
                if(location==null)
                {
                    onListerner.OnFailure("Unable to get location. Please turn on the location");
                    return;
                }
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
                LocationInfo locationInfo = await RefitQuery.getLocationFromCoordinates(location);
                if (location == null)
                {
                    onListerner.OnFailure("Error while fetching the information");
                    return;
                }

                getCovidRecord(locationInfo);
            }
            catch (Exception e)
            {
                onListerner.OnFailure(e.Message);
            }
        }
        private async void getCovidRecord(LocationInfo locationInfo)
        {
            try { 
            DayOfWeek weekStart = DayOfWeek.Sunday;
            DateTime startingDate = DateTime.Today;

            while (startingDate.DayOfWeek != weekStart)
                startingDate = startingDate.AddDays(-1);

            string previousWeekStart = startingDate.AddDays(-7).ToString("yyyy-MM-dd");
            string previousWeekEnd = startingDate.AddDays(-1).ToString("yyyy-MM-dd");

            records = await RefitQuery.getCovidRecord(locationInfo.countryName, previousWeekStart, previousWeekEnd);
                
                if(records == null)
                {
                    onListerner.OnFailure("Error while fecthing the information");
                    return;
                }
                onListerner.OnGetRecordSuccess(records);
            }
            catch (Exception e) 
            { 
                onListerner.OnFailure("Error while fecthing the information"); 
                Console.WriteLine("Error:" + e.InnerException.Message); 
            }
        }
    }


}
