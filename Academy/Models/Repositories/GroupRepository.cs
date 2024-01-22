using Academy.Domain.Entities.Group;
using Academy.Domain.Entities.User;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Repositories
{
    public class GroupRepository
    {
        string ConnectionString = @"Data Source=DESKTOP-0S5CE1C;Initial Catalog=Project_Academy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public GroupRepository()
        {

        }

        public List<Group> GetGroups()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Group>("SELECT * FROM Groups").ToList();
            }
        }

        public Group GetGroup(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Group>("SELECT * FROM Groups WHERE Id = @id", new {id}).FirstOrDefault();
            }
        }

        public void Create(string name)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "INSERT INTO Groups(Name) VALUES(@name)";
                db.Execute(query, name);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "DELETE FROM Groups WHERE Id = @id";
                db.Execute(query, new { id });
            }
        }

        public int GetIdByName(string name)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<int>("SELECT Id FROM Groups WHERE Name = @name",new {name}).FirstOrDefault();
            }
        }

        public void UpdateGroupById(int userid,int groupid)
        {
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "UPDATE Users SET GroupId = @groupid WHERE Id = @userid";
                db.Execute(query, new {groupid,userid});
            }
        }
    }
}
