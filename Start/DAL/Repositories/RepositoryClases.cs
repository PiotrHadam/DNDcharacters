using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Start.DAL.Repositories
{
    using Encje;
    class RepositoryClases
    {
        #region Zapytania
        private const string ALL_CLASSES = "SELECT * FROM `classes`";
        #endregion

        #region Metody
        public static List<Class> ReadAllClases()
        {
            List<Class> classes = new List<Class>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_CLASSES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    classes.Add(new Class(reader));
                connection.Close();
            }
            return classes;
        }
        #endregion
    }
}
