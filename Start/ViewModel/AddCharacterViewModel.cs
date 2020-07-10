using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Start.ViewModel
{
    using BaseClasses;
    using Model;
    using DAL.Encje;
    using Start.DAL.Repositories;
    using Start.DAL.Helpers;

    class AddCharacterViewModel : ViewModelBase
    {
        #region Składowe prywatne
        private Model model = null;

        private string name = "", image, description = "", story = "";
        private uint money = 20000;
        private int hitpoints = 20;
        private byte strength = 0, dexterity = 0, constitution = 0, intelligence = 0, wisdom = 0, charisma = 0, level = 0;
        private bool isInspired = false;
        private Dictionary<string, byte> abilities;
        private Dictionary<byte, byte> possiblespellsperday;
        #endregion

        #region Konstruktory
        public AddCharacterViewModel(Model model)
        {
            this.model = model;
            Characters = model.Characters;
            ClassNames = model.ClassNames;
            RaceNames = model.RaceNames;
            abilities = new Dictionary<string, byte>();
            possiblespellsperday = new Dictionary<byte, byte>();
            for (int i = 0; i < 18; i++)
            {
                abilities.Add(Rules.Abilities[i], 0);
            }
            for (byte i = 0; i < 10; i++)
            {
                possiblespellsperday.Add(i, 0);
            }
        }
        #endregion

        #region Właściwości

        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<string> RaceNames { get; set; }
        public ObservableCollection<string> ClassNames { get; set; }


        public string Name
        {
            get { return this.name; }
            set
            {
                name = value;
                onPropertyChanged(nameof(Name));
            }
        }
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                onPropertyChanged(nameof(Image));
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                onPropertyChanged(nameof(Description));
            }
        }

        public string Story
        {
            get { return story; }
            set
            {
                story = value;
                onPropertyChanged(nameof(Story));
            }
        }

        public uint Money
        {
            get { return money; }
            set
            {
                money = value;
                onPropertyChanged(nameof(Money));
            }
        }

        public int HitPoints
        {
            get { return hitpoints; }
            set
            {
                hitpoints = value;
                onPropertyChanged(nameof(HitPoints));
            }
        }

        public byte Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                onPropertyChanged(nameof(Strength));
            }
        }

        public byte Dexterity
        {
            get { return dexterity; }
            set
            {
                dexterity = value;
                onPropertyChanged(nameof(Dexterity));
            }
        }

        public byte Constitution
        {
            get { return constitution; }
            set
            {
                constitution = value;
                onPropertyChanged(nameof(Constitution));
            }
        }

        public byte Intelligence
        {
            get { return intelligence; }
            set
            {
                intelligence = value;
                onPropertyChanged(nameof(Intelligence));
            }
        }

        public byte Wisdom
        {
            get { return wisdom; }
            set
            {
                wisdom = value;
                onPropertyChanged(nameof(Wisdom));
            }
        }

        public byte Charisma
        {
            get { return charisma; }
            set
            {
                charisma = value;
                onPropertyChanged(nameof(Charisma));
            }
        }

        public bool IsInspired
        {
            get { return isInspired; }
            set
            {
                isInspired = value;
                onPropertyChanged(nameof(IsInspired));
            }
        }

        public byte Level
        {
            get { return level; }
            set
            {
                level = value;
                onPropertyChanged(nameof(Level));
            }
        }

        public Dictionary<string, byte> Abilities
        {
            get { return abilities; }
            set
            {
                abilities = value;
                onPropertyChanged(nameof(Abilities));
            }
        }

        public Dictionary<byte, byte> PossibleSpellsPerDay
        {
            get { return possiblespellsperday; }
            set
            {
                possiblespellsperday = value;
                onPropertyChanged(nameof(PossibleSpellsPerDay));
            }
        }

        #endregion
        public string Race { get; set; }
        public string Class { get; set; }


        private void ClearSheet()
        {
            Name = "";
            Image = "";
            Money = 20000;
            HitPoints = 20;
            Strength = 0;
            Dexterity = 0;
            Constitution = 0;
            Intelligence = 0;
            Wisdom = 0;
            Charisma = 0;
            IsInspired = false;
            Description = "";
            Story = "";
            Level = 0;

            Abilities.Clear();
            PossibleSpellsPerDay.Clear();
            for (int i = 0; i < 18; i++)
            {
                abilities.Add(Rules.Abilities[i], 0);
            }
            for (byte i = 0; i < 10; i++)
            {
                possiblespellsperday.Add(i, 0);
            }

        }

        #region Polecenia
        private int FindRaceIDbyName(string name)
        {
            foreach (Race r in RepositoryRaces.ReadAllRaces())
            {
                if (r.Name == name)
                    return r.RaceID;
            }
            return 1;
        }
        private int FindClassIDbyName(string name)
        {
            foreach (Class c in RepositoryClases.ReadAllClases())
            {
                if (c.Name == name)
                    return c.ClassID;
            }
            return 1;
        }

        private ICommand add = null;
        public ICommand Add
        {

            get
            {
                if (add == null)
                    add = new RelayCommand(
                        arg => {
                            var character = new Character.Builder().WithName(Name)
                                                                    .WithRaceID(Convert.ToByte(FindRaceIDbyName(Race)))
                                                                    .WithAbilities(Abilities)
                                                                    .WithCharacterStory(Story)
                                                                    .WithMoney(Money)
                                                                    .WithCharisma(Charisma)
                                                                    .WithClassID(Convert.ToByte(FindClassIDbyName(Class)))
                                                                    .WithConstitution(Constitution)
                                                                    .WithDescription(Description)
                                                                    .WithDexterity(Dexterity)
                                                                    .WithHitPoints(Convert.ToByte(HitPoints))
                                                                    .WithInspired(IsInspired)
                                                                    .WithInteligence(Intelligence)
                                                                    .WithLvl(Level)
                                                                    .WithName(Name)
                                                                    .WithStrenght(Strength)
                                                                    .WithWisdom(Wisdom)
                                                                    .WithPossibleSpellsPerDay(PossibleSpellsPerDay)
                                                                    .Build();

                            model.AddCharacterToDatabase(character);
                        }
                        ,
                        arg => (Name != "") && (Class != "") && (Race != "")
                        );
                return add;
            }
        }
        #endregion
    }
}
