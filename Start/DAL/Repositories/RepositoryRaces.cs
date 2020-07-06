using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Start.DAL.Repositories
{
    using Encje;
    class RepositoryRaces
    {
        #region Zapytania
        private const string ALL_RACES = "SELECT * FROM races";
        #endregion

        #region Metody
        public static List<Race> ReadAllRaces()
        {
            List<Race> races = new List<Race>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_RACES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    races.Add(new Race(reader));
                connection.Close();
            }
            return races;
        }
        #endregion
    }
}
