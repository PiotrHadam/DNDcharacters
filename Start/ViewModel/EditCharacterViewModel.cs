using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Start.ViewModel
{
    using BaseClasses;
    using Model;
    using DAL.Encje;
    class EditCharacterViewModel : ViewModelBase
    {
        #region Składowe prywatne
        private Model model = null;
        private Character character = new Character();

        private string name, image, description, story;
        private int money, hitpoints;
        private byte strength, dexterity, constitution, intelligence, wisdom, charisma, level;
        private bool isInspired = false;
        private Dictionary<string, byte> abilities;
        private Dictionary<byte, byte> possiblespellsperday;
        #endregion

        #region Konstruktory

        public EditCharacterViewModel(Model model, Character characterr)
        {
            this.model = model;
            Characters = model.Characters;
            character = characterr;
            name = character.Name;
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
            possiblespellsperday = character.PossibleSpellsPerDay;
        }
        #endregion

        #region Właściwości

        public ObservableCollection<Character> Characters { get; set; }

        public Character CurrentCharacter { get; set; }

        public string Name
        {
            get { return name; }
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

        public int Money
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

        private ICommand edit = null;
        public ICommand Edit
        {

            get
            {
                if (edit == null)
                    edit = new RelayCommand(
                        arg =>
                        {
                            var character = new Character();

                            if (model.EditCharacterInDatabase(character, character.CharacterID))
                            {
                                ClearSheet();
                                System.Windows.MessageBox.Show("Postać została zedytowana!");
                            }
                        }
                        ,
                        arg => (Name != "") && (Story != "") && (Description != "")
                        );
                return edit;
            }
        }
        #endregion
    }
}
