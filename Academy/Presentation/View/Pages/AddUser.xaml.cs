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
using System.Windows.Shapes;

namespace Academy.Presentation.View.Pages
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            Login_TextBox.BorderBrush = Brushes.Gray;
            Password_TextBox.BorderBrush = Brushes.Gray;
            UserName_TextBox.BorderBrush = Brushes.Gray;
            Status_ComboBox.BorderBrush = Brushes.Gray;

            if (string.IsNullOrWhiteSpace(UserName_TextBox.Text))
            {
                UserName_TextBox.BorderBrush = Brushes.Red;
            }
            else if (string.IsNullOrWhiteSpace(Login_TextBox.Text) || string.IsNullOrWhiteSpace(Password_TextBox.Text))
            {
                Login_TextBox.BorderBrush = Brushes.Red;
                Password_TextBox.BorderBrush = Brushes.Red;
            }
            else if(Status_ComboBox.SelectedIndex == -1)
            {
                Status_ComboBox.BorderBrush = Brushes.Red;
            }
            else
            {
                string Login = Login_TextBox.Text;
                string Password = Password_TextBox.Text;
                string UserName = UserName_TextBox.Text;
                if (Status_ComboBox.SelectedIndex == 0) 
                {
                    UserManager.GetInstance().Users.Add(new MyUser(Login, Password, UserName));
                }
                else if (Status_ComboBox.SelectedIndex == 1)
                {
                    UserManager.GetInstance().Users.Add(new Admin(Login, Password, UserName));
                }
                this.Close();
            }
        }
    }
}
