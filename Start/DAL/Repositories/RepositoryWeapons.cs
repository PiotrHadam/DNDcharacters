using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Start.DAL.Repositories
{
    using Encje;
    class RepositoryWeapons
    {
        #region Zapytania
        private const string ALL_WEAPONS = "SELECT * FROM weapons";
        private const string ADD_WEAPON = "INSERT INTO weapons (character_id, weapon_name, dmg_dice, dmg_dice_size, attack_range, damage_type, item_description) VALUES ";
        private const string DELETE_WEAPON = "DELETE FROM weapons WHERE weapon_id = ";
        #endregion

        #region Metody
        public static List<Weapon> ReadAllWeapons()
        {
            List<Weapon> weapons = new List<Weapon>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_WEAPONS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    weapons.Add(new Weapon(reader));
                connection.Close();
            }
            return weapons;
        }

        public static bool AddToDatabase(Weapon weapon)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_WEAPON} {weapon.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                weapon.WeaponID = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }

        public static bool EditWeapon(Weapon weapon, sbyte armorID)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_WEAPON = $"UPDATE wepons SET weapon_name='{weapon.WeaponName}', dmg_dice={weapon.DMGDice}, dmg_dice_size={weapon.DMGDiceSize}, attack_range='{weapon.AttackRange}', damage_type='{weapon.DamageType}', item_description={weapon.ItemDescription} WHERE weapon_id={armorID}";

                MySqlCommand command = new MySqlCommand(EDIT_WEAPON, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }

        public static bool DeleteFromDatabase(Weapon weapon)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_WEAPON} {weapon.ToDelete()}", connection);
                connection.Open();
                stan = true;
                connection.Close();
            }
            return stan;
        }
        #endregion
    }
}
