using CovidApps.contract;
using CovidApps.contract.Map;
using CovidApps.model.Map;
using CovidApps.presenter.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CovidApps.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage,IView
    {
        MapPresenter presenter;
        public MapPage()
        {
            InitializeComponent();
            this.presenter = new MapPresenter(this, new MapModel());
            this.presenter.getCurrentLocation();
        }

        public void onGetCurrentLocationSuccess(LocationInfo locationInfo)
        {
            if(locationInfo!=null)
            {
                mapCountryName.Text = locationInfo.countryName;
                mapAddress.Text = locationInfo.address;
                mapLatitude.Text = locationInfo.latitude;
                mapLongitude.Text = locationInfo.longitude;
            }
        }
    }
}