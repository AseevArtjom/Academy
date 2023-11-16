using Academy.Domain.Entities;
using Academy.Domain.Entities.User;
using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        private UserList userList;
        private MyUser currentUser;
        public LoginScreen(UserList userlist)
        {
            InitializeComponent();
            this.userList = userlist;
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {         
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                PasswordPlaceholder.Visibility = Visibility.Visible;
            }         
        }


        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox != null)
            {
                if (textBox.Text == "Login *")
                {
                    textBox.Text = "";
                    textBox.Foreground = Brushes.Black;
                }
            }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox != null)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = "Login *";
                    textBox.Foreground = Brushes.Gray;
                }
                
            }
        }

        private void CreateNewAccount_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            foreach(MyUser item in userList.GetUsers())
            {
                if(item.GetLogin() == LoginTextBox.Text && item.GetPassword() == PasswordBox.Password)
                {
                    currentUser = item;
                    this.Close();
                    MainWindow window = new MainWindow(currentUser);
                    
                    return;
                }
            }
            PasswordBox.BorderBrush = Brushes.Red;
            LoginTextBox.BorderBrush = Brushes.Red;

            ErrorLabel.BorderBrush = Brushes.Red;
            ErrorLabel.Content = "Invalid password or username!";
        }
    }
}
