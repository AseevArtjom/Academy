using Academy.Domain.Entities;
using Academy.Domain.Entities.HomeWork;
using Academy.Domain.Entities.Subject;
using Academy.Domain.Entities.User;
using Academy.Domain.Interfaces;
using Academy.Domain.Entities.Comment;
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
        private MyUser CurrentUser = UserManager.GetInstance().SelectedUser;

        public MainWindow()
        {
            InitializeComponent();
            NavigatorObject.pageSwitcher = this;

            var usermanager = UserManager.GetInstance();
            usermanager.Users.Add(new Admin("admin", "admin", "Admin"));
            usermanager.Users.Add(new MyUser("User","User","Default User"));

            UserManager.GetInstance().Users[1].Subjects.Add(new Subject("TEST", "TEST", ""));
            UserManager.GetInstance().Users[0].Subjects.Add(new Subject("Math", "Basic algorithms", "https://cdn.icon-icons.com/icons2/1351/PNG/512/icon-math_87982.png"));
            UserManager.GetInstance().Users[0].Subjects.Add(new Subject("Chemistry", "Basic chemical elements", "https://cdn.icon-icons.com/icons2/1617/PNG/512/3700459-chemical-chemistry-education-flask-science-test-tube_108750.png"));
            UserManager.GetInstance().Users[0].Subjects.Add(new Subject("С++", "С++ for dummies", "https://cdn.icon-icons.com/icons2/2148/PNG/512/c_icon_132529.png"));
            UserManager.GetInstance().Users[0].Subjects.Add(new Subject("Physics", "explore laws of nature", "https://cdn.icon-icons.com/icons2/609/PNG/512/molecule_icon-icons.com_56341.png"));
            UserManager.GetInstance().Users[0].Subjects.Add(new Subject("Geometry", "Shapes", "https://cdn.icon-icons.com/icons2/1617/PNG/512/3700470-drawing-geometry-measure-measuring-rulers-set-square_108760.png"));


            LoginScreen loginScreen = new LoginScreen();
            loginScreen.ShowDialog();

            
        }

        public MainWindow(MyUser currentuser)
        {

            this.CurrentUser = currentuser;
            HomeScreen homeScreen = new HomeScreen();

            

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