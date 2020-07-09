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

    class EditCharacterViewModel : ViewModelBase
    {
        #region Składowe prywatne
        private Character _character = new Character();
        private Model model = null;

        private ushort char_id = 0;
        private string name = "", image, description = "", story = "";
        private int money = 20000, hitpoints = 20;
        private byte strength = 0, dexterity = 0, constitution = 0, intelligence = 0, wisdom = 0, charisma = 0, level = 0;
        private bool isInspired = false;
        private Dictionary<string, byte> abilities;
        private Dictionary<byte, byte> possiblespellsperday;
        #endregion

        #region Konstruktory

        public EditCharacterViewModel()
        {
            _character = new Character(ListOfCharactersViewModel.SelectedCharacter);
            model = new Model();
            char_id = (ushort)_character.CharacterID;
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

        public EditCharacterViewModel(Model model, Character character)
        {
            this.model = model;
            _character = character;
            /*name = character.Name;
            image = character.Image;
            description = character.Description;
            story = character.Story;
            money = character.Money;
            hitpoints = character.HitPoints;
            strength = character.Strength;
            dexterity = character.Dexterity;
            constitution = character.Constitution;
            intelligence = character.Intelligence;
            wisdom = character.Wisdom;
            charisma = character.Charisma;
            level = character.Level;
            IsInspired = character.IsInspired;
            abilities = character.Abilities;
            possiblespellsperday = character.PossibleSpellsPerDay;*/
        }
        #endregion

        #region Właściwości

        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<string> RaceNames { get; set; }
        public ObservableCollection<string> ClassNames { get; set; }

        public Character CurrentCharacter { get; set; }

        public Character Character
        {
            get { return _character; }
            set
            {
                _character = value;
                onPropertyChanged(nameof(Character));
            }
        }

        public string Name
        {
            get { return _character.Name; }
            set
            {
                _character.Name = value;
                onPropertyChanged(nameof(Name));
            }
        }
        public string Image
        {
            get { return _character.Image; }
            set
            {
                _character.Image = value;
                onPropertyChanged(nameof(Image));
            }
        }

        public string Description
        {
            get { return _character.Description; }
            set
            {
                _character.Description = value;
                onPropertyChanged(nameof(Description));
            }
        }

        public string Story
        {
            get { return _character.Story; }
            set
            {
                _character.Story = value;
                onPropertyChanged(nameof(Story));
            }
        }

        public int Money
        {
            get { return _character.Money; }
            set
            {
                _character.Money = value;
                onPropertyChanged(nameof(Money));
            }
        }

        public int HitPoints
        {
            get { return _character.HitPoints; }
            set
            {
                _character.HitPoints = value;
                onPropertyChanged(nameof(HitPoints));
            }
        }

        public byte Strength
        {
            get { return _character.Strength; }
            set
            {
                _character.Strength = value;
                onPropertyChanged(nameof(Strength));
            }
        }

        public byte Dexterity
        {
            get { return _character.Dexterity; }
            set
            {
                _character.Dexterity = value;
                onPropertyChanged(nameof(Dexterity));
            }
        }

        public byte Constitution
        {
            get { return _character.Constitution; }
            set
            {
                _character.Constitution = value;
                onPropertyChanged(nameof(Constitution));
            }
        }

        public byte Intelligence
        {
            get { return _character.Intelligence; }
            set
            {
                _character.Intelligence = value;
                onPropertyChanged(nameof(Intelligence));
            }
        }

        public byte Wisdom
        {
            get { return _character.Wisdom; }
            set
            {
                _character.Wisdom = value;
                onPropertyChanged(nameof(Wisdom));
            }
        }

        public byte Charisma
        {
            get { return _character.Charisma; }
            set
            {
                _character.Charisma = value;
                onPropertyChanged(nameof(Charisma));
            }
        }

        public bool IsInspired
        {
            get { return _character.IsInspired; }
            set
            {
                _character.IsInspired = value;
                onPropertyChanged(nameof(IsInspired));
            }
        }

        public byte Level
        {
            get { return _character.Level; }
            set
            {
                _character.Level = value;
                onPropertyChanged(nameof(Level));
            }
        }

        public string Race
        {
            get { return _character.Race.Name; }
            set
            {
                _character.Race.Name = value;
                onPropertyChanged(nameof(Race));
            }
        }

        public string Class
        {
            get { return _character.Class.Name; }
            set
            {
                _character.Class.Name = value;
                onPropertyChanged(nameof(Class));
            }
        }

        public Dictionary<string, byte> Abilities
        {
            get { return _character.Abilities; }
            set
            {
                _character.Abilities = value;
                onPropertyChanged(nameof(Abilities));
            }
        }

        public Dictionary<byte, byte> PossibleSpellsPerDay
        {
            get { return _character.PossibleSpellsPerDay; }
            set
            {
                _character.PossibleSpellsPerDay = value;
                onPropertyChanged(nameof(PossibleSpellsPerDay));
            }
        }

        /*public List<string> PossibleRaces {

        public List<string> PossibleRaces {
            get {
                List<string> getter = new List<string>();
                RepositoryRaces.ReadAllRaces().ForEach(race => {
                    getter.Add(race.Name);
                });
                return getter;
            }
            set { PossibleRaces = value; }
        }
        public List<string> PossibleClasses {
            get {
                List<string> getter = new List<string>();
                RepositoryClases.ReadAllClases().ForEach(x => {
                    getter.Add(x.Name);
                });
                return getter;
            }
            set { { PossibleClasses = value; } }
        }*/

        #endregion



        private void ClearSheet()
        {
            name = "";
            image = "";
            money = 20000;
            hitpoints = 20;
            strength = 0;
            dexterity = 0;
            constitution = 0;
            intelligence = 0;
            wisdom = 0;
            charisma = 0;
            isInspired = false;
            description = "";
            story = "";
            level = 0;

            abilities.Clear();
            possiblespellsperday.Clear();


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

        private ICommand edit = null;
        public ICommand Edit
        {

            get
            {
                if (edit == null)
                    edit = new RelayCommand(
                        arg => {
                            var character = new Character.Builder().WithName(Name)
                                                                    .WithRaceID(Convert.ToByte(FindRaceIDbyName(Race)))
                                                                    .WithAbilities(Abilities)
                                                                    .WithCharacterStory(Story)
                                                                    .WithCharisma(Charisma)
                                                                    .WithClassID(Convert.ToByte(FindClassIDbyName(Class)))
                                                                    .WithConstitution(Constitution)
                                                                    .WithDescription(Description)
                                                                    .WithDexterity(Dexterity)
                                                                    .WithHitPoints(Convert.ToByte(HitPoints))
                                                                    .WithInteligence(Intelligence)
                                                                    .WithLvl(Level)
                                                                    .WithName(Name)
                                                                    .WithStrenght(Strength)
                                                                    .WithWisdom(Wisdom)
                                                                    .WithPossibleSpellsPerDay(PossibleSpellsPerDay)
                                                                    .Build();


                            var final_string = character.ToInsert();
                            if (model.EditCharacterInDatabase(character, char_id))
                            {
                                //model.Characters.edit(character);
                                ClearSheet();
                                System.Windows.MessageBox.Show("Postać została edytowana!");
                            }
                        }
                        ,
                        arg => (Name != "") && (Description != "") && (Story != "") && (Class != "") && (Race != "")
                        );
                return edit;
            }
        }
        #endregion
    }
}
