using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.DAL.Encje
{
    class DALItem
    {
        #region Własności
        public sbyte? ItemID { get; set; }
        public sbyte CharacterID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        #endregion

        #region Konstruktory
        public DALItem(MySqlDataReader reader)
        {
            ItemID = sbyte.Parse(reader["item_id"].ToString());
            CharacterID = sbyte.Parse(reader["character_id"].ToString());
            ItemName = reader["item_name"].ToString();
            ItemDescription = reader["item_description"].ToString();
        }

        public DALItem(sbyte characterid, string itemname, string itemdescription)
        {
            ItemID = null;
            CharacterID = characterid;
            ItemName = itemname.Trim();
            ItemDescription = itemdescription.Trim();
        }

        public DALItem(DALItem dalitem)
        {
            ItemID = dalitem.ItemID;
            CharacterID = dalitem.CharacterID;
            ItemName = dalitem.ItemName;
            ItemDescription = dalitem.ItemDescription;
        }
        #endregion

        #region Metody
        public string ToInsert()
        {
            return $"({CharacterID}, '{ItemName}', '{ItemDescription}')";
        }

        public string ToDelete()
        {
            return $"{ItemID}";
        }

        public override bool Equals(object obj)
        {
            var item = obj as DALItem;
            if (item is null) return false;
            if (CharacterID != item.CharacterID) return false;
            if (ItemName != item.ItemName) return false;
            if (ItemDescription != item.ItemDescription) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
