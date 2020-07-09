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
        public CharacterSheetViewModel CharacterVM { get; set; }
        public ListOfCharactersViewModel ListOfCharactersVM { get; set; }
        public EditCharacterViewModel EditCharacterVM { get; set; }

        public MainViewModel()
        {
            AddCharacterVM = new AddCharacterViewModel(model);
            ListOfCharactersVM = new ListOfCharactersViewModel(model);
            EditCharacterVM = new EditCharacterViewModel(model);
        }


    }
}
