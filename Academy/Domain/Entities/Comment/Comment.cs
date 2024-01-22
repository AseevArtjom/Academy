using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Entities.User;
using System.ComponentModel;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace Academy.Domain.Entities.Comment
{
    public class Comment : INotifyPropertyChanged
    {
        string ConnectionString = @"Data Source=DESKTOP-0S5CE1C;Initial Catalog=Project_Academy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public int _id;
        public string? _text;
        public DateTime? _dateofsending;
        int? _senderid;
        public int _homeworkid;
        public int _ownerid;

        public string _sendername;
        public string SenderName
        {
            get
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    return db.Query<string>("SELECT UserName FROM Users WHERE Id = @SenderId", new { SenderId }).FirstOrDefault();
                }
            }
            set
            {
                _sendername = value;
                OnPropertyChanged("SenderName");
            }
        }

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        public string? Text { get { return _text; } set { _text = value;OnPropertyChanged("Text"); } }
        public DateTime? DateOfSending { get { return _dateofsending; } set { _dateofsending = value; OnPropertyChanged("DateOfSending"); } }
        public int? SenderId { get { return _senderid; } set { _senderid = value; OnPropertyChanged("SenderId"); } }
        public int HomeWorkId { get { return _homeworkid; } set { _homeworkid = value; OnPropertyChanged("HomeWorkId"); } }
        public int OwnerId { get { return _ownerid; } set { _ownerid = value;OnPropertyChanged("OwnerId"); } }

        public Comment()
        {
        }

        public Comment(string text,DateTime dateofsending,int senderid,int homeworkid,int ownerid)
        {
            Text = text;
            DateOfSending = dateofsending;
            SenderId = senderid;
            HomeWorkId = homeworkid;
            OwnerId = ownerid;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }

    }
}
