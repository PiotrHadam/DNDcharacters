using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Start.DAL.Repositories
{
    using Encje;

    class RepositoryCharacterSpells
    {
        #region Zapytania
        private const string ALL_LINKS = "SELECT * FROM character_spells";
        private const string ADD_LINK = "INSERT INTO character_spells (character_id, spell_id) VALUES ";
        private const string DELETE_LINK = "DELETE FROM character_spells WHERE link_id = ";
        #endregion

        #region Metody
        public static List<CharacterSpell> ReadAllLinks()
        {
            List<CharacterSpell> links = new List<CharacterSpell>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_LINKS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    links.Add(new CharacterSpell(reader));
                connection.Close();
            }
            return links;
        }

        public static bool AddToDatabase(CharacterSpell link)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_LINK} {link.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                link.LinkID = (byte)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }

        public static bool EditLink(CharacterSpell link, byte linkID)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_LINK = $"UPDATE items SET character_id='{link.CharacterID}', spell_id={link.SpellID} WHERE item_id={linkID}";

                MySqlCommand command = new MySqlCommand(EDIT_LINK, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }

        public static bool DeleteFromDatabase(CharacterSpell link)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_LINK} {link.ToDelete()}", connection);
                connection.Open();
                stan = true;
                connection.Close();
            }
            return stan;
        }
        #endregion
    }
}
