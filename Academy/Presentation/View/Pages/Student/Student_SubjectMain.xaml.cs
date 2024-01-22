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
    public partial class Student_SubjectMain : UserControl
    {
        MyUser currentuser;
        Subject SelectedSubject;
        HomeWork SelectedHomeWork;
        HomeWorkRepository homeworks = new HomeWorkRepository();

        public Student_SubjectMain(MyUser CurrentUser)
        {
            InitializeComponent();
            currentuser = CurrentUser;

            SelectedSubject = SubjectManager.GetInstance().SelectedSubject;


            SubjectName.Content = SelectedSubject.Name;
            if (SelectedSubject.Image != "")
            {
                var bitmapImage = new BitmapImage(new Uri(SelectedSubject.Image));
                LogoImage.Source = bitmapImage;
            }




            LVHomeWork.ItemsSource = homeworks.GetHomeWorksBySubjectId(SelectedSubject.Id);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new Student_HomeScreen());
        }

        private void HomeWorkClick(object sender, RoutedEventArgs e)
        {
            Student_HomeWorkMain homeWorkMain = new Student_HomeWorkMain(currentuser, SelectedHomeWork);
            NavigatorObject.Switch(homeWorkMain);
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is ListViewItem item)
            {
                if (item.DataContext is HomeWork selectedhomework)
                {
                    SelectedHomeWork = selectedhomework;
                }
            }
        }
    }
}
