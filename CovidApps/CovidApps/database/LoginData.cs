using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApps.database
{
     public class LoginData
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string name { get; set; }
        public bool firstTimeFlag { get; set; }
        public string dateOfBirth { get; set; }
    }
}
