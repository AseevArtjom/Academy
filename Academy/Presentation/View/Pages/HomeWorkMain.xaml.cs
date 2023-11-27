using Academy.Domain.Entities;
using Academy.Domain.Entities.Subject;
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
using Academy.Domain.Entities.Comment;

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
            var subjectmanager = SubjectManager.GetInstance().SelectedSubject.SelectedHomeWork;
            HomeWorkName.Content = subjectmanager.Name;
            Desc_TextBox.Text = subjectmanager.Desc;
            Assigner.Content = subjectmanager.Assigner.GetUserName();
            DateOfAssign.Content = subjectmanager.SetHomeWork;
            

            LVComments.ItemsSource = subjectmanager.comments.Comments;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SubjectMain subjectMain = new SubjectMain(CurrentUser);
            NavigatorObject.Switch(subjectMain);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Desc_TextBox.IsReadOnly = true;
            Desc_TextBox.IsHitTestVisible = false;
            Desc_TextBox.Foreground = Brushes.Transparent;

            SavedText.Foreground = Brushes.Black;

            SubjectManager.GetInstance().SelectedSubject.SelectedHomeWork.Desc = SavedText.Text;
        }

        private void Edit_CLick(object sender, RoutedEventArgs e)
        {
            Desc_TextBox.IsReadOnly = false;
            Desc_TextBox.IsHitTestVisible = true;
            Desc_TextBox.Foreground = Brushes.Black;
            
            SavedText.Foreground = Brushes.Transparent;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            SubjectManager.GetInstance().SelectedSubject.SelectedHomeWork.comments.AddComment(new Comment(Sending_TextBox.Text,DateTime.Now,CurrentUser.UserName));
            Sending_TextBox.Text = "";
            NavigatorObject.Switch(new HomeWorkMain(CurrentUser));
        }
    }
}
