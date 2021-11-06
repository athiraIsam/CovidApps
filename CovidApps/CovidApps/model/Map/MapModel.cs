using CovidApps.contract;
using CovidApps.contract.Map;
using System;
using System.Collections.Generic;
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
            LocationInfo locationInfo = new LocationInfo()
            {
                countryName = "Malaysia"
            };
            
            try  
               { 
                 var location = await Geolocation.GetLastKnownLocationAsync();

                 if (location == null)
                 {
                  listerner.OnFailure("Unable to get location.Please turn on the location");
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
