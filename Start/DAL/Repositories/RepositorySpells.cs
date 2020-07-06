using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Start.DAL.Repositories
{
    using Encje;
    class RepositorySpells
    {
        #region Zapytania
        private const string ALL_SPELLS = "SELECT * FROM spells";
        #endregion

        #region Metody
        public static List<Spell> ReadAllSpells()
        {
            List<Spell> spells = new List<Spell>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_SPELLS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    spells.Add(new Spell(reader));
                connection.Close();
            }
            return spells;
        }
        #endregion
    }
}
