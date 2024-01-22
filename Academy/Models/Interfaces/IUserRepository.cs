using Academy.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Interfaces
{
    public interface IUserRepository
    {
        void Create(MyUser user);
        void Delete(int id);
        MyUser Get(int id);
        List<MyUser> GetUsers();
        void Update(MyUser user);
    }
}
