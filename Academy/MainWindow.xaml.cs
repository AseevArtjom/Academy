using Academy.Domain.Entities;
using Academy.Domain.Entities.HomeWork;
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
using System.Windows.Shapes;

namespace Academy
{
    public partial class MainWindow : Window
    {
        private UserList userList = new UserList();
        private MyUser CurrentUser;

        public MainWindow()
        {
            InitializeComponent();
            NavigatorObject.pageSwitcher = this;

            Admin admin = new Admin("admin","admin","Admin");
            userList.AddUser(admin);


            var subjectManager = SubjectManager.GetInstance();
            subjectManager.Subjects.Add(new Subject("Math", "Basic algorithms", "https://cdn.icon-icons.com/icons2/1351/PNG/512/icon-math_87982.png"));
            subjectManager.Subjects.Add(new Subject("Geometry", "Basic shapes", "https://cdn.icon-icons.com/icons2/1617/PNG/512/3700470-drawing-geometry-measure-measuring-rulers-set-square_108760.png"));
            subjectManager.Subjects.Add(new Subject("English", "Learn language", "https://cdn.icon-icons.com/icons2/3665/PNG/512/gb_flag_great_britain_england_union_jack_english_icon_228674.png"));
            subjectManager.Subjects.Add(new Subject("Geography", "Geography of the world", "https://cdn.icon-icons.com/icons2/2313/PNG/512/globe_geography_global_international_education_icon_141976.png"));
            subjectManager.Subjects.Add(new Subject("Computer science", "Basic programming languages", "https://cdn.icon-icons.com/icons2/568/PNG/512/desk_icon-icons.com_54432.png"));
            subjectManager.Subjects.Add(new Subject("Chemistry", "Molecular Science", "https://cdn.icon-icons.com/icons2/1617/PNG/512/3700459-chemical-chemistry-education-flask-science-test-tube_108750.png"));
            subjectManager.Subjects.Add(new Subject("Physics", "Explore laws of nature", "https://cdn.icon-icons.com/icons2/609/PNG/512/molecule_icon-icons.com_56341.png"));


            subjectManager.Subjects[0].homeworks.Add(new HomeWork("Essay", new DateTime(2023, 11, 18), new DateTime(2023, 11, 25), CurrentUser, 0));
            subjectManager.Subjects[0].homeworks.Add(new HomeWork("Presentation", new DateTime(2023, 11, 20), new DateTime(2023, 11, 28), CurrentUser, 0));
            subjectManager.Subjects[0].homeworks.Add(new HomeWork("Math Problems", new DateTime(2023, 11, 22), new DateTime(2023, 11, 30), CurrentUser, 0));
            subjectManager.Subjects[1].homeworks.Add(new HomeWork("Presentation", new DateTime(2023, 11, 20), new DateTime(2023, 11, 28), CurrentUser, 0));
            subjectManager.Subjects[2].homeworks.Add(new HomeWork("Math Problems", new DateTime(2023, 11, 22), new DateTime(2023, 11, 30), CurrentUser, 0));

            LoginScreen loginScreen = new LoginScreen(userList);
            loginScreen.ShowDialog();

            
        }

        public MainWindow(MyUser currentuser)
        {

            this.CurrentUser = currentuser;
            HomeScreen homeScreen = new HomeScreen(CurrentUser);
            NavigatorObject.Switch(homeScreen);
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
    }
}