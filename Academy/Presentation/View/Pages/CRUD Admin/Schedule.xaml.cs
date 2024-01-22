using Academy.Domain.Entities;
using Academy.Domain.Entities.Subject;
using Academy.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : UserControl 
    {
        private MyUser CurrentUser;

        public Schedule(MyUser myUser)
        {
            InitializeComponent();
            CurrentUser = myUser;
            UserNameTextBox.Content = CurrentUser.GetUserName();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Subject_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new HomeScreen());
        }

        private void Calendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new UsersPage(CurrentUser));
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
