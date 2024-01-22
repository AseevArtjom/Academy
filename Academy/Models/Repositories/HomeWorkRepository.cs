using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Entities.HomeWork;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Academy.Domain.Entities.Subject
{
    public class HomeWorkRepository
    {
        string ConnectionString = @"Data Source=DESKTOP-0S5CE1C;Initial Catalog=Project_Academy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public HomeWorkRepository()
        {

        }
         
        public List<HomeWork.HomeWork> GetHomeWorks()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<HomeWork.HomeWork>("SELECT * FROM HomeWorks").ToList();
            }
        }
        public List<HomeWork.HomeWork> GetHomeWorksBySubjectId(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<HomeWork.HomeWork>("SELECT * FROM HomeWorks WHERE SubjectId = @id", new { id }).ToList();
            }
        }
        public HomeWork.HomeWork GetHomeWorkById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<HomeWork.HomeWork>("SELECT * FROM HomeWorks WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(HomeWork.HomeWork homeWork, int SubjectId)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "INSERT INTO HomeWorks(Name,SetHomeWork,EndHomeWork,AssignerId,Mark,Description,SubjectId) " +
                            "VALUES(@Name,@SetHomeWork,@EndHomeWork,@AssignerId,@Mark,@Desc,@SubjectId)";
                var parameters = new
                {
                    homeWork.Name,
                    homeWork.SetHomeWork,
                    homeWork.EndHomeWork,
                    AssignerId = homeWork.AssignerId,
                    homeWork.Mark,
                    Desc = homeWork.Desc,
                    SubjectId = SubjectId
                };

                db.Execute(query, parameters);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "DELETE FROM HomeWorks WHERE Id = @id";
                db.Execute(query, new { id });
            }
        }

        public void UpdateDescription(int homeWorkId, string newDescription)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "UPDATE HomeWorks SET Description = @Description WHERE Id = @Id";
                var parameters = new { Id = homeWorkId, Description = newDescription };

                db.Execute(query, parameters);
            }
        }

        public string GetDescById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<string>("SELECT Description FROM HomeWorks WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

    }
}
