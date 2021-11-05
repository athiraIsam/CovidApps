using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace CovidApps.database
{
    public class LoginDataDB
    {
        SQLiteConnection conn; 
        string fileLocation;
        
        public LoginDataDB()
        { 
            fileLocation = FileSystem.AppDataDirectory + "/database";
            conn = new SQLiteConnection(fileLocation); 
        }
        public LoginData getdataById() 
        { 
            LoginData login = new LoginData(); 
            try {
                conn.CreateTable<LoginData>(); 
                login = conn.Get<LoginData>(1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            } 
            return login;
        }
        public void insertData(LoginData login)
        { 
            try { 
                conn.CreateTable<LoginData>();
                conn.Insert(login);
            } 
            catch (Exception e)
            { 
                Console.WriteLine(e);
            }
        }
        public void deleteData()
        {
            File.Delete(fileLocation); 
        }
        public void updateData(LoginData login)
        {
            conn.Update(login);
        }
    }
}
