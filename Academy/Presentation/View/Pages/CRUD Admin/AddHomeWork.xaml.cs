using Academy.Domain.Entities;
using Academy.Domain.Entities.HomeWork;
using Academy.Domain.Entities.Subject;
using Academy.Domain.Entities.User;
using System;
using System.Windows;

namespace Academy.Presentation.View.Pages
{
    public partial class AddHomeWork : Window
    {
        MyUser currentuser;
        HomeWorkRepository homeWorkRepository = new HomeWorkRepository();
        Subject SelectedSubject;
        public AddHomeWork(MyUser CurrentUser, Subject currentSubject)
        {
            InitializeComponent();
            currentuser = CurrentUser;
            SelectedSubject = currentSubject;
        }

        private void CreateHomeWork_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = (DateTime)StartDatePicker.SelectedDate;
            DateTime endDate = (DateTime)EndDatePicker.SelectedDate;

            if (startDate.CompareTo(endDate) > 0)
            {
                MessageBox.Show("Ошибка: дата начала позже даты окончания","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Image_TextBox.Text))
                {
                    homeWorkRepository.Create(new HomeWork("https://i.imgur.com/E6Q2Lzv.png", Name_TextBox.Text, startDate, endDate, currentuser.Id,"",0),SelectedSubject.Id);
                }
                else
                {
                    homeWorkRepository.Create(new HomeWork(Image_TextBox.Text, Name_TextBox.Text, startDate, endDate, currentuser.Id,"",0), SelectedSubject.Id);
                }
                
                this.Close();
                NavigatorObject.Switch(new SubjectMain(currentuser));
            }
        }
    }
}
