using Academy.Domain.Entities.Comment;
using Academy.Domain.Entities.Subject;
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
    public class CommentRepository
    {
        string ConnectionString = @"Data Source=DESKTOP-0S5CE1C;Initial Catalog=Project_Academy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public CommentRepository()
        {

        }

        public List<Comment> GetCommentsByHomeWorkIdAndOwnerId(int homeworkid,int userid)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Comment>("SELECT * FROM Comments WHERE HomeWorkId = @homeworkid AND OwnerId = @userid", new { homeworkid,userid }).ToList();
            }
        }

        public void Create(Comment comment)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "INSERT INTO Comments(Text,DateOfSending,SenderId,HomeWorkId,OwnerId) VALUES(@Text,@DateOfSending,@SenderId,@HomeWorkId,@OwnerId)";
                db.Execute(query, comment);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var query = "DELETE FROM Comments WHERE Id = @id";
                db.Execute(query, new { id });
            }
        }
    }
}
