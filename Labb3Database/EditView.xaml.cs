using Labb3Database.Data;
using Labb3Database.Model;
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
using System.Windows.Shapes;

namespace Labb3Database
{
    /// <summary>
    /// Interaction logic for EditView.xaml
    /// </summary>
    public partial class EditView : Window
    {
        static MongoCRUD db = new MongoCRUD("Labb3Database");
        static ObservableCollection<UserModel> users = new ObservableCollection<UserModel>();

        public EditView()
        {
            InitializeComponent();
            GetUsers();
            
        }

        public void GetUsers()
        {
            var userlist = db.GetAllUsers("Users");
            users.Clear();
            foreach (var user in userlist)
            {
                users.Add(user);
            }
            
        }

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

        private void btnCreateAcc_Click(object sender, RoutedEventArgs e)
        {
            string username = txtCreateUser.Text;
            string password = txtCreatePassword.Password;

            if (db.UserExists("Users", username, password))
            {
                MessageBox.Show("The username already exists. Please choose another one");
            }
            else
            {
                UserModel user = new UserModel(username, password);
                db.AddUser("Users", user);
                MessageBox.Show("The User has been added.");
            }

        }

        private void btnGoToMainW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goToMainWindow = new MainWindow();
            goToMainWindow.Show();
        }
    }
}
