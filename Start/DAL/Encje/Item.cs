using MySql.Data.MySqlClient;

namespace Start.DAL.Encje
{
    class Item
    {
        #region Własności
        public ushort? ItemID { get; set; }
        public ushort CharacterID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        #endregion

        #region Konstruktory
        public Item() { }

        public Item(MySqlDataReader reader)
        {
            ItemID = ushort.Parse(reader["item_id"].ToString());
            CharacterID = ushort.Parse(reader["character_id"].ToString());
            ItemName = reader["item_name"].ToString();
            ItemDescription = reader["item_description"].ToString();
        }

        public Item(ushort characterid, string itemname, string itemdescription)
        {
            ItemID = null;
            CharacterID = characterid;
            ItemName = itemname.Trim();
            ItemDescription = itemdescription.Trim();
        }

        public Item(Item dalitem)
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
            var item = obj as Item;
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

        public override string ToString() {
            return $"{ItemName}";
        }
        #endregion
    }
}
