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

    class ListOfCharactersViewModel : ViewModelBase
    {
        #region Składowe prywatne

        private Model model = null;
        private ObservableCollection<Character> characters = null;

        private int indexOfSelectedCharacter = -1;
        #endregion

        #region Konstruktory
        public ListOfCharactersViewModel(Model model)
        {
            this.model = model;
            characters = model.Characters;
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


        public static Character SelectedCharacter { get; set; }

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

        private ICommand chooseCharacter = null;
        public ICommand ChooseCharacter
        {
            get
            {
                if (chooseCharacter == null)
                    chooseCharacter = new RelayCommand(
                        arg =>
                        {
                            CharacterSheetViewModel charvm = new CharacterSheetViewModel();
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
                            model.DeleteCharacterFromDatabase(SelectedCharacter);
                            RefreshCharacters();
                        },
                        arg => IndexOfSelectedCharacter >= 0
                        );
                return deleteCharacter;
            }
        }

        private ICommand editCharacter = null;
        public ICommand EditCharacter
        {
            get
            {
                if (editCharacter == null)
                    editCharacter = new RelayCommand(
                        arg =>
                        {
                            EditCharacterViewModel editvm = new EditCharacterViewModel();
                        },
                        arg => IndexOfSelectedCharacter >= 0);
                return editCharacter;
            }
        }

        #endregion
    }
}
