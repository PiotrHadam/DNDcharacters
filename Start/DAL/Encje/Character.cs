using MySql.Data.MySqlClient;
using Start.DAL.Helpers;
using Start.DAL.Repositories;
using Start.Model;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Windows.Media.Animation;

namespace Start.DAL.Encje
{
    public class Character
    {
        //DO IMPLEMENTACJI WŁASNOŚCI NIE WYMAGAJĄCE INICJALIZACJI W KONSTRUKTORZE!!!
        public byte Perception { get { return Convert.ToByte(10 + WisdomBonus); } set { Perception = value; } }
        public Money CHMoney { get; set; } = new Money();
        public byte Speed { get { return 10; } set { Speed = value; } }
        public byte Proficiency { get { return Convert.ToByte(2 + (Level / 4)); } set { Proficiency = value; } }
        public byte ArmorClass
        {
            get
            {
                return Convert.ToByte(Armor.ClassBonus + ConstitutionBonus + 10);
            }
            set { ArmorClass = value; }
        }
        public byte MaxHitPoints
        {
            get
            {
                return Convert.ToByte(Level * 10);
            }
            set { MaxHitPoints = value; }
        }

        public byte StrengthBonus { get; set; }
        public byte DexterityBonus { get; set; }
        public byte ConstitutionBonus { get; set; }
        public byte IntelligenceBonus { get; set; }
        public byte WisdomBonus { get; set; }
        public byte CharismaBonus { get; set; }


        #region Własności
        // własności niewczytywane
        public Class Class { get; set; }
        public Race Race { get; set; }

        public List<Weapon> Weapons
        {
            get
            {
                var weapons = new List<Weapon>();
                foreach (Weapon weapon in RepositoryWeapons.ReadAllWeapons())
                {

                    if (weapon.CharacterID == CharacterID)
                    {
                        Weapons.Add(weapon);
                    }

                }
                return weapons;
            }
        }
        public Armor Armor { get; set; }
        public List<Item> Equipment
        {
            get
            {
                var equipment = new List<Item>();
                foreach (Item item in RepositoryItems.ReadAllItems())
                {
                    if (item.CharacterID == CharacterID)
                    {
                        Equipment.Add(item);
                    }
                }
                return equipment;
            }
        }
        public List<Spell> Spells { get; set; }


        // własności wczytywane
        private byte _classID { get; set; }
        public ushort? CharacterID { get; set; }
        private byte _raceID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public Dictionary<string, byte> Abilities { get; set; } = new Dictionary<string, byte>();

        /// <summary>
        /// First lvl next amount of spells on given lvl
        /// </summary>
        public Dictionary<byte, byte> PossibleSpellsPerDay { get; set; } = new Dictionary<byte, byte>();
        public uint Money { get; set; }
        public int HitPoints { get; set; }
        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Constitution { get; set; }
        public byte Intelligence { get; set; }
        public byte Wisdom { get; set; }
        public byte Charisma { get; set; }
        public bool IsInspired { get; set; }
        public string Description { get; set; }
        public string Story { get; set; }
        public byte Level { get; set; }
        #endregion

        #region Konstruktory
        public Character() { }

        public Character(MySqlDataReader reader)
        {
            CharacterID = byte.Parse(reader["character_id"].ToString());
            Name = reader["character_name"].ToString();
            _raceID = byte.Parse(reader["character_race"].ToString());
            _classID = byte.Parse(reader["character_class"].ToString());
            Image = reader["character_image_path"].ToString();
            Money = uint.Parse(reader["character_money"].ToString());
            HitPoints = int.Parse(reader["hit_points"].ToString());
            Strength = byte.Parse(reader["stregth"].ToString());
            Dexterity = byte.Parse(reader["dexterity"].ToString());
            Constitution = byte.Parse(reader["constitution"].ToString());
            Intelligence = byte.Parse(reader["inteligence"].ToString());
            Wisdom = byte.Parse(reader["wisdom"].ToString());
            Charisma = byte.Parse(reader["charisma"].ToString());
            Abilities.Add(Rules.Abilities[0], byte.Parse(reader["ability_acrobatics"].ToString()));
            Abilities.Add(Rules.Abilities[1], byte.Parse(reader["ability_animal_handing"].ToString()));
            Abilities.Add(Rules.Abilities[2], byte.Parse(reader["ability_arcana"].ToString()));
            Abilities.Add(Rules.Abilities[3], byte.Parse(reader["ability_athletics"].ToString()));
            Abilities.Add(Rules.Abilities[4], byte.Parse(reader["ability_deception"].ToString()));
            Abilities.Add(Rules.Abilities[5], byte.Parse(reader["ability_history"].ToString()));
            Abilities.Add(Rules.Abilities[6], byte.Parse(reader["ability_insight"].ToString()));
            Abilities.Add(Rules.Abilities[7], byte.Parse(reader["ability_intimidation"].ToString()));
            Abilities.Add(Rules.Abilities[8], byte.Parse(reader["ability_investigation"].ToString()));
            Abilities.Add(Rules.Abilities[9], byte.Parse(reader["ability_medicine"].ToString()));
            Abilities.Add(Rules.Abilities[10], byte.Parse(reader["ability_nature"].ToString()));
            Abilities.Add(Rules.Abilities[11], byte.Parse(reader["ability_perception"].ToString()));
            Abilities.Add(Rules.Abilities[12], byte.Parse(reader["ability_performance"].ToString()));
            Abilities.Add(Rules.Abilities[13], byte.Parse(reader["ability_persuasion"].ToString()));
            Abilities.Add(Rules.Abilities[14], byte.Parse(reader["ability_religion"].ToString()));
            Abilities.Add(Rules.Abilities[15], byte.Parse(reader["ability_sleight_of_hand"].ToString()));
            Abilities.Add(Rules.Abilities[16], byte.Parse(reader["ability_stealh"].ToString()));
            Abilities.Add(Rules.Abilities[17], byte.Parse(reader["ability_survival"].ToString()));
            for (byte i = 0; i < 10; i++)
            {
                try
                {
                    if (reader[$"known_spells_{i}"] != null)
                        PossibleSpellsPerDay.Add(Convert.ToByte(i + 1), byte.Parse(reader[$"known_spells_{i}"].ToString()));
                }
                catch { }
            }
            try
            {
                byte tmp = byte.Parse(reader["is_inpired"].ToString());
                IsInspired = Convert.ToBoolean(tmp);
            }
            catch { }
            Description = reader["character_description"].ToString();
            Story = reader["character_story"].ToString();
            Level = byte.Parse(reader["character_lvl"].ToString());

            // Znajdywanie klasy po numerze ID klasy odczytanym z bazy
            foreach (Class x in RepositoryClases.ReadAllClases())
            {
                if (x.ClassID == _classID)
                {
                    Class = x;
                    break;
                }
            }
            if (Class == null)
                throw new Exception("Invalid class ID");

            // Znajdywanie rasy po numerze ID odczytanym z bazy
            foreach (Race x in RepositoryRaces.ReadAllRaces())
            {
                if (x.RaceID == _raceID)
                {
                    Race = x;
                    break;
                }
            }
            if (Race == null)
                throw new Exception("Invalid Race ID");

            Armor = null;
            // Znajdowanie zbroi w repozytroium zbro
            foreach (Armor armor in RepositoryArmors.ReadAllArmors())
            {

                if (armor.CharacterID == CharacterID)
                {
                    Armor = armor;
                    break;
                }
            }

        }

        /// <summary>
        /// Konstruktor kopiujący
        /// </summary>
        /// <param name="character"></param>
        public Character(Character character)
        {
            CharacterID = character.CharacterID;
            Race = character.Race;
            Name = character.Name;
            _raceID = character._raceID;
            _classID = character._classID;
            Image = character.Image;
            Money = character.Money;
            CHMoney = character.CHMoney;
            HitPoints = character.HitPoints;
            Strength = character.Strength;
            Dexterity = character.Dexterity;
            Constitution = character.Constitution;
            Intelligence = character.Intelligence;
            Wisdom = character.Wisdom;
            Charisma = character.Charisma;
            IsInspired = character.IsInspired;
            Description = character.Description;
            Story = character.Story;
            Level = character.Level;
            Abilities = character.Abilities;
            PossibleSpellsPerDay = character.PossibleSpellsPerDay;


            // Znajdywanie klasy po numerze ID klasy odczytanym z bazy
            foreach (Class x in RepositoryClases.ReadAllClases())
            {
                if (x.ClassID == _classID)
                {
                    Class = x;
                    break;
                }

            }

            // Znajdywanie klasy po numerze ID odczytanym z bazy
            foreach (Race x in RepositoryRaces.ReadAllRaces())
            {
                if (x.RaceID == _raceID)
                {
                    Race = x;
                    break;
                }
            }

        }

        #endregion

        public Character(Builder builder)
        {
            Name = builder._name;
            _classID = builder._classID;
            this.Class = builder._class;
            HitPoints = builder._hitPoints;
            //CHMoney = builder._money;
            Money = builder._money;
            Race = builder._race;
            this._raceID = builder._raceID;
            IsInspired = builder._isInspired;
            Strength = builder._strenght;
            Dexterity = builder._dexterity;
            Constitution = builder._constitution;
            Intelligence = builder._inteligence;
            Wisdom = builder._wisdom;
            Charisma = builder._charisma;
            Abilities = builder._abilities;
            Armor = builder._armor;
            Description = builder._description;
            Story = builder._characterStory;
            Level = builder._lvl;
            PossibleSpellsPerDay = builder._possibleSpellsPerDay;
        }

        /// <summary>
        /// Korzystanie z buildera: 
        /// Character someCharacter = new Character.Bulder()
        ///                                         .WithName("Imie")
        ///                                         .WithHitPoints(45)
        ///                                         .WithClassID(2)
        ///                                         .
        ///                                         .
        ///                                         .
        ///                                         .WithLvL(5)
        ///                                         .Build();
        ///                                         
        /// </summary>
        #region Builder
        public class Builder
        {
            internal string _name;
            internal byte _classID;
            internal Class _class;
            internal Race _race;
            internal byte _raceID;
            internal byte _hitPoints;
            //internal Money _money;
            internal uint _money;
            internal bool _isInspired;
            internal byte _strenght;
            internal byte _dexterity;
            internal byte _constitution;
            internal byte _inteligence;
            internal byte _wisdom;
            internal byte _charisma;
            internal Dictionary<string, byte> _abilities = new Dictionary<string, byte>();
            internal List<Weapon> _weapons = new List<Weapon>();
            internal Armor _armor;
            internal List<Item> _otherEquipment = new List<Item>();
            internal string _description;
            internal string _characterStory;
            internal List<Spell> _spells = new List<Spell>();
            internal byte _lvl;
            internal Dictionary<byte, byte> _possibleSpellsPerDay = new Dictionary<byte, byte>();

            public Builder WithName(string name)
            {
                _name = name;
                return this;
            }
            public Builder WithHitPoints(byte currentHitPoints)
            {
                _hitPoints = currentHitPoints;
                return this;
            }

            /*public Builder WithMoney(Money money)
            {
                _money = money;
                return this;
            }*/
            public Builder WithMoney(uint money)
            {
                _money = money;
                return this;
            }
            public Builder WithLvl(byte lvl)
            {
                _lvl = lvl;
                return this;
            }
            public Builder WithClassID(byte characterClassID)
            {
                _classID = characterClassID;
                foreach (Class x in RepositoryClases.ReadAllClases())
                {
                    if (x.ClassID == _classID)
                    {
                        _class = x;
                        break;
                    }
                }
                if (_class == null)
                    throw new Exception("Invalid class ID");
                return this;
            }

            public Builder WithRaceID(byte raceID)
            {

                _raceID = raceID;
                foreach (Race x in RepositoryRaces.ReadAllRaces())
                {
                    if (x.RaceID == _raceID)
                    {
                        _race = x;
                        break;
                    }
                }
                if (_race == null)
                    throw new Exception("Invalid Race ID");
                return this;
            }

            public Builder WithInspired(bool isInspired)
            {
                _isInspired = isInspired;
                return this;
            }
            public Builder WithStrenght(byte strenght)
            {
                _strenght = strenght;
                return this;
            }
            public Builder WithDexterity(byte dexterity)
            {
                _dexterity = dexterity;
                return this;
            }
            public Builder WithConstitution(byte constitution)
            {
                _constitution = constitution;
                return this;
            }
            public Builder WithCharisma(byte charisma)
            {
                _charisma = charisma;
                return this;
            }
            public Builder WithInteligence(byte inteligence)
            {
                _inteligence = inteligence;
                return this;
            }
            public Builder WithWisdom(byte wisdom)
            {
                _wisdom = wisdom;
                return this;
            }
            public Builder WithWeapon1(List<Weapon> weapons)
            {
                _weapons = weapons;
                return this;
            }

            public Builder WithArmor(Armor armor)
            {
                _armor = armor;
                return this;
            }
            public Builder WithOtehrEquipment(List<Item> otehrEquipment)
            {
                _otherEquipment = otehrEquipment;
                return this;
            }
            public Builder WithDescription(string description)
            {
                _description = description;
                return this;
            }
            public Builder WithCharacterStory(string characterStory)
            {
                _characterStory = characterStory;
                return this;
            }
            public Builder WithAbilities(List<byte> abilities)
            {
                _abilities = new Dictionary<string, byte>();
                try
                {
                    for (int i = 0; i < Rules.Abilities.Length; i++)
                        _abilities.Add(Rules.Abilities[i], abilities[i]);
                }
                catch
                {
                    throw new Exception("Invalid format or number of abilities!");
                }
                return this;
            }
            public Builder WithAbilities(Dictionary<string, byte> abilities)
            {
                _abilities = abilities;
                return this;
            }
            public Builder WithPossibleSpellsPerDay(Dictionary<byte, byte> possibleSpells)
            {
                _possibleSpellsPerDay = possibleSpells;
                return this;
            }
            public Builder WithSpells(List<Spell> spells)
            {
                _spells = spells;
                spells.Sort();
                return this;
            }
            public Character Build()
            {
                return new Character(this);
            }
        }
        #endregion


        #region Metody


        public string ToInsert()
        {
            string possibleSpellsPerDay = string.Empty;
            string abilities = string.Empty;

            try
            {
                for (byte i = 0; i < PossibleSpellsPerDay.Count; i++)
                {
                    possibleSpellsPerDay += PossibleSpellsPerDay[i].ToString() + ", ";
                };
            }
            catch
            {
                for (byte i = 0; i < 10; i++)
                {
                    possibleSpellsPerDay += 0.ToString() + ", ";
                };
            }


            foreach (KeyValuePair<string, byte> ability in Abilities)
            {
                abilities += ability.Value.ToString() + ", ";
            }

            /*return $"({Name}, {Class.ClassID}, {Race.RaceID},, {Money}, {HitPoints}, {Charisma}, " +
                $"{Constitution}, {Dexterity}, {Intelligence}, {Strength}, {Wisdom}," +
                $"{abilities} {possibleSpellsPerDay}" + // przecinki już są na końcu tych wyrażeń              
                $"{Convert.ToInt32(IsInspired)}, \"{Description}\", \"{Story}\", {Level})";*/

            return $"INSERT INTO `characters` (`character_id`, `character_name`, `character_race`, `character_class`," +
                $" `character_image_path`, `character_money`, `hit_points`, `charisma`, `constitution`, `dexterity`," +
                $" `inteligence`, `stregth`, `wisdom`, `ability_acrobatics`, `ability_animal_handing`, `ability_arcana`," +
                $" `ability_athletics`, `ability_deception`, `ability_history`, `ability_insight`, `ability_intimidation`, " +
                $"`ability_investigation`, `ability_medicine`, `ability_nature`, `ability_perception`, `ability_performance`, " +
                $"`ability_persuasion`, `ability_religion`, `ability_sleight_of_hand`, `ability_stealh`, `ability_survival`, " +
                $"`known_spells_0`, `known_spells_1`, `known_spells_2`, `known_spells_3`, `known_spells_4`, `known_spells_5`, " +
                $"`known_spells_6`, `known_spells_7`, `known_spells_8`, `known_spells_9`, `is_inpired`, `character_description`, " +
                $"`character_story`, `character_lvl`) " +
                $"VALUES (NULL, '{Name}', '{Race.RaceID}', '{Class.ClassID}', NULL, '{Money}', '{HitPoints}', '{Charisma}', '{Constitution}', '{Dexterity}', '{Intelligence}', " +
                $"'{Strength}', '{Wisdom}', '{Abilities["acrobatics"]}', '{Abilities["animal_handing"]}', '{Abilities["arcana"]}', '{Abilities["athletics"]}', " +
                $"'{Abilities["deception"]}', '{Abilities["history"]}', '{Abilities["insight"]}', " +
                $"'{Abilities["intimidation"]}', '{Abilities["investigation"]}', '{Abilities["medicine"]}', " +
                $"'{Abilities["nature"]}', '{Abilities["perception"]}', '{Abilities["performance"]}', '{Abilities["persuasion"]}'," +
                $" '{Abilities["religion"]}', '{Abilities["sleight_of_hand"]}', '{Abilities["stealh"]}', '{Abilities["survival"]}', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, b'{Convert.ToInt32(IsInspired)}', '{Description}', '{Story}', '{Level}');";

        }

        public string ToDelete()
        {
            return $"{CharacterID}";
        }

        #endregion
    }
}
