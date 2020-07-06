using MySql.Data.MySqlClient;

namespace Start.DAL.Encje
{
    class Character
    {
        #region Własności
        public byte? CharacterID { get; set; }
        public string Name { get; set; }
        public byte Race { get; set; }
        public byte Clas { get; set; }
        public string Image { get; set; }
        public int Money { get; set; }
        public int HitPoints { get; set; }
        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Constitution { get; set; }
        public byte Intelligence { get; set; }
        public byte Wisdom { get; set; }
        public byte Charisma { get; set; }
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
        public byte A_Survival { get; set; }
        public byte KnownSpells0 { get; set; }
        public byte KnownSpells1 { get; set; }
        public byte KnownSpells2 { get; set; }
        public byte KnownSpells3 { get; set; }
        public byte KnownSpells4 { get; set; }
        public byte KnownSpells5 { get; set; }
        public byte KnownSpells6 { get; set; }
        public byte KnownSpells7 { get; set; }
        public byte KnownSpells8 { get; set; }
        public byte KnownSpells9 { get; set; }
        public byte KnownSpells10 { get; set; }
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
            Race = byte.Parse(reader["character_race"].ToString());
            Clas = byte.Parse(reader["character_class"].ToString());
            Image = reader["character_image_path"].ToString();
            Money = int.Parse(reader["character_money"].ToString());
            HitPoints = int.Parse(reader["hit_points"].ToString());
            Strength = byte.Parse(reader["stregth"].ToString());
            Dexterity = byte.Parse(reader["dexterity"].ToString());
            Constitution = byte.Parse(reader["constitution"].ToString());
            Intelligence = byte.Parse(reader["inteligence"].ToString());
            Wisdom = byte.Parse(reader["wisdom"].ToString());
            Charisma = byte.Parse(reader["charisma"].ToString());
            A_Acrobatics = byte.Parse(reader["ability_acrobatics"].ToString());
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
            A_Survival = byte.Parse(reader["ability_survival"].ToString());
            KnownSpells0 = byte.Parse(reader["known_spells_0"].ToString());
            KnownSpells1 = byte.Parse(reader["known_spells_1"].ToString());
            KnownSpells2 = byte.Parse(reader["known_spells_2"].ToString());
            KnownSpells3 = byte.Parse(reader["known_spells_3"].ToString());
            KnownSpells4 = byte.Parse(reader["known_spells_4"].ToString());
            KnownSpells5 = byte.Parse(reader["known_spells_5"].ToString());
            KnownSpells6 = byte.Parse(reader["known_spells_6"].ToString());
            KnownSpells7 = byte.Parse(reader["known_spells_7"].ToString());
            KnownSpells8 = byte.Parse(reader["known_spells_8"].ToString());
            KnownSpells9 = byte.Parse(reader["known_spells_9"].ToString());
            KnownSpells10 = byte.Parse(reader["known_spells_10"].ToString());
            IsInspired = byte.Parse(reader["is_inspired"].ToString());
            Description = reader["character_description"].ToString();
            Story = reader["character_story"].ToString();
            Level = byte.Parse(reader["character_lvl"].ToString());
        }

        public Character(string name, byte race, byte clas, string image, int money, int hitpoints, byte strength, byte dexterity, byte constitution, byte intelligence, byte wisdom, byte charisma, byte acrobatics, byte animalhanding, byte arcana, byte athletics, byte deception, byte history, byte insight, byte intimidation, byte investigation, byte medicine, byte nature, byte perception, byte performance, byte persuasion, byte religion, byte sleightofhand, byte stealth, byte survival, byte knownspells0, byte knownspells1, byte knownspells2, byte knownspells3, byte knownspells4, byte knownspells5, byte knownspells6, byte knownspells7, byte knownspells8, byte knownspells9, byte knownspells10, byte isinspired, string description, string story, byte level)
        {
            CharacterID = null;
            Name = name.Trim();
            Race = race;
            Clas = clas;
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
        }

        public Character(Character character)
        {
            CharacterID = character.CharacterID;
            Name = character.Name;
            Race = character.Race;
            Clas = character.Clas;
            Image = character.Image;
            Money = character.Money;
            HitPoints = character.HitPoints;
            Strength = character.Strength;
            Dexterity = character.Dexterity;
            Constitution = character.Constitution;
            Intelligence = character.Intelligence;
            Wisdom = character.Wisdom;
            Charisma = character.Charisma;
            A_Acrobatics = character.A_Acrobatics;
            A_AnimalHanding = character.A_AnimalHanding;
            A_Arcana = character.A_Arcana;
            A_Athletics = character.A_Athletics;
            A_Deception = character.A_Deception;
            A_History = character.A_History;
            A_Insight = character.A_Insight;
            A_Intimidation = character.A_Intimidation;
            A_Investigation = character.A_Investigation;
            A_Medicine = character.A_Medicine;
            A_Nature = character.A_Nature;
            A_Perception = character.A_Perception;
            A_Performance = character.A_Performance;
            A_Persuasion = character.A_Persuasion;
            A_Religion = character.A_Religion;
            A_SleightOfHand = character.A_SleightOfHand;
            A_Stealth = character.A_Stealth;
            A_Survival = character.A_Survival;
            KnownSpells0 = character.KnownSpells0;
            KnownSpells1 = character.KnownSpells1;
            KnownSpells2 = character.KnownSpells2;
            KnownSpells3 = character.KnownSpells3;
            KnownSpells4 = character.KnownSpells4;
            KnownSpells5 = character.KnownSpells5;
            KnownSpells6 = character.KnownSpells6;
            KnownSpells7 = character.KnownSpells7;
            KnownSpells8 = character.KnownSpells8;
            KnownSpells9 = character.KnownSpells9;
            KnownSpells10 = character.KnownSpells10;
            IsInspired = character.IsInspired;
            Description = character.Description;
            Story = character.Story;
            Level = character.Level;
        }

        #endregion

        #region Metody


        public string ToInsert()
        {
            return $"('{Name}', {Race}, {Clas}, '{Image}', {Money}, {HitPoints}, {Charisma}, {Constitution}, {Dexterity}, {Intelligence}, {Strength}, {Wisdom}, {A_Acrobatics}, {A_AnimalHanding}, {A_Arcana}, {A_Athletics}, {A_Deception}, {A_History}, {A_Insight}, {A_Intimidation}, {A_Investigation}, {A_Medicine}, {A_Nature}, {A_Perception}, {A_Performance}, {A_Persuasion}, {A_Religion}, {A_SleightOfHand}, {A_Stealth}, {A_Survival}, {KnownSpells0}, {KnownSpells1}, {KnownSpells2}, {KnownSpells3}, {KnownSpells4}, {KnownSpells5}, {KnownSpells6}, {KnownSpells7}, {KnownSpells8}, {KnownSpells9}, {KnownSpells10}, {IsInspired}, \"{Description}\", \"{Story}\", {Level})";
        }

        public string ToDelete()
        {
            return $"'{CharacterID}";
        }

        public override bool Equals(object obj)
        {
            var character = obj as Character;
            if (character is null) return false;
            if (Name.ToLower() != character.Name.ToLower()) return false;
            if (Race != character.Race) return false;
            if (Clas != character.Clas) return false;
            if (Money != character.Money) return false;
            if (HitPoints != character.HitPoints) return false;
            if (Strength != character.Strength) return false;
            if (Dexterity != character.Dexterity) return false;
            if (Constitution != character.Constitution) return false;
            if (Intelligence != character.Intelligence) return false;
            if (Wisdom != character.Wisdom) return false;
            if (Charisma != character.Charisma) return false;
            if (A_Acrobatics != character.A_Acrobatics) return false;
            if (A_AnimalHanding != character.A_AnimalHanding) return false;
            if (A_Arcana != character.A_Arcana) return false;
            if (A_Athletics != character.A_Athletics) return false;
            if (A_Deception != character.A_Deception) return false;
            if (A_History != character.A_History) return false;
            if (A_Insight != character.A_Insight) return false;
            if (A_Intimidation != character.A_Intimidation) return false;
            if (A_Investigation != character.A_Investigation) return false;
            if (A_Medicine != character.A_Medicine) return false;
            if (A_Nature != character.A_Nature) return false;
            if (A_Perception != character.A_Perception) return false;
            if (A_Performance != character.A_Performance) return false;
            if (A_Persuasion != character.A_Persuasion) return false;
            if (A_Religion != character.A_Religion) return false;
            if (A_SleightOfHand != character.A_SleightOfHand) return false;
            if (A_Stealth != character.A_Stealth) return false;
            if (A_Survival != character.A_Survival) return false;
            if (IsInspired != character.IsInspired) return false;
            if (Description != character.Description) return false;
            if (Story != character.Story) return false;
            if (Level != character.Level) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
