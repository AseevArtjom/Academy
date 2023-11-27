using Academy.Domain.Entities.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities.User
{
    public class UserManager
    {
        private static UserManager? _instance;
        public List<MyUser> Users { get; private set; }
        public MyUser SelectedUser { get; set; }

        private UserManager()
        {
            Users = new List<MyUser>();
        }

        public static UserManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserManager();
            }
            return _instance;
        }
    }
}
