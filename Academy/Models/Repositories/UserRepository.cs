using Academy.Domain.Entities.User;
using Academy.Models.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        string ConnectionString = @"Data Source=DESKTOP-0S5CE1C;Initial Catalog=Project_Academy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public UserRepository(){
            
        }

        public List<MyUser> GetUsers()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<MyUser>("SELECT * FROM Users").ToList();
            }
        }

        public MyUser Get(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<MyUser>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(MyUser user)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "INSERT INTO Users(Login,Password,UserName,Status,GroupId) VALUES(@Login,@Password,@UserName,@Status,@GroupId)";
                db.Execute(query,user);
            }
        }

        public void Update(MyUser user)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "UPDATE Users SET Login = @Login, Password = @Password,UserName = @UserName,Status = @Status,GroupId = @GroupId WHERE Id = @Id";
                db.Execute(query, user);
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "DELETE FROM Users WHERE Id = @id";
                db.Execute(query, new { id });
            }
        }
        public int GetIdByLogin(string Login)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<int>("SELECT Id FROM Users WHERE Login = @Login", new { Login }).FirstOrDefault();
            }
        }
    }
}
