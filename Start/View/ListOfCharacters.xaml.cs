using System;
using System.Collections.Generic;
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
    using ViewModel;
    /// <summary>
    /// Logika interakcji dla klasy ListOfCharacters.xaml
    /// </summary>
    public partial class ListOfCharacters : Page
    {
        public ListOfCharacters()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b == Back) this.NavigationService.Navigate(new Uri("View/MainPage.xaml", UriKind.Relative));
            //else if (b == Choose) this.NavigationService.Navigate(new CharacterSheet());
            //else if (b == Choose) this.NavigationService.Navigate(new Uri("View/CharacterSheet.xaml"), UriKind.Relative);
            else if (b == Choose)
            {
                CharacterSheet charsh = new CharacterSheet();
                charsh.Show();
            }
        }
    }
}
