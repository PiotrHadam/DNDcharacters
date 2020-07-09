using MySql.Data.MySqlClient;
using System;

namespace Start.DAL.Encje
{
    public class Spell : IComparable<Spell>
    {
        #region Własności
        public byte? SpellID { get; set; }
        public string SpellName { get; set; }
        public byte RequiredLvl { get; set; }
        public string Domain { get; set; }
        public string CastingTime { get; set; }
        public string SpellRange { get; set; }
        public string Duration { get; set; }
        public string Damage { get; set; }
        public byte IsBardSpell { get; set; }
        public byte IsClericSpell { get; set; }
        public byte IsDruidSpell { get; set; }
        public byte IsPaladinSpell { get; set; }
        public byte IsRangerSpell { get; set; }
        public byte IsSorcererSpell { get; set; }
        public byte IsWarlockSpell { get; set; }
        public byte IsWizardSpell { get; set; }
        public string Description { get; set; }
        #endregion

        #region Konstruktory
        public Spell(MySqlDataReader reader)
        {
            SpellID = byte.Parse(reader["spell_id"].ToString());
            SpellName = reader["spell_name"].ToString();
            RequiredLvl = byte.Parse(reader["required_lvl"].ToString());
            Domain = reader["domain"].ToString();
            CastingTime = reader["casting_time"].ToString();
            SpellRange = reader["spell_range"].ToString();
            Duration = reader["duration"].ToString();
            Damage = reader["damage"].ToString();
            IsBardSpell = byte.Parse(reader["is_bard_spell"].ToString());
            IsClericSpell = byte.Parse(reader["is_cleric_spell"].ToString());
            IsDruidSpell = byte.Parse(reader["is_druid_spell"].ToString());
            IsPaladinSpell = byte.Parse(reader["is_paladin_spell"].ToString());
            IsRangerSpell = byte.Parse(reader["is_ranger_spell"].ToString());
            IsSorcererSpell = byte.Parse(reader["is_sorcerer_spell"].ToString());
            IsWarlockSpell = byte.Parse(reader["is_warlock_spell"].ToString());
            IsWizardSpell = byte.Parse(reader["is_wizzard_spell"].ToString());
            Description = reader["description"].ToString();
        }

        public int CompareTo(Spell other) {
            return this.RequiredLvl.CompareTo(other.RequiredLvl);
        }
        #endregion


    }
}