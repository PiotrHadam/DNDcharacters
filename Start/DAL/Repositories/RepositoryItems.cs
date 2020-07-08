using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Start.DAL.Repositories
{
    using Encje;
    class RepositoryItems
    {
        #region Zapytania
        private const string ALL_ITEMS = "SELECT * FROM `items`";
        private const string ADD_ITEM = "INSERT INTO `items` (character_id, item_name, item_description) VALUES ";
        private const string DELETE_ITEM = "DELETE FROM `items` WHERE item_id = ";
        #endregion

        #region Metody
        public static List<Item> ReadAllItems()
        {
            List<Item> items = new List<Item>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    MySqlCommand command = new MySqlCommand(ALL_ITEMS, connection);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        items.Add(new Item(reader));
                    connection.Close();
                }
            }
            catch { }
            return items;
        }

        public static bool AddToDatabase(Item item)
        {
            bool state = false;
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    MySqlCommand command = new MySqlCommand($"{ADD_ITEM} {item.ToInsert()}", connection);
                    connection.Open();
                    var id = command.ExecuteNonQuery();
                    state = true;
                    item.ItemID = (ushort)command.LastInsertedId;
                    connection.Close();
                }
            }
            catch { }
            return state;
        }

        public static bool EditItem(Item item, ushort? itemID)
        {
            bool state = false;
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    string EDIT_ITEM = $"UPDATE items SET item_name='{item.ItemName}', item_description={item.ItemDescription} WHERE item_id={itemID}";

                    MySqlCommand command = new MySqlCommand(EDIT_ITEM, connection);
                    connection.Open();
                    var n = command.ExecuteNonQuery();
                    if (n == 1) state = true;

                    connection.Close();
                }
            }
            catch { }
            return state;
        }

        public static bool DeleteFromDatabase(Item item)
        {
            bool state = false;
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    MySqlCommand command = new MySqlCommand($"{DELETE_ITEM} {item.ToDelete()}", connection);
                    connection.Open();
                    _ = command.ExecuteNonQuery();
                    state = true;
                    connection.Close();
                }
            }
            catch { }
            return state;
        }
        #endregion
    }
}
