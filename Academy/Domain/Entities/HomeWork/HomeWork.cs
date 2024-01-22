using Academy.Domain.Entities.User;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Academy.Domain.Entities.HomeWork
{
    public class HomeWork : INotifyPropertyChanged
    {
        public int _id;
        public string? _image;
        private string? _name;
        private DateTime? _sethomework;
        private DateTime? _endhomework;
        private int _assignerId;
        private int _mark;
        private string _desc;

        public Comment.CommentList comments = new Comment.CommentList();
        
        public Comment.Comment SelectedComment { get; set; }

        public int Id { get { return _id; } set { _id = value;OnPropertyChanged("Id"); } }
        public string? Image { get { return _image; } set { _image = value; OnPropertyChanged("Image"); } }
        public string? Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public DateTime? SetHomeWork { get { return _sethomework; } set { _sethomework = value; OnPropertyChanged("SetHomeWork"); } }
        public DateTime? EndHomeWork { get { return _endhomework; } set { _endhomework = value; OnPropertyChanged("EndHomeWork"); } }
        public int AssignerId { get { return _assignerId; } set { _assignerId = value; OnPropertyChanged("AssignerId"); } }
        public int Mark { get { return _mark; } set { _mark = value; OnPropertyChanged("Mark"); } }
        public string Desc { get { return _desc; } set { _desc = value;OnPropertyChanged("Desc"); } }

        public HomeWork()
        {
            Image = "https://i.imgur.com/E6Q2Lzv.png";
        }

        public HomeWork(string image,string name,DateTime set,DateTime end,int assignerid, string desc, int mark)
        {
            Image = image;
            Name = name;
            SetHomeWork = set;
            EndHomeWork = end;
            AssignerId = assignerid;
            Mark = mark;
        }
        public HomeWork(string name, DateTime set, DateTime end, int assignerid, string desc, int mark)
        {
            Image = "https://i.imgur.com/E6Q2Lzv.png";
            Name = name;
            SetHomeWork = set;
            EndHomeWork = end;
            AssignerId = assignerid;
            Mark = mark;
            Desc = desc;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}
