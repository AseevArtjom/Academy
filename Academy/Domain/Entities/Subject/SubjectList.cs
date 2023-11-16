using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities.Subject
{
    public class SubjectList : INotifyPropertyChanged
    {
        public List<Subject>? Subjects = null;



        public Subject selectedSubject
        {
            get { return selectedSubject; }
            set
            {
                selectedSubject = value;
                OnPropertyChanged("SelectedSubject");
            }
        }
        public SubjectList()
        {
            Subjects = new List<Subject>();
        }

        

        public void RemoveSubject(Subject subject)
        {
            Subjects?.Remove(subject);
        }
        public void RemoveAllSubjects()
        {
            Subjects?.Clear();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}
