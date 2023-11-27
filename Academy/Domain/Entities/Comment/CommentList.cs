using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities.Comment
{
    public class CommentList : INotifyPropertyChanged
    {
        public List<Comment>? Comments = null;

        public Comment SelectedComment
        {
            get { return SelectedComment; }
            set
            {
                SelectedComment = value;
                OnPropertyChanged("SelectedComment");
            }
        }

        public CommentList()
        {
            Comments = new List<Comment>();
        }
        
        public void AddComment(Comment comment)
        {
            Comments?.Add(comment);
        }

        public void RemoveComment(Comment comment)
        {
            Comments?.Remove(comment);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}
