using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using Academy.Domain.Entities.HomeWork;

namespace Academy.Domain.Entities.Subject
{
    public class Subject : INotifyPropertyChanged
    {
        public int _id;
        public string? _name;
        public string? _description;
        public string? _image;
        public int GroupId { get; set; }

        public HomeWorkList homeworks = new HomeWorkList();
        public HomeWork.HomeWork SelectedHomeWork { get; set; }

        // -
        public Subject(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }

        public Subject(int id,string name,string description,string image,int groupid)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            GroupId = groupid;
        }

        public Subject(string name, string description, string image, int groupid)
        {
            Name = name;
            Description = description;
            Image = image;
            GroupId = groupid;
        }

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        public string? Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public string? Description { get { return _description; } set { _description = value; OnPropertyChanged("Description"); } }
        public string? Image { get { return _image; } set { _image = value; OnPropertyChanged("Image"); } }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }

    }
}
