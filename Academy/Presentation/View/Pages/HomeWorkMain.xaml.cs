using Academy.Domain.Entities;
using Academy.Domain.Entities.User;
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

namespace Academy.Presentation.View.Pages
{
    /// <summary>
    /// Interaction logic for HomeWorkMain.xaml
    /// </summary>
    public partial class HomeWorkMain : UserControl
    {
        MyUser CurrentUser;
        public HomeWorkMain(MyUser currentuser)
        {
            InitializeComponent();
            CurrentUser = currentuser;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SubjectMain subjectMain = new SubjectMain(CurrentUser);
            NavigatorObject.Switch(subjectMain);
        }
    }
}
