using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.DAL.Repositories
{
    using Encje;
    class RepositoryUsers
    {
        #region ZAPYTANIA
        private const string ALL_USERS = "select * from `users`";
        #endregion

        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    MySqlCommand command = new MySqlCommand(ALL_USERS, connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        users.Add(new User(dataReader));
                    connection.Close();
                }

            }
            catch { }
            return users;
        }

        public static bool AddUser(string UserID, string Password)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                try
                {
                    MySqlCommand commandcreate = new MySqlCommand($"create user '{UserID}'@'{DBConnection.Server}' identified by '{Password}'", connection);
                    MySqlCommand commandgrantprivilegescharacters = new MySqlCommand($"grant select, insert, delete, update on characters to '{UserID}'@'{DBConnection.Server}'", connection);
                    MySqlCommand commandgrantprivilegesarmors = new MySqlCommand($"grant select, insert, delete, update on armors to '{UserID}'@'{DBConnection.Server}'", connection);
                    MySqlCommand commandgrantprivilegesitems = new MySqlCommand($"grant select, insert, delete, update on items to '{UserID}'@'{DBConnection.Server}'", connection);
                    MySqlCommand commandgrantprivilegesweapons = new MySqlCommand($"grant select, insert, delete, update on weapons to '{UserID}'@'{DBConnection.Server}'", connection);
                    MySqlCommand commandgrantprivilegeslinks = new MySqlCommand($"grant select, insert, delete, update on character_spells to '{UserID}'@'{DBConnection.Server}'", connection);
                    MySqlCommand commandgrantselectclasses = new MySqlCommand($"grant select on classes to '{UserID}'@'{DBConnection.Server}'", connection);
                    MySqlCommand commandgrantselectraces = new MySqlCommand($"grant select on races to '{UserID}'@'{DBConnection.Server}'", connection);
                    MySqlCommand commandgrantselectspells = new MySqlCommand($"grant select on spells to '{UserID}'@'{DBConnection.Server}'", connection);
                    MySqlCommand commandinsertusers = new MySqlCommand($"insert users value ('{UserID}', MD5('{Password}'))", connection);

                    connection.Open();
                    new MySqlCommand($"start transaction", connection).ExecuteNonQuery();
                    commandcreate.ExecuteNonQuery();
                    commandgrantprivilegesarmors.ExecuteNonQuery();
                    commandgrantprivilegescharacters.ExecuteNonQuery();
                    commandgrantprivilegesitems.ExecuteNonQuery();
                    commandgrantprivilegeslinks.ExecuteNonQuery();
                    commandgrantprivilegesweapons.ExecuteNonQuery();
                    commandgrantselectclasses.ExecuteNonQuery();
                    commandgrantselectraces.ExecuteNonQuery();
                    commandgrantselectspells.ExecuteNonQuery();
                    commandinsertusers.ExecuteNonQuery();
                    new MySqlCommand($"commit", connection).ExecuteNonQuery();
                    state = true;
                }
                catch { new MySqlCommand($"rollback", connection).ExecuteNonQuery(); }
                connection.Close();
            }
            return state;
        }

        public static string HashPassword(string password)
        {
            string hashed = "";
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    MySqlCommand command = new MySqlCommand($"select MD5(\"{password}\") PWD", connection);
                    connection.Open();
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        hashed = dataReader["PWD"].ToString();
                    connection.Close();
                }
            }
            catch { }
            return hashed;
        }
    }
}
