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
using System.Net.Security;
using Academy.Domain.Entities.Subject;
using System.Security.Cryptography.Pkcs;
using Academy.Domain.Entities.HomeWork;
using Academy.Models.Repositories;

namespace Academy.Presentation.View.Pages
{
    public partial class SubjectMain : UserControl
    {
        MyUser currentuser;
        Subject SelectedSubject;
        HomeWork SelectedHomeWork;

        SubjectRepository Subjects = new SubjectRepository();
        HomeWorkRepository homeworks = new HomeWorkRepository();

        public SubjectMain(MyUser CurrentUser)
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
            NavigatorObject.Switch(new HomeScreen());
        }

        private void HomeWorkClick(object sender, RoutedEventArgs e)
        {
            HomeWorkMain homeWorkMain = new HomeWorkMain(currentuser,SelectedHomeWork);
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

        private void AddHomeWork(object sender, RoutedEventArgs e)
        {
            AddHomeWork addHomeWork = new AddHomeWork(currentuser,SelectedSubject);
            addHomeWork.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            homeworks.Delete(SelectedHomeWork.Id);
            SubjectMain subjectmain = new SubjectMain(currentuser);
            NavigatorObject.Switch(subjectmain);
        }

        private void SubjectDelete_Click(object sender, RoutedEventArgs e)
        {
            Subjects.Delete(SubjectManager.GetInstance().SelectedSubject.Id);
            HomeScreen homeScreen = new HomeScreen();
            NavigatorObject.Switch(homeScreen);
        }
    }
}
