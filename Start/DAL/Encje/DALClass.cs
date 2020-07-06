using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.DAL.Encje
{
    class DALClass
    {
        #region Własności
        public sbyte ClassID { get; set; }
        public string ClassName { get; set; }
        public string PrimaryAbility { get; set; }
        public string SaveThrow1 { get; set; }
        public string SaveThrow2 { get; set; }
        public sbyte HaveSpellcastAbility { get; set; }
        #endregion

        #region Konstruktory
        public DALClass(MySqlDataReader reader)
        {
            ClassID = sbyte.Parse(reader["class_id"].ToString());
            ClassName = reader["class_name"].ToString();
            PrimaryAbility = reader["primary_ability"].ToString();
            SaveThrow1 = reader["save_throw_1"].ToString();
            SaveThrow2 = reader["save_throw_2"].ToString();
            HaveSpellcastAbility = sbyte.Parse(reader["have_spellcast_abiliy"].ToString());
        }
        #endregion
    }
}
