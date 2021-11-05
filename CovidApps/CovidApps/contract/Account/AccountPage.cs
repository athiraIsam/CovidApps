using CovidApps.database;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.contract.Account
{

    public interface IView
    {
        void OnGetIdSucess(LoginInfo loginInfo);
        void OnDeleteIdSuccess();
        void OnUpdateIdSuccess();
        void OnFailure(string error);
    }
    public interface IModel
    {
        void deleteId(IOnListerner listerner);
        void updateId(IOnListerner listerner, LoginData login);
        void getId(IOnListerner listerner);
    }

    public interface IPresenter
    {
        void deleteId();
        void updateId(LoginData login);
        void getId();
    }
    public interface IOnListerner
    {
        void OnGetIdSucess(LoginInfo login);
        void OnDeleteIdSuccess();
        void OnUpdateIdSuccess();
        void OnFailure(string error);
    }
}
