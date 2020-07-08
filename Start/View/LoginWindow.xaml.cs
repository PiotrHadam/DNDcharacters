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
using System.Windows.Shapes;

namespace Start.View
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>

    using DAL;
    using DAL.Repositories;
    using DAL.Encje;
    using Start.Model;

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        #region Metody zdarzeń
        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string nick = textBoxLogin.Text, pwd = textBoxPassword.Password;
            if (AccountCheck(nick, pwd) == false) return;
            DBConnection.Login(nick, pwd);

            MainWindow win = new MainWindow();
            win.Show();
            Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow win = new RegisterWindow();
            win.Show();
            Close();
        }

        // Sprawdzenie czy jest dostęp do bazy danych i czy istnieje użytkownik o podanych danych (nick + hasło):
        private bool AccountCheck(string nickname, string password)
        {
            if (DBConnection.LoginAsRoot() == false)
            {
                MessageBox.Show("Brak dostępu do bazy danych!");
                return false;
            }

            List<User> ExistingUsers = Model.Users;
            if (ExistingUsers.Count == 0)
            {
                MessageBox.Show("Baza użytkowników jest pusta!");
                return false;
            }

            int user_index = 0;
            while (user_index < ExistingUsers.Count)
            {
                if (ExistingUsers[user_index].UserID == nickname) break;
                user_index++;
            }
            if (user_index == ExistingUsers.Count || RepositoryUsers.HashPassword(password) != ExistingUsers[user_index].Password)
            {
                MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło!");
                return false;
            }

            return true;
        }
        #endregion
    }
}
