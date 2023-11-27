using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Entities.User;
using System.ComponentModel;

namespace Academy.Domain.Entities.Comment
{
    public class Comment : INotifyPropertyChanged
    {
        public string? _commenttext;
        public DateTime? _dateofsending;
        string? _whosent;

        public string? CommentText { get { return _commenttext; } set { _commenttext = value;OnPropertyChanged("CommentText"); } }
        public DateTime? DateOfSending { get { return _dateofsending; } set { _dateofsending = value; OnPropertyChanged("DateOfSending"); } }
        public string? WhoSent { get { return _whosent; } set { _whosent = value; OnPropertyChanged("WhoSent"); } }


        public Comment(string commenttext,DateTime dateofsending,string whosent)
        {
            CommentText = commenttext;
            DateOfSending = dateofsending;
            WhoSent = whosent;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }

    }
}
