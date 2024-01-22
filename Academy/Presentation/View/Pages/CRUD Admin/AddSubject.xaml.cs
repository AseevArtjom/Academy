using Academy.Domain.Entities;
using Academy.Domain.Entities.Subject;
using Academy.Domain.Entities.User;
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
using System.Windows.Shapes;

namespace Academy.Presentation.View.Pages
{
    public partial class AddSubject : Window
    {
        Subject newSubject;
        MyUser currentUser;

        UserRepository users = new UserRepository();
        SubjectRepository subjects = new SubjectRepository();

        public AddSubject(MyUser CurrentUser)
        {
            InitializeComponent();
            currentUser = CurrentUser;
        }

        private void CreateSubject_Click(object sender, RoutedEventArgs e)
        {
            string Image = Image_TextBox.Text;
            string Name = Name_TextBox.Text;
            string Desc = Desc_TextBox.Text;
            int GroupId = currentUser.GroupId;

            newSubject = new Subject(Name, Desc, Image,GroupId);

            subjects.Create(newSubject);


            this.Close();
            NavigatorObject.Switch(new HomeScreen());
        }
    }
}
