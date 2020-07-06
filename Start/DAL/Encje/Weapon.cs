using MySql.Data.MySqlClient;

namespace Start.DAL.Encje
{
    class Weapon
    {
        #region Własności
        public byte? WeaponID { get; set; }
        public byte CharacterID { get; set; }
        public string WeaponName { get; set; }
        public byte DMGDice { get; set; }
        public byte DMGDiceSize { get; set; }
        public string AttackRange { get; set; }
        public string DamageType { get; set; }
        public string ItemDescription { get; set; }
        #endregion

        #region Konstruktory
        public Weapon(MySqlDataReader reader)
        {
            WeaponID = byte.Parse(reader["weapon_id"].ToString());
            CharacterID = byte.Parse(reader["character_id"].ToString());
            WeaponName = reader["weapon_name"].ToString();
            DMGDice = byte.Parse(reader["required_lvl"].ToString());
            DMGDiceSize = byte.Parse(reader["dmg_dice_size"].ToString());
            AttackRange = reader["attack_range"].ToString();
            DamageType = reader["damage_type"].ToString();
            ItemDescription = reader["item_description"].ToString();
        }

        public Weapon(byte characterid, string weaponname, byte dmgdice, byte dmgdicesize, string attackrange, string damagetype, string itemdescription)
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

        public Weapon(Weapon dalweapon)
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
            var weapon = obj as Weapon;
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