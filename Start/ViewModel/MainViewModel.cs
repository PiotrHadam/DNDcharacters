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

    class MainViewModel : ViewModelBase
    {
        private Model model = new Model();

        public AddCharacterViewModel AddCharacterVM { get; set; }
        public CharacterViewModel CharacterVM { get; set; }
        public ListOfCharactersViewModel ListOfCharactersVM { get; set; }

        public MainViewModel()
        {
            AddCharacterVM = new AddCharacterViewModel(model);
            CharacterVM = new CharacterViewModel(model);
            ListOfCharactersVM = new ListOfCharactersViewModel(model);
        }
    }
}
