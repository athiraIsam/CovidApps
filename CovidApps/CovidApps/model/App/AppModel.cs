using CovidApps.contract.App;
using CovidApps.database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace CovidApps.model.App
{
    public class AppModel : IModel
    {
        public void checkLoginRule(IOnListerner listerner)
        {
            string fileLocation = FileSystem.AppDataDirectory + "/database"; 
            
            try { using (SQLiteConnection conn = new SQLiteConnection(fileLocation)) 
                { 
                    conn.CreateTable<LoginData>(); 
                    if (conn.Get<LoginData>(1) != null) 
                    { 
                        listerner.showLandingPage(); 
                    } 
                } 
            } 
            catch (Exception e) 
            { listerner.showLoginPage(); }
        }
    }
}
