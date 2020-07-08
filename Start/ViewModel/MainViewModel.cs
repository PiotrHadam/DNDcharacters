 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.ViewModel
{
    using Model;
    using BaseClasses;
    using System.Windows.Input;
    using Start.DAL.Encje;

    class MainViewModel : ViewModelBase
    {
        private Model model = new Model();

        public AddCharacterViewModel AddCharacterVM { get; set; }
        public CharacterViewModel CharacterVM { get; set; }
        public ListOfCharactersViewModel ListOfCharactersVM { get; set; }
        public EditCharacterViewModel EditCharacterVM { get; set; }

        public MainViewModel()
        {
            AddCharacterVM = new AddCharacterViewModel(model);
            ListOfCharactersVM = new ListOfCharactersViewModel(model);
            Character ch = ListOfCharactersVM.SelectedCharacter;
            CharacterVM = new CharacterViewModel(model, ch);
            //Character c = CharacterVM.Character;
            //EditCharacterVM = new EditCharacterViewModel(model, c);
        }
    }
}
