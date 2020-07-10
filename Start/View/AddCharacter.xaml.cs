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
using Start.ViewModel;

namespace Start.View
{
    using DAL.Encje;
    using Start.DAL.Repositories;
    using Start.ViewModel;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Logika interakcji dla klasy AddCharacter.xaml
    /// </summary>
    public partial class AddCharacter : Page
    {

        public AddCharacter()
        {
            InitializeComponent();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b == Back) this.NavigationService.Navigate(new Uri("View/MainPage.xaml", UriKind.Relative));
            else if (b == Save) this.NavigationService.Navigate(new Uri("View/AddItems.xaml", UriKind.Relative));
        }

        private static readonly Regex _regex = new Regex("[^0-9]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

    }
}
