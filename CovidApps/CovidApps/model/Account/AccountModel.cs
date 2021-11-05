using CovidApps.contract;
using CovidApps.contract.Account;
using CovidApps.database;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.model.Account
{
   public class AccountModel : IModel 
    {
        LoginDataDB loginDataDB;
        public AccountModel()
        {
            loginDataDB = new LoginDataDB();
        }

        public void deleteId(IOnListerner listerner)
        {
            loginDataDB.deleteData();
            listerner.OnDeleteIdSuccess();
        }

        public void getId(IOnListerner listerner)
        {
            LoginData loginData = loginDataDB.getdataById();
            LoginInfo loginInfo = new LoginInfo();

            loginInfo.setUserName(loginData.name);
            loginInfo.setDateOfBirth(loginData.dateOfBirth);

            listerner.OnGetIdSucess(loginInfo);
        }

        public void updateId(IOnListerner listerner, LoginData login)
        {
            loginDataDB.updateData(login);
            listerner.OnUpdateIdSuccess();
        }
    }
}
