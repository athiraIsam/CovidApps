using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.contract.LoginPage
{
    public interface IView
    {
        void OnLoginSuccess(); 
        void OnLoginFailure(string error);
    }
    public interface IModel
    {
        void OnLoginChecker(IListerner listerner, LoginInfo loginInfo);
    }

    public interface IPresenter
    {
        void OnLogin(LoginInfo loginInfo);
    }
    public interface IListerner
    {
        void OnLoginSuccess(); void OnLoginFailure(string error);
    }
}
