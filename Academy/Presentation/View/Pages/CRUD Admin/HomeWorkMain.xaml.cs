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
using Academy.Domain.Entities.HomeWork;
using Academy.Models.Repositories;
using Academy.Domain.Entities.Group;

namespace Academy.Presentation.View.Pages
{
    public partial class HomeWorkMain : UserControl
    {
        MyUser CurrentUser;
        HomeWork SelectedHomeWork;
        HomeWorkRepository HomeWorks = new HomeWorkRepository();
        UserRepository Users = new UserRepository();
        CommentRepository comments = new CommentRepository();

        public HomeWorkMain(MyUser currentuser, HomeWork selectedHomeWork)
        {
            InitializeComponent();
            SelectedHomeWork = selectedHomeWork;
            CurrentUser = currentuser;

            HomeWorkName.Content = SelectedHomeWork.Name;
            Desc_TextBox.Text = HomeWorks.GetDescById(SelectedHomeWork.Id);
            Assigner.Content = Users.Get(SelectedHomeWork.AssignerId).UserName;
            DateOfAssign.Content = SelectedHomeWork.SetHomeWork;
            Mark_Combobox.Text = SelectedHomeWork.Mark.ToString();

            LVComments.ItemsSource = comments.GetCommentsByHomeWorkIdAndOwnerId(SelectedHomeWork.Id, CurrentUser.Id);
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

            HomeWorks.UpdateDescription(SelectedHomeWork.Id, SavedText.Text);
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
            if (!string.IsNullOrWhiteSpace(Sending_TextBox.Text))
            {
                comments.Create(new Comment(Sending_TextBox.Text, DateTime.Now, CurrentUser.Id, SelectedHomeWork.Id, CurrentUser.Id));
                Sending_TextBox.Text = "";
                NavigatorObject.Switch(new HomeWorkMain(CurrentUser, SelectedHomeWork));
            }
        }

        private void CommentDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LVComments.SelectedItem != null)
            {
                Comment comment = LVComments.SelectedItem as Comment;
                comments.Delete(comment.Id);
            }
            NavigatorObject.Switch(new HomeWorkMain(CurrentUser, SelectedHomeWork));
        }

        private void Mark_Combobox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                if (Mark_Combobox.SelectedIndex > 0)
                {
                    Mark_Combobox.SelectedIndex -= 1;
                }
            }
        }
    }
}
