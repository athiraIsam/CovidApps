using CovidApps.contract.LoginPage;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.presenter.Login
{
    public class LoginPresenter : IPresenter ,IListerner
    {
        IView mainView; 
        IModel mainModel; 
        
        public LoginPresenter(IView view, IModel model)
        { 
            this.mainView = view; 
            this.mainModel = model; 
        }
        public void OnLogin(contract.LoginInfo loginInfo) 
        { 
            if (this.mainModel != null)
                mainModel.OnLoginChecker(this, loginInfo); 
        }
        public void OnLoginFailure(string error) 
        { 
            if (this.mainView != null)
                this.mainView.OnLoginFailure(error); 
        }
        public void OnLoginSuccess() { 
            if (this.mainView != null) 
                this.mainView.OnLoginSuccess(); 
        }
    }
}
