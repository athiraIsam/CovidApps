using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.contract.App
{
    public interface IView
    {
        void showLoginPage(); 
        void showLandingPage();
    }
    public interface IModel
    {
        void checkLoginRule(IOnListerner listerner);
    }
    
    public interface IPresenter
    {
        void checkLoginRule();
    }
    public interface IOnListerner
    {
        void showLoginPage();
        void showLandingPage();
    }
}
