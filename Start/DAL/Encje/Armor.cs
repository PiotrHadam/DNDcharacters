using MySql.Data.MySqlClient;

namespace Start.DAL.Encje
{
    public class Armor
    {
        #region Własności
        public ushort? ArmorID { get; set; }
        public ushort CharacterID { get; set; }
        public string ArmorName { get; set; }
        public byte ClassBonus { get; set; }
        public string ItemDescription { get; set; }
        #endregion

        #region Konstruktory
        public Armor() { }

        public Armor(MySqlDataReader reader)
        {
            ArmorID = ushort.Parse(reader["armor_id"].ToString());
            CharacterID = ushort.Parse(reader["character_id"].ToString());
            ArmorName = reader["armor_name"].ToString();
            ClassBonus = byte.Parse(reader["armor_class_bonus"].ToString());
            ItemDescription = reader["item_description"].ToString();
        }

        public Armor(ushort characterid, string armorname, byte classbonus, string itemdescription)
        {
            ArmorID = null;
            CharacterID = characterid;
            ArmorName = armorname.Trim();
            ClassBonus = classbonus;
            ItemDescription = itemdescription.Trim();
        }

        public Armor(Armor dalarmor)
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
            var armor = obj as Armor;
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
        public override string ToString()
        {
            return $"{ArmorName}";
        }
        #endregion
    }
}