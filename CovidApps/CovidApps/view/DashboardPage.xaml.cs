using CovidApps.contract;
using CovidApps.contract.DashboardPage;
using CovidApps.json.covid19;
using CovidApps.model.Dashboard;
using CovidApps.presenter.Dashboard;
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
    public partial class DashboardPage : TabbedPage,IView
    {
        DashboardPresenter presenter;
        public DashboardPage()
        {
            InitializeComponent();

            this.presenter = new DashboardPresenter(this, new DashboardModel());
            this.presenter.getCovidRecord();
            Children.Add(new MapPage());
            Children.Add(new AccountPage());
        }

        public void OnFailure(string error)
        {
            loading.IsVisible = false;
            DisplayAlert("Warning", error,"OK");

        }

        public void OnGetRecordSuccess(List<JsonCovidRecord> covidRecords)
        {
           
            if (covidRecords == null) 
                return; 
            if (covidRecords.Count == 0)
                return;
            MainListView.ItemsSource = covidRecords; 
            countryName.Text = "List of Past week Covid-19 Case in: " + covidRecords[0].country;
            loading.IsVisible = false;
        }
    }
}