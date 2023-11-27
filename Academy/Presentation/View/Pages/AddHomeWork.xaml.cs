using Academy.Domain.Entities;
using Academy.Domain.Entities.HomeWork;
using Academy.Domain.Entities.Subject;
using Academy.Domain.Entities.User;
using System;
using System.Windows;

namespace Academy.Presentation.View.Pages
{
    /// <summary>
    /// Interaction logic for AddHomeWork.xaml
    /// </summary>
    public partial class AddHomeWork : Window
    {
        MyUser currentuser;
        public AddHomeWork(MyUser CurrentUser)
        {
            InitializeComponent();
            currentuser = CurrentUser;
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
                    SubjectManager.GetInstance().SelectedSubject.homeworks.AddHomeWork(new HomeWork("https://i.imgur.com/E6Q2Lzv.png", Name_TextBox.Text, startDate, endDate, currentuser, 0));
                }
                else
                {
                    SubjectManager.GetInstance().SelectedSubject.homeworks.AddHomeWork(new HomeWork(Image_TextBox.Text, Name_TextBox.Text, startDate, endDate, currentuser, 0));
                }
                
                this.Close();
                NavigatorObject.Switch(new SubjectMain(currentuser));
            }
        }
    }
}
