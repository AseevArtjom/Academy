using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities.User
{
    public class UserList
    {
        private List<MyUser> users = new List<MyUser>();

        public void AddUser(MyUser user)
        {
            users.Add(user);
        }
        public List<MyUser> GetUsers()
        {
            return users;
        }
    }
}
