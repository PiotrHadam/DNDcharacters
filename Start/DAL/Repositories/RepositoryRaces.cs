using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.DAL.Repositories
{
    using Encje;
    class RepositoryRaces
    {
        #region Zapytania
        private const string ALL_RACES = "SELECT * FROM races";
        #endregion

        #region Metody
        public static List<DALRace> ReadAllRaces()
        {
            List<DALRace> races = new List<DALRace>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_RACES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    races.Add(new DALRace(reader));
                connection.Close();
            }
            return races;
        }
        #endregion
    }
}
