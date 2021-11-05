using CovidApps.contract;
using CovidApps.contract.LoginPage;
using CovidApps.database;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.model.Login
{
    public class LoginModel : IModel
    {
        public void OnLoginChecker(IListerner listerner, LoginInfo loginInfo)
        {
         
            if (loginInfo != null) 
            {
                if (loginInfo.getUserName() == null) 
                { 
                    listerner.OnLoginFailure("Username cannot be null"); 
                    return;
                } 
                if (loginInfo.getUserName().Length < 3) 
                { 
                    listerner.OnLoginFailure("Username is to short"); 
                    return; 
                } 
                
                LoginData login = new LoginData()
                { 
                    name = loginInfo.getUserName(), 
                    firstTimeFlag = true, 
                    dateOfBirth = loginInfo.getDateOfBirth() 
                };
                
                LoginDataDB loginDataDB = new LoginDataDB();
                loginDataDB.insertData(login); 

                listerner.OnLoginSuccess(); 
            }
        }
    }
}
