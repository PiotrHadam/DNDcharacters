using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.DAL.Encje
{
    class User
    {
        public string UserID { get; private set; }
        public string Password { get; private set; }

        public User(MySqlDataReader dataReader)
        {
            UserID = dataReader["login"].ToString();
            Password = dataReader["password"].ToString();
        }
    }
}
