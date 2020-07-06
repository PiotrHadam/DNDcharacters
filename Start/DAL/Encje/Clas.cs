using MySql.Data.MySqlClient;

namespace Start.DAL.Encje
{
    class Clas
    {
        #region Własności
        public byte ClassID { get; set; }
        public string ClassName { get; set; }
        public string PrimaryAbility { get; set; }
        public string SaveThrow1 { get; set; }
        public string SaveThrow2 { get; set; }
        public byte HaveSpellcastAbility { get; set; }
        #endregion

        #region Konstruktory
        public Clas(MySqlDataReader reader)
        {
            ClassID = byte.Parse(reader["class_id"].ToString());
            ClassName = reader["class_name"].ToString();
            PrimaryAbility = reader["primary_ability"].ToString();
            SaveThrow1 = reader["save_throw_1"].ToString();
            SaveThrow2 = reader["save_throw_2"].ToString();
            HaveSpellcastAbility = byte.Parse(reader["have_spellcast_abiliy"].ToString());
        }
        #endregion
    }
}
