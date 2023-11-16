using Academy.Domain.Entities.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Academy.Presentation.View.Pages
{
    public partial class AddSubject : Window
    {
        Subject newSubject;
        public AddSubject()
        {
            InitializeComponent();
        }

        private void CreateSubject_Click(object sender, RoutedEventArgs e)
        {
            string Image = Image_TextBox.Text;
            string Name = Name_TextBox.Text;
            string Desc = Desc_TextBox.Text;
            newSubject = new Subject(Name, Desc, Image);
            SubjectManager.GetInstance().Subjects.Add(newSubject);
            this.Close();
        }
    }
}
