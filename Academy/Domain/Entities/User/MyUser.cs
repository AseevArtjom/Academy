using Academy.Domain.Entities.Subject;
using Academy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Entities;

namespace Academy.Domain.Entities.User
{
    public class MyUser : INotifyPropertyChanged
    {
        private int _id;
        private string? _login;
        private string? _password;
        private string? _username;
        private string? _status;
        public int GroupId { get; set; }

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        public string? Login { get { return _login; } set { _login = value; OnPropertyChanged("Login"); } }
        public string? Password { get { return _password; } set { _password = value; OnPropertyChanged("Password"); } }
        public string? UserName { get { return _username; } set { _username = value; OnPropertyChanged("UserName"); } }
        public string? Status { get { return _status; } set { _status = value; OnPropertyChanged("Status"); } }
        public List<Subject.Subject> Subjects { get; set; } = new List<Subject.Subject>();


        public MyUser(string login, string password, string userName)
        {
            Login = login;
            Password = password;
            UserName = userName;
            Status = "Student";
        }

        public MyUser(int id, string login, string password, string username, string status, int groupId)
        {
            Id = id;
            Login = login;
            Password = password;
            UserName = username;
            Status = status;
            GroupId = groupId;
        }

        public MyUser(string login, string password, string username, string status, int groupId)
        {
            Login = login;
            Password = password;
            UserName = username;
            Status = status;
            GroupId = groupId;
        }

        public string GetLogin()
        {
            return Login;
        }
        public string GetPassword()
        {
            return Password;
        }
        public string GetStatus()
        {
            return Status;
        }
        public string GetUserName()
        {
            return UserName;
        }

        public override string ToString()
        {
            return $"Log : {Login},Pas : {Password},Name : {UserName},Status : {Status},Group : {GroupId}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}
