using CovidApps.api.openstreetmap;
using CovidApps.contract;
using CovidApps.contract.Map;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CovidApps.model.Map
{
    public class MapModel : IModel
    {
        IOnListerner listerner;
        public void getCurrentLocation(IOnListerner listerner)
        {
            this.listerner = listerner;
            getCurrentLocation();
        }

        private async void getCurrentLocation()
        {
          
            try  
               { 
                 var location = await Geolocation.GetLastKnownLocationAsync();

                 if (location == null)
                 {
                  listerner.OnFailure("Unable to get location.Please turn on the location");
                  return;              
                 }

                LocationInfo locationInfo = await RefitQuery.getLocationFromCoordinates(location);
                if(location==null)
                {
                    listerner.OnFailure("Error while fetching the information");
                    return;
                }
                this.listerner.onGetCurrentLocationSuccess(locationInfo);      
             }

              catch (FeatureNotSupportedException fnsEx)         
              {                
                  // Handle not supported on device exception
              }
     
            
        }
    }
}
