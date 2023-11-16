using Academy.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities.HomeWork
{
    public class HomeWork : INotifyPropertyChanged
    {
        public string? _name;
        public DateTime? _sethomework;
        public DateTime? _endhomework;
        public MyUser? _assigner;
        public int _mark;

        public string? Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public DateTime? SetHomeWork { get { return _sethomework; } set { _sethomework = value; OnPropertyChanged("SetHomeWork"); } }
        public DateTime? EndHomeWork { get { return _endhomework; } set { _endhomework = value; OnPropertyChanged("EndHomeWork"); } }
        public MyUser? Assigner { get { return _assigner; } set { _assigner = value; OnPropertyChanged("Assigner"); } }
        public int Mark { get { return _mark; } set { _mark = value; OnPropertyChanged("Mark"); } }

        public HomeWork(string name,DateTime set,DateTime end,MyUser user,int mark)
        {
            Name = name;
            SetHomeWork = set;
            EndHomeWork = end;
            Assigner = user;
            Mark = mark;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}
