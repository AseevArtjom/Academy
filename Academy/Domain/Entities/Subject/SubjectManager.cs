using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities.Subject
{
    public class SubjectManager
    {
        private static SubjectManager? _instance;
        public List<Subject> Subjects { get; private set; }
        public Subject SelectedSubject { get; set; }

        private SubjectManager()
        {
            Subjects = new List<Subject>();
        }

        public static SubjectManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SubjectManager();
            }
            return _instance;
        }

        public static event Action<Subject> SubjectAdded;

        public void AddSubject(Subject subject)
        {
            Subjects?.Add(subject);
            SubjectAdded.Invoke(subject);
        }

    }
}
