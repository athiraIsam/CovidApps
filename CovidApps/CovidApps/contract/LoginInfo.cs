using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.contract
{
    public class LoginInfo
    {
        private string userName;
        private string dateOfbirth;

        public string getUserName() { return userName; }
        public void setUserName(string userName) { this.userName = userName; }
        public string getDateOfBirth() { return dateOfbirth; }
        public void setDateOfBirth(string dateOfBirth) { this.dateOfbirth = dateOfBirth; }
    }
}
