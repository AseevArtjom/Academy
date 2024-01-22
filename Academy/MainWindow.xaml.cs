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
using Academy.Presentation.View.Pages.CRUD_Student;

namespace Academy
{
    public partial class MainWindow : Window
    {
        private MyUser CurrentUser = UserManager.GetInstance().SelectedUser;

        public MainWindow()
        {
            InitializeComponent();
            NavigatorObject.pageSwitcher = this;

            LoginScreen loginScreen = new LoginScreen();
            loginScreen.ShowDialog();
        }

        public MainWindow(MyUser currentuser)
        {

            this.CurrentUser = currentuser;
            var window = new UserControl();

            if (this.CurrentUser.Status == "Admin")
            {
                window = new HomeScreen();
            }
            else if (this.CurrentUser.Status == "Student")
            {
                window = new Student_HomeScreen();
            }
            else
            {
                MessageBox.Show("Login error!","Login Exception",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            NavigatorObject.Switch(window);
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