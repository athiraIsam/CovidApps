using CovidApps.contract.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.presenter.App
{
    public class AppPresenter : IPresenter, IOnListerner
    {
        IView mainView; 
        IModel mainModel; 
        public AppPresenter(IView mainView, IModel mainModel)
        { 
            this.mainView = mainView; 
            this.mainModel = mainModel;
        }
        public void checkLoginRule() 
        { 
            if (this.mainModel != null)
                this.mainModel.checkLoginRule(this); 
        }
        public void showLandingPage() 
        { 
            if (this.mainView != null) 
                this.mainView.showLandingPage();
        }
        public void showLoginPage() 
        { 
            if (this.mainView != null)
                this.mainView.showLoginPage(); 
        }
    }
}
