using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Academy.Domain.Entities.Subject
{
    public class Subject : INotifyPropertyChanged
    {
        public string? _name;
        public string? _description;
        public string? _image;

        public Subject(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }

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
