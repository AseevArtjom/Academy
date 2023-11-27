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
        public string? _image;
        private string? _name;
        private DateTime? _sethomework;
        private DateTime? _endhomework;
        private MyUser? _assigner;
        private int _mark;
        private string _desc;

        public Comment.CommentList comments = new Comment.CommentList();
        
        public Comment.Comment SelectedComment { get; set; }

        public string? Image { get { return _image; } set { _image = value; OnPropertyChanged("Image"); } }
        public string? Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public DateTime? SetHomeWork { get { return _sethomework; } set { _sethomework = value; OnPropertyChanged("SetHomeWork"); } }
        public DateTime? EndHomeWork { get { return _endhomework; } set { _endhomework = value; OnPropertyChanged("EndHomeWork"); } }
        public MyUser? Assigner { get { return _assigner; } set { _assigner = value; OnPropertyChanged("Assigner"); } }
        public int Mark { get { return _mark; } set { _mark = value; OnPropertyChanged("Mark"); } }
        public string Desc { get { return _desc; } set { _desc = value;OnPropertyChanged("Desc"); } }

        public HomeWork(string image,string name,DateTime set,DateTime end,MyUser assigner,int mark)
        {
            Image = image;
            Name = name;
            SetHomeWork = set;
            EndHomeWork = end;
            Assigner = assigner;
            Mark = mark;
        }
        public HomeWork(string name, DateTime set, DateTime end, MyUser assigner, int mark)
        {
            Image = "https://i.imgur.com/E6Q2Lzv.png";
            Name = name;
            SetHomeWork = set;
            EndHomeWork = end;
            Assigner = assigner;
            Mark = mark;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}
