using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.DAL.Encje
{
    class DALArmor
    {
        #region Własności
        public sbyte? ArmorID { get; set; }
        public sbyte CharacterID { get; set; }
        public string ArmorName { get; set; }
        public sbyte ClassBonus { get; set; }
        public string ItemDescription { get; set; }
        #endregion

        #region Konstruktory
        public DALArmor(MySqlDataReader reader)
        {
            ArmorID = sbyte.Parse(reader["armor_id"].ToString());
            CharacterID = sbyte.Parse(reader["character_id"].ToString());
            ArmorName = reader["armor_name"].ToString();
            ClassBonus = sbyte.Parse(reader["armor_class_bonus"].ToString());
            ItemDescription = reader["item_description"].ToString();
        }

        public DALArmor(sbyte characterid, string armorname, sbyte classbonus, string itemdescription)
        {
            ArmorID = null;
            CharacterID = characterid;
            ArmorName = armorname.Trim();
            ClassBonus = classbonus;
            ItemDescription = itemdescription.Trim();
        }

        public DALArmor(DALArmor dalarmor)
        {
            ArmorID = dalarmor.ArmorID;
            CharacterID = dalarmor.CharacterID;
            ArmorName = dalarmor.ArmorName;
            ClassBonus = dalarmor.ClassBonus;
            ItemDescription = dalarmor.ItemDescription;
        }
        #endregion

        #region Metody
        public string ToInsert()
        {
            return $"({CharacterID}, '{ArmorName}', {ClassBonus}, '{ItemDescription}')";
        }

        public string ToDelete()
        {
            return $"{ArmorID}";
        }

        public override bool Equals(object obj)
        {
            var armor = obj as DALArmor;
            if (armor is null) return false;
            if (CharacterID != armor.CharacterID) return false;
            if (ArmorName != armor.ArmorName) return false;
            if (ClassBonus != armor.ClassBonus) return false;
            if (ItemDescription != armor.ItemDescription) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}