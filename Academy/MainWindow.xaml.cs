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
using System.Windows.Shapes;

namespace Academy
{
    public partial class MainWindow : Window
    {
        private UserList userList = new UserList();
        private SubjectList subjectList = new SubjectList();
        private MyUser CurrentUser;

        public MainWindow()
        {
            InitializeComponent();
            NavigatorObject.pageSwitcher = this;

            Admin admin = new Admin("admin","admin","Admin");
            userList.AddUser(admin);

           

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