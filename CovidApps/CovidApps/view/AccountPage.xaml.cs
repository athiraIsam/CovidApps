using CovidApps.contract;
using CovidApps.contract.Account;
using CovidApps.database;
using CovidApps.model.Account;
using CovidApps.presenter.Account;
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
    public partial class AccountPage : ContentPage,IView 
    {
        AccountPresenter accountPresenter;
        public AccountPage()
        {
            InitializeComponent();
            this.accountPresenter = new AccountPresenter(this, new AccountModel());
            this.accountPresenter.getId();
        }

        public void OnDeleteIdSuccess()
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        public void OnFailure(string error)
        {
            DisplayAlert("Warning", error, "OK");
        }

        public void OnGetIdSucess(LoginInfo loginInfo)
        {
            userName.Text = loginInfo.getUserName();
            dateBirth.Text = loginInfo.getDateOfBirth();
        }

        public void OnUpdateIdSuccess()
        {
            DisplayAlert("Update","Success", "OK");
            dateBirth.Text = newDate.Date.ToShortDateString();

        }

        private async void deleteImage_Clicked(object sender, EventArgs e) 
        {
            bool answer = await DisplayAlert("Warning!", "Would you like to delete your account?", "Yes", "No");
            if(answer)
                this.accountPresenter.deleteId(); 
        }

        void Date_DateSelected(object sender, DateChangedEventArgs e)
        { 
            dateBirth.Text = e.NewDate.Date.ToShortDateString();
        }
        private void editImage_Clicked(object sender, EventArgs e) 
        {
            newDate.IsVisible = true;
            newDate.Focus(); 
            newDate.DateSelected += Date_DateSelected;
        }
        private async void OnSave_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Warning!", "Would you like to save your changes?", "Yes", "No");
            if (answer)
            {
                LoginData login = new LoginData()
                {
                    name = userName.Text,
                    firstTimeFlag = true,
                    dateOfBirth = dateBirth.Text,
                    Id = 1,
                };

                this.accountPresenter.updateId(login);
            }
        }
    }
}