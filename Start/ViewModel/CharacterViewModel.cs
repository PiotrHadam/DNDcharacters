using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.ViewModel
{
    using DAL.Encje;
    using BaseClasses;
    using Model;
    using System.Windows.Input;

    class CharacterViewModel : ViewModelBase
    {
        #region Składowe prywatne
        private Model model = null;
        private Character character = null;

        private string name, image, description, story;
        private int money = 0, hitpoints = 0;
        private byte strength = 0, dexterity = 0, constitution = 0, intelligence = 0, wisdom = 0, charisma = 0, isinspired = 0, level = 0;
        private Dictionary<string, byte> abilities;
        private Dictionary<byte, byte> possiblespellsperday;
        private bool editingAbility = true;
        #endregion

        #region Konstruktory
        public CharacterViewModel(Model model)
        {
            this.model = model;
        }

        public CharacterViewModel(Model model, Character character)
        {
            this.model = model;
            this.character = character;
        }
        #endregion

        #region Właściwości

        public Character Character
        {
            get { return character; }
            set
            {
                character = value;
                onPropertyChanged(nameof(Character));
            }
        }

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

        public byte IsInspired
        {
            get { return isinspired; }
            set
            {
                isinspired = value;
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

        public bool EditingAbility
        {
            get { return editingAbility; }
            set
            {
                editingAbility = value;
                onPropertyChanged(nameof(EditingAbility));
            }
        }
        #endregion

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
                            AddCharacterViewModel editing = new AddCharacterViewModel(model);
                        },
                        arg => true);
                return edit;
            }
        }
        #endregion
    }
}
