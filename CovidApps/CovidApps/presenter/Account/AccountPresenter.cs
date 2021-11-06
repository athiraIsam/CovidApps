using CovidApps.contract;
using CovidApps.contract.Account;
using CovidApps.database;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.presenter.Account
{
    public class AccountPresenter : IPresenter,IOnListerner

    {
        IView mainView;
        IModel mainModel;

        public AccountPresenter(IView view, IModel model)
        {
            this.mainView = view;
            this.mainModel = model;
        }

        public void deleteId()
        {
            if (this.mainModel != null)
                this.mainModel.deleteId(this);
        }

        public void getId()
        {
            if (this.mainModel != null)
                this.mainModel.getId(this);
        }

        public void OnDeleteIdSuccess()
        {
            if (this.mainView != null)
                this.mainView.OnDeleteIdSuccess();
        }

        public void OnFailure(string error)
        {
            if (this.mainView != null)
                this.mainView.OnFailure(error);
        }

        public void OnGetIdSucess(LoginInfo login)
        {
            if (this.mainView != null)
                this.mainView.OnGetIdSucess(login);
        }

        public void OnUpdateIdSuccess()
        {
            if (this.mainView != null)
                this.mainView.OnUpdateIdSuccess();
        }
        public void updateId(LoginData login)
        {
            if (this.mainModel != null)
                this.mainModel.updateId(this, login);
        }
    }
}
