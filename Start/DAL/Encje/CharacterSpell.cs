using MySql.Data.MySqlClient;

namespace Start.DAL.Encje
{
    class CharacterSpell
    {
        #region Własności
        public ushort? LinkID { get; set; }
        public ushort CharacterID { get; set; }
        public byte SpellID { get; set; }

        #endregion

        #region Konstruktor
        public CharacterSpell() { }

        public CharacterSpell(MySqlDataReader reader)
        {
            LinkID = ushort.Parse(reader["link_id"].ToString());
            CharacterID = ushort.Parse(reader["character_id"].ToString());
            SpellID = byte.Parse(reader["spell_id"].ToString());
        }

        public CharacterSpell(ushort characterid, byte spellid)
        {
            LinkID = null;
            CharacterID = characterid;
            SpellID = spellid;
        }

        public CharacterSpell(CharacterSpell characterspell)
        {
            LinkID = characterspell.LinkID;
            CharacterID = characterspell.CharacterID;
            SpellID = characterspell.SpellID;
        }
        #endregion

        #region Metody
        public string ToInsert()
        {
            return $"({CharacterID}, {SpellID})";
        }

        public string ToDelete()
        {
            return $"{LinkID}";
        }

        public override bool Equals(object obj)
        {
            var charspell = obj as CharacterSpell;
            if (charspell is null) return false;
            if (CharacterID != charspell.CharacterID) return false;
            if (SpellID != charspell.SpellID) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
