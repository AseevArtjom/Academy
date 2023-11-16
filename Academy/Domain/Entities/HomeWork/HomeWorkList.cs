using Academy.Domain.Entities.Subject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities.HomeWork
{
    public class HomeWorkList : INotifyPropertyChanged
    {
        public List<HomeWork>? HomeWorks = null;

        public HomeWorkList()
        {
            HomeWorks = new List<HomeWork>();
        }

        public void AddHomeWork(HomeWork homeWork)
        {
            HomeWorks?.Add(homeWork);
        }

        public void RemoveHomeWork(HomeWork homeWork)
        {
            HomeWorks?.Remove(homeWork);
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}
