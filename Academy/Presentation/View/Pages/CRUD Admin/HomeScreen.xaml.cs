using Academy.Domain.Entities;
using Academy.Domain.Entities.Subject;
using Academy.Domain.Entities.User;
using Academy.Domain.Interfaces;
using Academy.Models.Repositories;
using Academy.Presentation.View.Pages;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class HomeScreen : UserControl
    {
        MyUser currentuser = UserManager.GetInstance().SelectedUser;
        SubjectRepository subjects = new SubjectRepository();
        UserRepository users = new UserRepository();
        GroupRepository groups = new GroupRepository();

        public HomeScreen()
        {
            InitializeComponent();


            UserNameTextBox.Content = currentuser.GetUserName().ToString();

            var groupList = groups.GetGroups();

            for (int i = 0; i < groupList.Count; i++)
            {
                Groups_ComboBox.Items.Add(groupList[i].Name);
                if (groupList[i].Id == currentuser.GroupId)
                {
                    Groups_ComboBox.SelectedItem = groupList[i].Name;
                }
            }

            LVHomeScreen.ItemsSource = subjects.GetSubjectsByGroupId(currentuser.GroupId);
        }

        private void LVMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LVHomeScreen.SelectedItem != null)
            {
               SubjectManager.GetInstance().SelectedSubject = (Subject)LVHomeScreen.SelectedItem;
            }
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Schedules_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new Schedule(currentuser));
        }

        public Action? CloseAction { get; set; }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            INavigator? s = nextPage as INavigator;
            if (s != null)
            {
                s.UtilizeStart(state);
            }
            else
            {
                throw new ArgumentException("NextPage is not Navigator: " + nextPage.Name.ToString());
            }
        }

        private void AddSubject_Click(object sender, RoutedEventArgs e)
        {
            AddSubject addSubject = new AddSubject(currentuser);
            addSubject.ShowDialog();
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            SubjectMain subjectMain = new SubjectMain(currentuser);
            NavigatorObject.Switch(subjectMain);
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is ListViewItem item)
            {
                if (item.DataContext is Subject selectedSubject)
                {
                    SubjectManager.GetInstance().SelectedSubject = selectedSubject;
                }
            }
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new UsersPage(currentuser));
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

        private void GroupsCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Groups_ComboBox.SelectedItem != null)
            {
                int newGroupId = groups.GetIdByName(Groups_ComboBox.SelectedValue.ToString());
                groups.UpdateGroupById(currentuser.Id, newGroupId);

                currentuser.GroupId = newGroupId;

                UserNameTextBox.Content = currentuser.GetUserName().ToString();
                LVHomeScreen.ItemsSource = subjects.GetSubjectsByGroupId(currentuser.GroupId);
            }
        }

    }
}