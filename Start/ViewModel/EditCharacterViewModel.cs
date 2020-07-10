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
        private Dictionary<string, byte> abilities = new Dictionary<string, byte>();
        private Dictionary<byte, byte> possiblespellsperday = new Dictionary<byte, byte>();
        #endregion

        #region Konstruktory

        public EditCharacterViewModel()
        {
            _character = ListOfCharactersViewModel.SelectedCharacter;
            model = new Model();
            char_id = (ushort)_character.CharacterID;
            Characters = model.Characters;
            ClassNames = model.ClassNames;
            RaceNames = model.RaceNames;
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

        public uint Money
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

        #endregion



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

        private ICommand edit = null;
        public ICommand Edit
        {

            get
            {
                if (edit == null)
                    edit = new RelayCommand(
                        arg => {
                            var characterr = new Character.Builder().WithName(Name)
                                                                    .WithRaceID(Convert.ToByte(FindRaceIDbyName(Race)))
                                                                    .WithAbilities(Abilities)
                                                                    .WithMoney(Money)
                                                                    .WithCharacterStory(Story)
                                                                    .WithCharisma(Charisma)
                                                                    .WithClassID(Convert.ToByte(FindClassIDbyName(Class)))
                                                                    .WithConstitution(Constitution)
                                                                    .WithDescription(Description)
                                                                    .WithDexterity(Dexterity)
                                                                    .WithHitPoints(Convert.ToByte(HitPoints))
                                                                    .WithInteligence(Intelligence)
                                                                    .WithLvl(Level)
                                                                    .WithInspired(IsInspired)
                                                                    .WithName(Name)
                                                                    .WithStrenght(Strength)
                                                                    .WithWisdom(Wisdom)
                                                                    .WithPossibleSpellsPerDay(PossibleSpellsPerDay)
                                                                    .Build();


                            if (model.EditCharacterInDatabase(characterr, char_id))
                            {
                                ClearSheet();
                                System.Windows.MessageBox.Show("Postać została edytowana!");
                            }
                        }
                        ,
                        arg => (Name != "") && (Class != "") && (Race != "")
                        );
                return edit;
            }
        }
        #endregion
    }
}
