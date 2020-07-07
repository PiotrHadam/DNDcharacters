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
    /// <summary>
    /// Logika interakcji dla klasy CharacterView.xaml
    /// </summary>
    public partial class CharacterView : Page
    {
        public CharacterView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b == Delete)
            {
                //funkcja do edytowania postaci
                this.NavigationService.Navigate(new Uri("View/AddCharacter.xaml", UriKind.Relative));
            }
            else if (b == Back) this.NavigationService.Navigate(new Uri("View/ListOfCharacters.xaml", UriKind.Relative));
        }
    }
}
