using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.DAL.Encje
{
    class DALWeapon
    {
        #region Własności
        public sbyte? WeaponID { get; set; }
        public sbyte CharacterID { get; set; }
        public string WeaponName { get; set; }
        public sbyte DMGDice { get; set; }
        public sbyte DMGDiceSize { get; set; }
        public string AttackRange { get; set; }
        public string DamageType { get; set; }
        public string ItemDescription { get; set; }
        #endregion

        #region Konstruktory
        public DALWeapon(MySqlDataReader reader)
        {
            WeaponID = sbyte.Parse(reader["weapon_id"].ToString());
            CharacterID = sbyte.Parse(reader["character_id"].ToString());
            WeaponName = reader["weapon_name"].ToString();
            DMGDice = sbyte.Parse(reader["required_lvl"].ToString());
            DMGDiceSize = sbyte.Parse(reader["dmg_dice_size"].ToString());
            AttackRange = reader["attack_range"].ToString();
            DamageType = reader["damage_type"].ToString();
            ItemDescription = reader["item_description"].ToString();
        }

        public DALWeapon(sbyte characterid, string weaponname, sbyte dmgdice, sbyte dmgdicesize, string attackrange, string damagetype, string itemdescription)
        {
            WeaponID = null;
            CharacterID = characterid;
            WeaponName = weaponname.Trim();
            DMGDice = dmgdice;
            DMGDiceSize = dmgdicesize;
            AttackRange = attackrange.Trim();
            DamageType = damagetype.Trim();
            ItemDescription = itemdescription.Trim();
        }

        public DALWeapon(DALWeapon dalweapon)
        {
            WeaponID = dalweapon.WeaponID;
            CharacterID = dalweapon.CharacterID;
            WeaponName = dalweapon.WeaponName;
            DMGDice = dalweapon.DMGDice;
            DMGDiceSize = dalweapon.DMGDiceSize;
            AttackRange = dalweapon.AttackRange;
            DamageType = dalweapon.DamageType;
            ItemDescription = dalweapon.ItemDescription;
        }
        #endregion

        #region Metody
        public string ToInsert()
        {
            return $"({CharacterID}, '{WeaponName}', {DMGDice}, {DMGDiceSize}, '{AttackRange}', '{DamageType}', '{ItemDescription}')";
        }

        public string ToDelete()
        {
            return $"{WeaponID}";
        }

        public override bool Equals(object obj)
        {
            var weapon = obj as DALWeapon;
            if (weapon is null) return false;
            if (CharacterID != weapon.CharacterID) return false;
            if (WeaponName != weapon.WeaponName) return false;
            if (DMGDice != weapon.DMGDice) return false;
            if (DMGDiceSize != weapon.DMGDiceSize) return false;
            if (AttackRange != weapon.AttackRange) return false;
            if (DamageType != weapon.DamageType) return false;
            if (ItemDescription != weapon.ItemDescription) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}