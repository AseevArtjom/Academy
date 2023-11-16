using Academy.Domain.Entities.User;
using Academy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities
{
    public class Admin : MyUser,IAdmin
    {
        private string Login;
        private string Password;
        private string UserName;
        private string Status;
        public Admin(string login, string password, string userName) : base(login, password, userName)
        {
            Login = login;
            Password = password;
            UserName = userName;
            Status = "Admin";
        }
    }
}
