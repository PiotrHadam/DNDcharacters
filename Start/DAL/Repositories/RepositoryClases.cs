using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Start.DAL.Repositories
{
    using Encje;
    class RepositoryClases
    {
        #region Zapytania
        private const string ALL_CLASSES = "SELECT * FROM classes";
        #endregion

        #region Metody
        public static List<DALClass> ReadAllClases()
        {
            List<DALClass> classes = new List<DALClass>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_CLASSES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    classes.Add(new DALClass(reader));
                connection.Close();
            }
            return classes;
        }
        #endregion
    }
}
