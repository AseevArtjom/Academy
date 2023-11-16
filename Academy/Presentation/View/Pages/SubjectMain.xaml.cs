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

namespace Academy.Presentation.View.Pages
{
    /// <summary>
    /// Interaction logic for SubjectMain.xaml
    /// </summary>
    public partial class SubjectMain : UserControl
    {
        MyUser currentuser;
        public SubjectMain(MyUser CurrentUser)
        {
            InitializeComponent();
            currentuser = CurrentUser;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new HomeScreen(currentuser));
        }
    }
}
