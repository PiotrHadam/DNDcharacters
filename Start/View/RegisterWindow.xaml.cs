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
    /// Logika interakcji dla klasy RegisterWindow.xaml
    /// </summary>

    using DAL;
    using DAL.Encje;
    using DAL.Repositories;
    using Start.Model;

    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow win = new LoginWindow();
            win.Show();
            Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string nick = textBoxLogin.Text, pwd = textBoxPassword.Password;
            if (AccountCheck(nick, pwd) == false) return;
            if (RepositoryUsers.AddUser(nick, pwd) == false)
            {
                MessageBox.Show("Nie udało się utworzyć użytkownika.");
                return;
            }
            LoginWindow win = new LoginWindow();
            win.Show();
            Close();
        }

        private bool AccountCheck(string nickname, string pwd)
        {
            if (pwd.Length == 0 || nickname.Length == 0)
            {
                MessageBox.Show("Uzupełnij puste pola!");
                return false;
            }

            if (DBConnection.LoginAsRoot() == false)
            {
                MessageBox.Show("Brak dostępu do bazy danych!");
                return false;
            }

            List<User> ExistingUsers = Model.Users;
            if (ExistingUsers.Contains(null))
            {
                MessageBox.Show("Brak dostępu do bazy!");
                return false;
            }

            int user_index = 0;
            while (user_index < ExistingUsers.Count)
            {
                if (ExistingUsers[user_index].UserID == nickname)
                {
                    MessageBox.Show("Istnieje już użytkownik o takiej nazwie.");
                    return false;
                }
                user_index++;
            }
            return true;
        }
    }
}
