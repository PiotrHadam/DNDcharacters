using MySql.Data.MySqlClient;

namespace Start.DAL.Encje
{
    public class Race
    {
        #region Własności
        public byte RaceID { get; set; }
        public string Name { get; set; }
        public byte CharsimaThrowBonus { get; set; }
        public byte ConstitutionThrowBonus { get; set; }
        public byte DexterityBonus { get; set; }
        public byte IntelligenceThrowBonus { get; set; }
        public byte StrengthThrowBonus { get; set; }
        public byte WisdomThrowBonus { get; set; }
        #endregion

        #region Konstruktory
        public Race() { }

        public Race(MySqlDataReader reader)
        {
            RaceID = byte.Parse(reader["race_id"].ToString());
            Name = reader["race_name"].ToString();
            ConstitutionThrowBonus = byte.Parse(reader["constitution_throw_bonus"].ToString());
            CharsimaThrowBonus = byte.Parse(reader["charisa_throw_bonus"].ToString());
            DexterityBonus = byte.Parse(reader["dexterity_bonus"].ToString());
            IntelligenceThrowBonus = byte.Parse(reader["inteligence_throw_bonus"].ToString());
            StrengthThrowBonus = byte.Parse(reader["stregth_throw_bonus"].ToString());
            WisdomThrowBonus = byte.Parse(reader["wisdom_throw_bonus"].ToString());
        }
        #endregion
        public override string ToString()
        {
            return Name;
        }
    }
}