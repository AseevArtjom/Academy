using Academy.Domain.Entities;
using Academy.Domain.Entities.User;
using Academy.Models.Repositories;
using Dapper;
using MaterialDesignThemes.Wpf;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class LoginScreen : Window
    {
        private MyUser currentUser;
        public LoginScreen()
        {
            InitializeComponent();
        }

        string ConnectionString = @"Data Source=DESKTOP-0S5CE1C;Initial Catalog=Project_Academy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
            UserRepository users = new UserRepository();
            foreach(MyUser item in users.GetUsers())
            {
                if(item.GetLogin() == LoginTextBox.Text && item.GetPassword() == PasswordBox.Password)
                {
                    this.Close();
                    UserManager.GetInstance().SelectedUser = item;
                    MainWindow window = new MainWindow(item);
                    
                    return;
                }
            }
            PasswordBox.BorderBrush = Brushes.Red;
            LoginTextBox.BorderBrush = Brushes.Red;

            ErrorLabel.BorderBrush = Brushes.Red;
            ErrorLabel.Content = "Invalid password or username!";
        }

        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("There is nothing we can do","Forgot Password",MessageBoxButton.OK,MessageBoxImage.Warning);
        }
    }
}
