using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.DAL.Encje
{
    class DALRace
    {
        #region Własności
        public sbyte RaceID { get; set; }
        public string RaceName { get; set; }
        public sbyte CharismaBonus { get; set; }
        public sbyte ConstitutionThrowBonus { get; set; }
        public sbyte DexterityBonus { get; set; }
        public sbyte IntelligenceThrowBonus { get; set; }
        public sbyte StrengthThrowBonus { get; set; }
        public sbyte WisdomThrowBonus { get; set; }
        #endregion

        #region Konstruktory
        public DALRace(MySqlDataReader reader)
        {
            RaceID = sbyte.Parse(reader["race_id"].ToString());
            RaceName = reader["race_name"].ToString();
            ConstitutionThrowBonus = sbyte.Parse(reader["constitution_throw_bonus"].ToString());
            DexterityBonus = sbyte.Parse(reader["dexterity_bonus"].ToString());
            IntelligenceThrowBonus = sbyte.Parse(reader["inteligence_throw_bonus"].ToString());
            StrengthThrowBonus = sbyte.Parse(reader["stregth_throw_bonus"].ToString());
            WisdomThrowBonus = sbyte.Parse(reader["wisdom_throw_bonus"].ToString());
        }
        #endregion
    }
}