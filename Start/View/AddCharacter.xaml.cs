using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Start.View
{
    /// <summary>
    /// Logika interakcji dla klasy AddCharacter.xaml
    /// </summary>
    public partial class AddCharacter : Page
    {
        public ObservableCollection<string> AllowedClasses = new ObservableCollection<string>()
        {
            "Druid",
            "Kapłan",
            "Czarodziej"
        };

        public ObservableCollection<string> AllowedRaces = new ObservableCollection<string>()
        {
            "Człowiek",
            "Elf",
            "Krasnolud"
        };

        public AddCharacter()
        {
            InitializeComponent();
            Classes.ItemsSource = AllowedClasses;
            Races.ItemsSource = AllowedRaces;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b == Save)
            {
                //funkcja do zapisywania postaci
                this.NavigationService.Navigate(new AddCharacter());
            }
            else if (b == Back) this.NavigationService.Navigate(new MainPage());
        }
    }
}
