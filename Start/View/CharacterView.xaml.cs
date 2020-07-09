using System;
using System.Windows;
using System.Windows.Controls;

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
            if (b == Edit)
            {
                //funkcja do edytowania postaci
                this.NavigationService.Navigate(new Uri("View/AddCharacter.xaml", UriKind.Relative));
            }
            else if (b == Back) this.NavigationService.Navigate(new Uri("View/ListOfCharacters.xaml", UriKind.Relative));
        }
    }
}
