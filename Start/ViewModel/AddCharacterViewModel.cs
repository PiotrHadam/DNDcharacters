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
    class AddCharacterViewModel : ViewModelBase
    {
        #region Składowe prywatne
        private Model model = null;

        private string name, image, description, story;
        private int money = 20000, hitpoints = 20;
        private byte strength = 0, dexterity = 0, constitution = 0, intelligence = 0, wisdom = 0, charisma = 0, isinspired = 0, level = 0;
        private Dictionary<string, byte> abilities;
        private Dictionary<byte, byte> possiblespellsperday;
        private bool addingAbility = true;
        private bool editingAbility = false;
        #endregion

        #region Konstruktory
        public AddCharacterViewModel(Model model)
        {
            this.model = model;
            Characters = model.Characters;
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

        public bool AddingAbility
        {
            get { return addingAbility; }
            set
            {
                addingAbility = value;
                onPropertyChanged(nameof(AddingAbility));
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


        private void CzyscFormularz()
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
            isinspired = 0;
            description = "";
            story = "";
            level = 0;
            abilities.Clear();
            possiblespellsperday.Clear();
        }

        #region Polecenia

        private ICommand add = null;
        public ICommand Add
        {

            get
            {
                if (add == null)
                    add = new RelayCommand(
                        arg =>
                        {
                            var character = new Character();

                            if (model.AddCharacterToDatabase(character))
                            {
                                CzyscFormularz();
                                System.Windows.MessageBox.Show("Osoba została dodana do bazy!");
                            }
                        }
                        ,
                        arg => (Name != "") && (Image != "") && (Story != "") && (Description != "")
                        );


                return add;
            }
        }
        #endregion
    }
}
