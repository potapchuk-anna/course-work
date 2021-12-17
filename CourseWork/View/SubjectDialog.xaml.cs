using CourseWork.Model;
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

namespace CourseWork.View
{
    /// <summary>
    /// Interaction logic for SubjectDialog.xaml
    /// </summary>
    public partial class SubjectDialog : Window, IDialog
    {
        private SubjectRepository repository;
        public SubjectDialog(SubjectRepository repository)
        {
            this.repository = repository;
            InitializeComponent();
        }

        public ModelBase GetModel
        {
            get
            {
                return new Subject()
                {
                    Title = titleBox.Text,
                    Teacher = teacherBox.SelectedItem as Teacher,
                    TeacherId= (teacherBox.SelectedItem as Teacher).Id

                };
            }
        }
        private void SubjectDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var teachers = repository.context.Teachers.ToArray();
            teacherBox.ItemsSource = teachers;
        }
        public IDialog Instance => new SubjectDialog(repository);

        public void Set(ModelBase model)
        {
            Subject subject = model as Subject;
            teacherBox.SelectedItem = subject.Teacher;
            titleBox.Text = subject.Title;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (repository.context.Teachers.Count() == 0)
            {
                MessageBox.Show("Error. Subject cannot be inserted, because teachers are not created");
                return;
            }
            else if (String.IsNullOrEmpty(titleBox.Text))
            {
                MessageBox.Show("Error. Suject`s title cannot be null."); return;
            }
            else if (String.IsNullOrEmpty(teacherBox.Text))
            {
                MessageBox.Show("Error. You should choose teacher."); return;
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
