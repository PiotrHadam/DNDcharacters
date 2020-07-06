using MySql.Data.MySqlClient;

namespace Start.DAL.Encje
{
    class DALSpell
    {
        #region Własności
        public sbyte? SpellID { get; set; }
        public string SpellName { get; set; }
        public sbyte RequiredLvl { get; set; }
        public string Domain { get; set; }
        public string CastingTime { get; set; }
        public string SpellRange { get; set; }
        public string Duration { get; set; }
        public string Damage { get; set; }
        public sbyte IsBardSpell { get; set; }
        public sbyte IsClericSpell { get; set; }
        public sbyte IsDruidSpell { get; set; }
        public sbyte IsPaladinSpell { get; set; }
        public sbyte IsRangerSpell { get; set; }
        public sbyte IsSorcererSpell { get; set; }
        public sbyte IsWarlockSpell { get; set; }
        public sbyte IsWizardSpell { get; set; }
        public string Description { get; set; }
        #endregion

        #region Konstruktory
        public DALSpell(MySqlDataReader reader)
        {
            SpellID = sbyte.Parse(reader["spell_id"].ToString());
            SpellName = reader["spell_name"].ToString();
            RequiredLvl = sbyte.Parse(reader["required_lvl"].ToString());
            Domain = reader["domain"].ToString();
            CastingTime = reader["castingTime"].ToString();
            SpellRange = reader["spell_range"].ToString();
            Duration = reader["duration"].ToString();
            Damage = reader["damage"].ToString();
            IsBardSpell = sbyte.Parse(reader["is_bard_spell"].ToString());
            IsClericSpell = sbyte.Parse(reader["is_cleric_spell"].ToString());
            IsDruidSpell = sbyte.Parse(reader["is_druid_spell"].ToString());
            IsPaladinSpell = sbyte.Parse(reader["is_paladin_spell"].ToString());
            IsRangerSpell = sbyte.Parse(reader["is_ranger_spell"].ToString());
            IsSorcererSpell = sbyte.Parse(reader["is_sorcerer_spell"].ToString());
            IsWarlockSpell = sbyte.Parse(reader["is_warlock_spell"].ToString());
            IsWizardSpell = sbyte.Parse(reader["is_wizzard_spell"].ToString());
            Description = reader["description"].ToString();
        }
        #endregion
    }
}