using ClassRegister.Classes;
using ClassRegister.Models;
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

namespace ClassRegister.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text.Trim();
            string password = PasswordTB.Password.Trim();

            User authUser = null;
            authUser = Entities.GetContext().Users.Where(user => user.Login == login && user.Password == password).FirstOrDefault();

            if (authUser != null)
            {
                var rolesList = Entities.GetContext().UserTypes.OrderBy(p => p.Id).ToList();

                int i = 0;

                foreach (var number in rolesList)
                {
                    i = i + 1;

                    if(authUser.UserTypeId == i)
                    {
                        switch (i)
                        {
                            case 1:
                                Manager.MainFrame.Navigate(new AdminHomePage());
                                break;
                            case 2:
                                Manager.MainFrame.Navigate(new TeacherHomePage());
                                break;
                            case 3:
                                Manager.MainFrame.Navigate(new StudentHomePage());
                                break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Неверный логин и/или пароль!");
            }
        }

        private void LoginKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string login = LoginTB.Text.Trim();
                string password = PasswordTB.Password.Trim();

                User authUser = null;
                authUser = Entities.GetContext().Users.Where(user => user.Login == login && user.Password == password).FirstOrDefault();

                if (authUser != null)
                {
                    var rolesList = Entities.GetContext().UserTypes.OrderBy(p => p.Id).ToList();

                    int i = 0;

                    foreach (var number in rolesList)
                    {
                        i = i + 1;

                        if (authUser.UserTypeId == i)
                        {
                            switch (i)
                            {
                                case 1:
                                    Manager.MainFrame.Navigate(new AdminHomePage());
                                    break;
                                case 2:
                                    Manager.MainFrame.Navigate(new TeacherHomePage());
                                    break;
                                case 3:
                                    Manager.MainFrame.Navigate(new StudentHomePage());
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин и/или пароль!");
                }
            }
        }
    }
}
