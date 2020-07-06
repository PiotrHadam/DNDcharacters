using MySql.Data.MySqlClient;
using Start.DAL.Helpers;
using Start.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO.Packaging;


namespace Start.DAL.Encje
{
    class Character {
        #region Własności
        // własności niewczytywane
        public Class Class { get; set; }
        public Race Race { get; set; }
        public List<Weapon> Weapons { get; set; }
        public Armor Armor { get; set; }
        public List<Item> Equipment { get; set; }

        // własności wczytywane
        private byte _classID { get; set; }
        public byte? CharacterID { get; set; }
        public byte _raceID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public Dictionary<string,byte> Abilities { get; set; }
        
        /// <summary>
        /// First lvl next amount of spells on given lvl
        /// </summary>
        public Dictionary<byte, byte> PossibleSpellsPerDay { get; set; }
        public int Money { get; set; }
        public int HitPoints { get; set; }
        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Constitution { get; set; }
        public byte Intelligence { get; set; }
        public byte Wisdom { get; set; }
        public byte Charisma { get; set; }
        
        /*
        public byte A_Acrobatics { get; set; }
        public byte A_AnimalHanding { get; set; }
        public byte A_Arcana { get; set; }
        public byte A_Athletics { get; set; }
        public byte A_Deception { get; set; }
        public byte A_History { get; set; }
        public byte A_Insight { get; set; }
        public byte A_Intimidation { get; set; }
        public byte A_Investigation { get; set; }
        public byte A_Medicine { get; set; }
        public byte A_Nature { get; set; }
        public byte A_Perception { get; set; }
        public byte A_Performance { get; set; }
        public byte A_Persuasion { get; set; }
        public byte A_Religion { get; set; }
        public byte A_SleightOfHand { get; set; }
        public byte A_Stealth { get; set; }
        public byte A_Survival { get; set; }*/
        /*public byte KnownSpells0 { get; set; }
        public byte KnownSpells1 { get; set; }
        public byte KnownSpells2 { get; set; }
        public byte KnownSpells3 { get; set; }
        public byte KnownSpells4 { get; set; }
        public byte KnownSpells5 { get; set; }
        public byte KnownSpells6 { get; set; }
        public byte KnownSpells7 { get; set; }
        public byte KnownSpells8 { get; set; }
        public byte KnownSpells9 { get; set; }
        public byte KnownSpells10 { get; set; }*/
        public byte IsInspired { get; set; }
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
            Money = int.Parse(reader["character_money"].ToString());
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
            /*A_Acrobatics = byte.Parse(reader["ability_acrobatics"].ToString());
            A_AnimalHanding = byte.Parse(reader["ability_animal_handing"].ToString());
            A_Arcana = byte.Parse(reader["ability_arcana"].ToString());
            A_Athletics= byte.Parse(reader["ability_athletics"].ToString());
            A_Deception = byte.Parse(reader["ability_deception"].ToString());
            A_History = byte.Parse(reader["ability_history"].ToString());
            A_Insight = byte.Parse(reader["ability_insight"].ToString());
            A_Intimidation = byte.Parse(reader["ability_intimidation"].ToString());
            A_Investigation = byte.Parse(reader["ability_investigation"].ToString());
            A_Medicine = byte.Parse(reader["ability_medicine"].ToString());
            A_Nature = byte.Parse(reader["ability_nature"].ToString());
            A_Perception = byte.Parse(reader["ability_perception"].ToString());
            A_Performance = byte.Parse(reader["ability_performance"].ToString());
            A_Persuasion = byte.Parse(reader["ability_persuasion"].ToString());
            A_Religion = byte.Parse(reader["ability_religion"].ToString());
            A_SleightOfHand = byte.Parse(reader["ability_sleight_of_hand"].ToString());
            A_Stealth = byte.Parse(reader["ability_stealh"].ToString());
            A_Survival = byte.Parse(reader["ability_survival"].ToString());*/
            PossibleSpellsPerDay.Add(1, byte.Parse(reader["known_spells_0"].ToString()));
            PossibleSpellsPerDay.Add(2, byte.Parse(reader["known_spells_1"].ToString()));
            PossibleSpellsPerDay.Add(3, byte.Parse(reader["known_spells_2"].ToString()));
            PossibleSpellsPerDay.Add(4, byte.Parse(reader["known_spells_3"].ToString()));
            PossibleSpellsPerDay.Add(5, byte.Parse(reader["known_spells_4"].ToString()));
            PossibleSpellsPerDay.Add(6, byte.Parse(reader["known_spells_5"].ToString()));
            PossibleSpellsPerDay.Add(7, byte.Parse(reader["known_spells_6"].ToString()));
            PossibleSpellsPerDay.Add(8, byte.Parse(reader["known_spells_7"].ToString()));
            PossibleSpellsPerDay.Add(9, byte.Parse(reader["known_spells_8"].ToString()));
            PossibleSpellsPerDay.Add(10, byte.Parse(reader["known_spells_9"].ToString()));
            /*KnownSpells0 = byte.Parse(reader["known_spells_0"].ToString());
            KnownSpells1 = byte.Parse(reader["known_spells_1"].ToString());
            KnownSpells2 = byte.Parse(reader["known_spells_2"].ToString());
            KnownSpells3 = byte.Parse(reader["known_spells_3"].ToString());
            KnownSpells4 = byte.Parse(reader["known_spells_4"].ToString());
            KnownSpells5 = byte.Parse(reader["known_spells_5"].ToString());
            KnownSpells6 = byte.Parse(reader["known_spells_6"].ToString());
            KnownSpells7 = byte.Parse(reader["known_spells_7"].ToString());
            KnownSpells8 = byte.Parse(reader["known_spells_8"].ToString());
            KnownSpells9 = byte.Parse(reader["known_spells_9"].ToString());*/
            IsInspired = byte.Parse(reader["is_inspired"].ToString());
            Description = reader["character_description"].ToString();
            Story = reader["character_story"].ToString();
            Level = byte.Parse(reader["character_lvl"].ToString());

            // Znajdywanie klasy po numerze ID klasy odczytanym z bazy
            foreach(Class x in RepositoryClases.ReadAllClases()) {
                if(x.ClassID == _classID) {
                    Class = x;
                    break;
                }
                else
                    throw new Exception("Invalid class ID");
            }

            // Znajdywanie klasy po numerze ID odczytanym z bazy
            foreach(Race x in RepositoryRaces.ReadAllRaces()) {
                if(x.RaceID == _raceID) {
                    Race = x;
                    break;
                }
                else
                    throw new Exception("Invalid class ID");
            }

            // Znajdywanie broni postaci w repozytorium wszystkich broni
            Weapons = new List<Weapon>();
            foreach(Weapon weapon in RepositoryWeapons.ReadAllWeapons()) {
                
                if(weapon.CharacterID == CharacterID) {
                    Weapons.Add(weapon);
                }
                else
                    throw new Exception("Invalid weapon ID");
            }

            Armor = null;
            // Znajdowanie zbroi w repozytroium zbro
            foreach(Armor armor in RepositoryArmors.ReadAllArmors()) {

                if(armor.CharacterID == CharacterID) {
                    Armor = armor;
                    break;
                }                
            }

            // Dodawanie 
            Equipment = new List<Item>();
            foreach(Item item in RepositoryItems.ReadAllItems()) {
                if(item.CharacterID == CharacterID) {
                    Equipment.Add(item);
                }
                else
                    throw new Exception("Invalid class ID");
            }

        }
        /*
        public Character(string name, byte race, byte clas, string image, int money, int hitpoints, byte strength, byte dexterity, byte constitution, byte intelligence, byte wisdom, byte charisma, byte acrobatics, byte animalhanding, byte arcana, byte athletics, byte deception, byte history, byte insight, byte intimidation, byte investigation, byte medicine, byte nature, byte perception, byte performance, byte persuasion, byte religion, byte sleightofhand, byte stealth, byte survival, byte knownspells0, byte knownspells1, byte knownspells2, byte knownspells3, byte knownspells4, byte knownspells5, byte knownspells6, byte knownspells7, byte knownspells8, byte knownspells9, byte knownspells10, byte isinspired, string description, string story, byte level)
        {
            CharacterID = null;
            Name = name.Trim();
            _raceID = race;
            _classID = clas;
            Image = image.Trim();
            Money = money;
            HitPoints = hitpoints;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            A_Acrobatics = acrobatics;
            A_AnimalHanding = animalhanding;
            A_Arcana = arcana;
            A_Athletics = athletics;
            A_Deception = deception;
            A_History = history;
            A_Insight = insight;
            A_Intimidation = intimidation;
            A_Investigation = investigation;
            A_Medicine = medicine;
            A_Nature = nature;
            A_Perception = perception;
            A_Performance = performance;
            A_Persuasion = persuasion;
            A_Religion = religion;
            A_SleightOfHand = sleightofhand;
            A_Stealth = stealth;
            A_Survival = survival;
            KnownSpells0 = knownspells0;
            KnownSpells1 = knownspells1;
            KnownSpells2 = knownspells2;
            KnownSpells3 = knownspells3;
            KnownSpells4 = knownspells4;
            KnownSpells5 = knownspells5;
            KnownSpells6 = knownspells6;
            KnownSpells7 = knownspells7;
            KnownSpells8 = knownspells8;
            KnownSpells9 = knownspells9;
            KnownSpells10 = knownspells10;
            IsInspired = isinspired;
            Description = description.Trim();
            Story = story.Trim();
            Level = level;
        }*/

        public Character(Character character)
        {
            CharacterID = character.CharacterID;
            Name = character.Name;
            _raceID = character._raceID;
            _classID = character._classID;
            Image = character.Image;
            Money = character.Money;
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

            // Znajdywanie klasy po numerze ID klasy odczytanym z bazy
            foreach(Class x in RepositoryClases.ReadAllClases()) {
                if(x.ClassID == _classID) {
                    Class = x;
                    break;
                }
                else
                    throw new Exception("Invalid class ID");
            }

            // Znajdywanie klasy po numerze ID odczytanym z bazy
            foreach(Race x in RepositoryRaces.ReadAllRaces()) {
                if(x.RaceID == _raceID) {
                    Race = x;
                    break;
                }
                else
                    throw new Exception("Invalid class ID");
            }

            // Znajdywanie broni postaci w repozytorium wszystkich broni
            Weapons = new List<Weapon>();
            foreach(Weapon weapon in RepositoryWeapons.ReadAllWeapons()) {

                if(weapon.CharacterID == CharacterID) {
                    Weapons.Add(weapon);
                }
                else
                    throw new Exception("Invalid weapon ID");
            }

            Armor = null;
            // Znajdowanie zbroi w repozytroium zbro
            foreach(Armor armor in RepositoryArmors.ReadAllArmors()) {

                if(armor.CharacterID == CharacterID) {
                    Armor = armor;
                    break;
                }
            }

            // Dodawanie 
            Equipment = new List<Item>();
            foreach(Item item in RepositoryItems.ReadAllItems()) {
                if(item.CharacterID == CharacterID) {
                    Equipment.Add(item);
                }
                else
                    throw new Exception("Invalid class ID");
            }
        }
        
        #endregion

        #region Metody


        public string ToInsert()
        {
            string possibleSpellsPerDay = string.Empty;
            string abilities = string.Empty;
            for(byte i= 0; i < PossibleSpellsPerDay.Count; i++) {
                possibleSpellsPerDay += PossibleSpellsPerDay[i].ToString() + ", ";
            };
            foreach(KeyValuePair<string,byte> ability in Abilities) {
                abilities += ability.Value.ToString() + ", ";
            }
            return $"('{Name}', {_raceID}, {_raceID}, '{Image}', {Money}, {HitPoints}, {Charisma}, " +
                $"{Constitution}, {Dexterity}, {Intelligence}, {Strength}, {Wisdom}, " +
                $"{abilities} {possibleSpellsPerDay}" + // przecinki już są na końcu tych wyrażeń              
                $" {IsInspired}, \"{Description}\", \"{Story}\", {Level})";
        }

        public string ToDelete()
        {
            return $"'{CharacterID}";
        }

       

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
