using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Start.ViewModel
{
    using BaseClasses;
    using Model;
    using DAL.Encje;
    using System.Windows.Navigation;

    class ListOfCharactersViewModel : ViewModelBase
    {
        #region Składowe prywatne

        private Model model = null;
        private ObservableCollection<Character> characters = null;
        private ObservableCollection<Class> classes = null;
        private ObservableCollection<Race> races = null;
        private ObservableCollection<Armor> armors = null;
        private ObservableCollection<Item> items = null;
        private ObservableCollection<Weapon> weapons = null;
        private ObservableCollection<Spell> spells = null;
        private ObservableCollection<CharacterSpell> links = null;

        private int indexOfSelectedCharacter = -1;
        #endregion

        #region Konstruktory
        public ListOfCharactersViewModel(Model model)
        {
            this.model = model;
            characters = model.Characters;
            classes = model.Classes;
            races = model.Races;
            armors = model.Armors;
            items = model.Items;
            weapons = model.Weapons;
            spells = model.Spells;
            links = model.Links;
        }
        #endregion

        #region Właściwości
        public int IndexOfSelectedCharacter
        {
            get => indexOfSelectedCharacter;
            set
            {
                indexOfSelectedCharacter = value;
                onPropertyChanged(nameof(IndexOfSelectedCharacter));
            }
        }

        public Character SelectedCharacter { get; set; }

        public ObservableCollection<Character> Characters
        {
            get { return characters; }
            set
            {
                characters = value;
                onPropertyChanged(nameof(Characters));
            }
        }
        #endregion

        #region Metody
        public void RefreshCharacters() => Characters = model.Characters;
        #endregion

        #region Polecenia

        /*private ICommand loadAllCharacters = null;
        public ICommand LoadAllCharacters
        {
            get
            {
                if (loadAllCharacters == null)
                    loadAllCharacters = new RelayCommand(
                        arg =>
                        {
                            Characters = model.Characters;
                        },
                        arg => true
                        );

                return loadAllCharacters;
            }
        }*/

        private ICommand chooseCharacter = null;
        public ICommand ChooseCharacter
        {
            get
            {
                if (chooseCharacter == null)
                    chooseCharacter = new RelayCommand(
                        arg =>
                        {
                            CharacterSheetViewModel charvm = new CharacterSheetViewModel(SelectedCharacter);
                        },
                        arg => IndexOfSelectedCharacter >= 0);
                return chooseCharacter;
            }
        }

        private ICommand deleteCharacter = null;
        public ICommand DeleteCharacter
        {
            get
            {
                if (deleteCharacter == null)
                    deleteCharacter = new RelayCommand(
                        arg =>
                        {
                            if (model.DeleteCharacterFromDatabase(SelectedCharacter))
                                System.Windows.MessageBox.Show("Postać usunięta!");
                            RefreshCharacters();
                        },
                        arg => IndexOfSelectedCharacter >= 0
                        );
                return deleteCharacter;
            }
        }

        #endregion
    }
}
