using Academy.Domain.Entities.Subject;
using Academy.Domain.Entities.User;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Repositories
{
    public class SubjectRepository
    {
        string ConnectionString = @"Data Source=DESKTOP-0S5CE1C;Initial Catalog=Project_Academy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SubjectRepository()
        {

        }

        public List<Subject> GetSubjects()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Subject>("SELECT * FROM Subjects").ToList();
            }
        }

        public Subject GetSubject(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Subject>("SELECT * FROM Subjects WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Subject subject)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "INSERT INTO Subjects(Name,Description,Image,GroupId) VALUES(@Name,@Description,@Image,@GroupId)";
                db.Execute(query, subject);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "DELETE FROM Subjects WHERE Id = @id";
                db.Execute(query, new { id });
            }
        }

        public List<Subject> GetSubjectsByGroupId(int groupid)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Subject>("SELECT * FROM Subjects WHERE GroupId = @groupid", new { groupid }).ToList();
            }
        }
    }
}