using Academy.Domain.Entities.Subject;
using Academy.Domain.Entities.User;
using Academy.Domain.Entities;
using Academy.Domain.Interfaces;
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

namespace Academy.Presentation.View.Pages.CRUD_Student
{
    public partial class Student_HomeScreen : UserControl
    {
        MyUser currentuser = UserManager.GetInstance().SelectedUser;
        SubjectRepository subjects = new SubjectRepository();
        UserRepository users = new UserRepository();
        GroupRepository groups = new GroupRepository();

        public Student_HomeScreen()
        {
            InitializeComponent();


            UserNameTextBox.Content = currentuser.GetUserName().ToString();
            UserGroupName_Label.Content = groups.GetGroup(currentuser.GroupId).Name;

            LVHomeScreen.ItemsSource = subjects.GetSubjectsByGroupId(currentuser.GroupId);
        }

        private void LVMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LVHomeScreen.SelectedItem != null)
            {
                SubjectManager.GetInstance().SelectedSubject = (Subject)LVHomeScreen.SelectedItem;
            }
        }

        private void Schedules_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new Student_Schedule(currentuser));
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

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            Student_SubjectMain subjectMain = new Student_SubjectMain(currentuser);
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
