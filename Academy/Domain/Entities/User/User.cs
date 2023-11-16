using Academy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities.User
{
    public class MyUser : IUser
    {
        private string Login;
        private string Password;
        private string UserName;
        private string Status;
        public MyUser(string login, string password, string userName)
        {
            Login = login;
            Password = password;
            UserName = userName;
            Status = "Student";
        }
        public string GetLogin()
        {
            return Login;
        }
        public string GetPassword()
        {
            return Password;
        }
        public string GetStatus()
        {
            return Status;
        }
        public string GetUserName()
        {
            return UserName;
        }
    }
}
