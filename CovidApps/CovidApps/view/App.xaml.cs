using CovidApps.contract.App;
using CovidApps.model.App;
using CovidApps.presenter.App;
using CovidApps.view;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CovidApps
{
    public partial class App : Application,IView
    {
        AppPresenter appPresenter;
        public App()
        {
            InitializeComponent();

            this.appPresenter = new AppPresenter(this, new AppModel()); 
            this.appPresenter.checkLoginRule();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public void showLoginPage()
        {
            MainPage = new NavigationPage(new LoginPage());
        }
        public void showLandingPage() 
        { 
            MainPage = new NavigationPage(new DashboardPage()); 
        }
    }
}
