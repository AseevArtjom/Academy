using Academy.Domain.Entities.User;
using Academy.Domain.Entities;
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
using Academy.Models.Repositories;

namespace Academy.Presentation.View.Pages.CRUD_Student
{

    public partial class Student_Schedule : UserControl
    {
        private MyUser CurrentUser;
        GroupRepository groups = new GroupRepository();

        public Student_Schedule(MyUser myUser)
        {
            InitializeComponent();
            CurrentUser = myUser;
            UserNameTextBox.Content = CurrentUser.GetUserName();
            UserGroupName_Label.Content = groups.GetGroup(CurrentUser.GroupId).Name;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Subject_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new Student_HomeScreen());
        }

        private void Calendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

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
