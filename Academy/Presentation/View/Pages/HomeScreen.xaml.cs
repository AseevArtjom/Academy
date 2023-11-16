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

            var subjectManager = SubjectManager.GetInstance();

            SubjectManager.SubjectAdded += OnSubjectAdded;


            subjectManager.Subjects.Add(new Subject("Math", "Basic algorithms", "https://cdn.icon-icons.com/icons2/1351/PNG/512/icon-math_87982.png"));
            subjectManager.Subjects.Add(new Subject("Geometry", "Basic shapes", "https://cdn.icon-icons.com/icons2/1617/PNG/512/3700470-drawing-geometry-measure-measuring-rulers-set-square_108760.png"));
            subjectManager.Subjects.Add(new Subject("English", "Learn language", "https://cdn.icon-icons.com/icons2/3665/PNG/512/gb_flag_great_britain_england_union_jack_english_icon_228674.png"));
            subjectManager.Subjects.Add(new Subject("Geography", "Geography of the world", "https://cdn.icon-icons.com/icons2/2313/PNG/512/globe_geography_global_international_education_icon_141976.png"));
            subjectManager.Subjects.Add(new Subject("Computer science", "Basic programming languages", "https://cdn.icon-icons.com/icons2/568/PNG/512/desk_icon-icons.com_54432.png"));
            subjectManager.Subjects.Add(new Subject("Chemistry", "Molecular Science", "https://cdn.icon-icons.com/icons2/1617/PNG/512/3700459-chemical-chemistry-education-flask-science-test-tube_108750.png"));
            subjectManager.Subjects.Add(new Subject("Physics", "Explore laws of nature", "https://cdn.icon-icons.com/icons2/609/PNG/512/molecule_icon-icons.com_56341.png"));

            LVHomeScreen.ItemsSource = subjectManager.Subjects;
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
            NavigatorObject.Switch(new SubjectMain(CurrentUser));
        }
    }
}
