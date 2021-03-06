﻿using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Start.DAL.Repositories
{
    using Encje;
    class RepositoryArmors
    {
        #region Zapytania
        private const string ALL_ARMORS = "SELECT * FROM `armors`";
        private const string ADD_ARMOR = "INSERT INTO `armors` (character_id, armor_name, armor_class_bonus, item_description) VALUES ";
        private const string DELETE_ARMOR = "DELETE FROM `armors` WHERE armor_id = ";
        #endregion

        #region Metody
        public static List<Armor> ReadAllArmors()
        {
            List<Armor> armors = new List<Armor>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    MySqlCommand command = new MySqlCommand(ALL_ARMORS, connection);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        armors.Add(new Armor(reader));
                    connection.Close();
                }
            }
            catch { }
            return armors;
        }

        public static bool AddToDatabase(Armor armor)
        {
            bool state = false;
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    MySqlCommand command = new MySqlCommand($"{ADD_ARMOR} {armor.ToInsert()}", connection);
                    connection.Open();
                    var id = command.ExecuteNonQuery();
                    state = true;
                    armor.ArmorID = (ushort)command.LastInsertedId;
                    connection.Close();
                }
            }
            catch { }
            return state;
        }

        public static bool EditArmor(Armor armor, ushort? armorID)
        {
            bool state = false;
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    string EDIT_ARMOR = $"UPDATE armors SET armor_name='{armor.ArmorName}', class_bonus={armor.ClassBonus}, item_description={armor.ItemDescription} WHERE armor_id={armorID}";

                    MySqlCommand command = new MySqlCommand(EDIT_ARMOR, connection);
                    connection.Open();
                    var n = command.ExecuteNonQuery();
                    if (n == 1) state = true;

                    connection.Close();
                }
            }
            catch { }
            return state;
        }

        public static bool DeleteFromDatabase(Armor armor)
        {
            bool state = false;
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    MySqlCommand command = new MySqlCommand($"{DELETE_ARMOR} {armor.ToDelete()}", connection);
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
