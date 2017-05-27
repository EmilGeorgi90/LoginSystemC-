using System;
using CRUD;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace LoginSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CRUD.MainWindow newwindows;
        Login login = new Login("Data Source=MININT-HGBTR5E;Initial Catalog=login;Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            bool usernameTest = login.LoginUserName(TxtUsername.Text);
            bool passwordTest = login.LoginPassword(Password.Password);
            if (usernameTest == true && passwordTest == true)
            {
                Login FilmInfo = new Login("Data Source=MININT-HGBTR5E;Initial Catalog=Filminfo;Integrated Security=True");
                newwindows = new CRUD.MainWindow();
                newwindows.Show();
                

            }
            else
            {
                MessageBox.Show("It is not a valid login");
            }

        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                login.Save(TxtUsername.Text, Password.Password);

            }
            catch (SqlException)
            {

                MessageBox.Show("it is not a valid username/password");
            }
        }
    }
    }

