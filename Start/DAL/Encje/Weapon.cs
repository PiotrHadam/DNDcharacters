using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;
using Start.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Start.DAL.Encje
{
    public class Weapon
    {
        #region Własności
        public ushort? WeaponID { get; set; }
        public ushort CharacterID { get; set; }
        public string WeaponName { get; set; }
        public Dice DMG { get; set; }
        public string AttackRange { get; set; }
        public string DamageType { get; set; }
        public string ItemDescription { get; set; }
        #endregion

        
        #region Konstruktory
        public Weapon(MySqlDataReader reader)
        {
            WeaponID = ushort.Parse(reader["weapon_id"].ToString());
            CharacterID = ushort.Parse(reader["character_id"].ToString());
            WeaponName = reader["weapon_name"].ToString();
            DMG = new Dice(byte.Parse(reader["dmg_dice"].ToString()), byte.Parse(reader["dmg_dice_size"].ToString()));
            AttackRange = reader["attack_range"].ToString();
            DamageType = reader["damage_type"].ToString();
            ItemDescription = reader["item_description"].ToString();
        }

        public Weapon(ushort characterid, string weaponname, byte dmgdice, byte dmgdicesize, string attackrange, string damagetype, string itemdescription)
        {
            WeaponID = null;
            CharacterID = characterid;
            WeaponName = weaponname.Trim();
            DMG = new Dice(dmgdice, dmgdicesize);
            AttackRange = attackrange.Trim();
            DamageType = damagetype.Trim();
            ItemDescription = itemdescription.Trim();
        }

        public Weapon(Weapon dalweapon)
        {
            WeaponID = dalweapon.WeaponID;
            CharacterID = dalweapon.CharacterID;
            WeaponName = dalweapon.WeaponName;
            DMG = dalweapon.DMG;
            AttackRange = dalweapon.AttackRange;
            DamageType = dalweapon.DamageType;
            ItemDescription = dalweapon.ItemDescription;
        }
        #endregion

        #region Metody
        public string ToInsert()
        {
            return $"({CharacterID}, '{WeaponName}', {DMG}, '{AttackRange}', '{DamageType}', '{ItemDescription}')";
        }

        public string ToDelete()
        {
            return $"{WeaponID} {DMG}";
        }

        public override bool Equals(object obj)
        {
            var weapon = obj as Weapon;
            if (weapon is null) return false;
            if (CharacterID != weapon.CharacterID) return false;
            if (WeaponName != weapon.WeaponName) return false;
            if (DMG != weapon.DMG) return false;
            if (AttackRange != weapon.AttackRange) return false;
            if (DamageType != weapon.DamageType) return false;
            if (ItemDescription != weapon.ItemDescription) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString() {
            return $"{this.WeaponName} {this.DMG}";
        }
        #endregion
    }
}