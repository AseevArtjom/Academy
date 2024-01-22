using Academy.Domain.Entities;
using Academy.Domain.Entities.User;
using Academy.Models.Repositories;
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

namespace Academy.Presentation.View.Pages
{
    public partial class UsersPage : UserControl
    {
        MyUser CurrentUser;
        UserRepository users = new UserRepository();
        public UsersPage(MyUser CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
            UserNameTextBox.Content = CurrentUser.UserName;

            LVUsers.ItemsSource = users.GetUsers();
        }

        private void Updatepage()
        {
            NavigatorObject.Switch(new UsersPage(CurrentUser));
        }

        private void Schedules_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new Schedule(CurrentUser));
        }

        private void Subject_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new HomeScreen());
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
            Updatepage();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var SelectedUser = LVUsers.SelectedItem as MyUser;
            int SelectedUserId = users.GetIdByLogin(SelectedUser.Login);
            var choice = MessageBox.Show("Are you sure you want to delete " + SelectedUser.UserName + "?","Choice",MessageBoxButton.YesNo,MessageBoxImage.Question,MessageBoxResult.No);
            if (choice == MessageBoxResult.Yes)
            {
                users.Delete(SelectedUserId);
                Updatepage();
            }
            else
            {
                return;
            }   
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            if (UserPopup.IsOpen)
            {
                UserPopup.IsOpen = false;
            }
            else if (UserPopup.IsOpen == false)
            {
                UserPopup.IsOpen = true;
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            UserPopup.IsOpen = false;
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.ShowDialog();
        }
    }
}