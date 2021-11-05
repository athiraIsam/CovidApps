using CovidApps.contract;
using CovidApps.contract.LoginPage;
using CovidApps.model.Login;
using CovidApps.presenter.Login;
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
    public partial class LoginPage : ContentPage,IView
    {
        LoginPresenter loginPresenter;
        public LoginPage()
        {
            InitializeComponent();
            this.loginPresenter = new LoginPresenter(this, new LoginModel());
        }
        public void OnLoginFailure(string error) 
        { 
            loginError.IsVisible = true; 
            loginError.Text = error; 
        }
        public void OnLoginSuccess() 
        { 
            Navigation.PushAsync(new DashboardPage()); 
        }
        private void OnLoginCLicked(object sender, EventArgs e)
        {
            LoginInfo loginInfo = new LoginInfo();

            loginInfo.setUserName(userName.Text);
            loginInfo.setDateOfBirth(dateOfBirth.Date.ToShortDateString()); 
            
            this.loginPresenter.OnLogin(loginInfo); 
        }
    }

}