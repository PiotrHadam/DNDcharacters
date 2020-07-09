using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.DAL
{
    class DBConnection
    {
        #region Właściwości
        private static MySqlConnectionStringBuilder stringBuilder;

        public static string Nickname { get { return "root"; } private set {; } }
        private static string Password { get{ return ""; } set {; } }
        public static string Server { get {
                { return "localhost"; }
            } set {; } }
        private static string Database { get { return "dnd_characters2"; } set {; } }
        private static uint Port { get { return 3306; } set {; } }

        public static DBConnection Instance
        {
            get => new DBConnection();
        }

        public MySqlConnection Connection => new MySqlConnection(stringBuilder.ToString());
        #endregion

        private DBConnection()
        {
            stringBuilder = new MySqlConnectionStringBuilder
            {
                UserID = Nickname,
                Password = Password,
                Server = Server,
                Database = Database,
                Port = Port,
                CharacterSet = "utf8"
            };
        }

        public static void Login(string user, string password)
        {
            Nickname = user;
            Password = password;
        }

        public static bool LoginAsRoot()
        {
            try
            {
                Nickname = "root";
                Password = "";
                Server = "localhost";
                Database = "dnd_characters";
                Port = 3306;
                return true;
            }
            catch { return false; }
        }
    }
}
