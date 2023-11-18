using Academy.Domain.Entities;
using Academy.Domain.Entities.Subject;
using Academy.Domain.Entities.User;
using Academy.Domain.Interfaces;
using Academy.Presentation.View.Pages;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : UserControl
    {
        private MyUser CurrentUser;
        public HomeScreen(MyUser currentuser)
        {
            InitializeComponent();


            UserNameTextBox.Content = currentuser.GetUserName();
            CurrentUser = currentuser;

            SubjectManager.SubjectAdded += OnSubjectAdded;

            var subjectManager = SubjectManager.GetInstance();

            LVHomeScreen.ItemsSource = SubjectManager.GetInstance().Subjects;
        }

        private void LVMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LVHomeScreen.SelectedItem != null)
            {
                SubjectManager.GetInstance().SelectedSubject = (Subject)LVHomeScreen.SelectedItem;
            }
        }

        private void OnSubjectAdded(Subject subject)
        {
            LVHomeScreen.ItemsSource = null;
            LVHomeScreen.ItemsSource = SubjectManager.GetInstance().Subjects;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Schedules_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new Schedule(CurrentUser));
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
            AddSubject addSubject = new AddSubject();
            addSubject.ShowDialog();
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            SubjectMain subjectMain = new SubjectMain(CurrentUser);
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
    }
}
