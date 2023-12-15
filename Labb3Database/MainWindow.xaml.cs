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
using Labb3Database.Model;
using Labb3Database.Data;


namespace Labb3Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MongoCRUD db = new MongoCRUD("Labb3Database");
        static List<UserModel> users = new List<UserModel>();

        public MainWindow()
        {
            InitializeComponent();

        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            EditView editView = new EditView();

            string username = txtUser.Text;
            string password = txtPassword.Password;
            if (!db.UserExists("Users", username, password))
            {
                MessageBox.Show("Wrong Username or Password");


            }
            else
            {
                editView.Show();
            }
        }
        public void GetUsers()
        {
            users = db.GetAllUsers("Users");
            foreach (var user in users)
            {
                MessageBox.Show($"{user.UserName}{user.Password} found in the database");
            }
        }


        //private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        //{
        //    string username = txtUser.Text;
        //    string password = txtPassword.Password;

        //    if (db.UserExists("Users", username, password))
        //    {
        //        MessageBox.Show("The username already exists. Please choose another one");
        //    }
        //    else
        //    {
        //        UserModel user = new UserModel(username, password);
        //        db.CreateUser("Users", user);
        //        MessageBox.Show("The User has been added.");
        //    }

        //}

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnGoToCreate_Click(object sender, RoutedEventArgs e)
        {
            EditView editView = new EditView();
            Hide();
            editView.Show();
        }
    }
}
