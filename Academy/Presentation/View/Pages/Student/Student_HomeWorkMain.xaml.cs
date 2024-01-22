using Academy.Domain.Entities.Comment;
using Academy.Domain.Entities.HomeWork;
using Academy.Domain.Entities.Subject;
using Academy.Domain.Entities.User;
using Academy.Domain.Entities;
using Academy.Models.Repositories;
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

namespace Academy.Presentation.View.Pages.CRUD_Student
{

    public partial class Student_HomeWorkMain : UserControl
    {
        MyUser CurrentUser;
        HomeWork SelectedHomeWork;
        HomeWorkRepository HomeWorks = new HomeWorkRepository();
        UserRepository Users = new UserRepository();
        CommentRepository comments = new CommentRepository();

        public Student_HomeWorkMain(MyUser currentuser, HomeWork selectedHomeWork)
        {
            InitializeComponent();
            SelectedHomeWork = selectedHomeWork;
            CurrentUser = currentuser;

            HomeWorkName.Content = SelectedHomeWork.Name;
            Desc_TextBox.Text = HomeWorks.GetDescById(SelectedHomeWork.Id);
            Assigner.Content = Users.Get(SelectedHomeWork.AssignerId).UserName;
            DateOfAssign.Content = SelectedHomeWork.SetHomeWork;
            Mark_Label.Content = SelectedHomeWork.Mark.ToString();

            LVComments.ItemsSource = comments.GetCommentsByHomeWorkIdAndOwnerId(SelectedHomeWork.Id, CurrentUser.Id);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Student_SubjectMain subjectMain = new Student_SubjectMain(CurrentUser);
            NavigatorObject.Switch(subjectMain);
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Sending_TextBox.Text))
            {
                comments.Create(new Comment(Sending_TextBox.Text, DateTime.Now, CurrentUser.Id, SelectedHomeWork.Id, CurrentUser.Id));
                Sending_TextBox.Text = "";
                NavigatorObject.Switch(new Student_HomeWorkMain(CurrentUser, SelectedHomeWork));
            }
        }

        private void CommentDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LVComments.SelectedItem != null)
            {
                Comment comment = LVComments.SelectedItem as Comment;
                if(CurrentUser.Id == comment.OwnerId)
                {
                    comments.Delete(comment.Id);
                }
                else
                {
                    MessageBox.Show("Only owner can delete comment!","Comment deletion",MessageBoxButton.OK,MessageBoxImage.Error);
                    return;
                }
            }
            NavigatorObject.Switch(new Student_HomeWorkMain(CurrentUser, SelectedHomeWork));
        }
    }
}
