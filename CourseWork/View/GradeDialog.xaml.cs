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
    /// Interaction logic for GradeDialog.xaml
    /// </summary>
    public partial class GradeDialog : Window, IDialog
    {
        private GradeRepository repository;
        public GradeDialog(GradeRepository repository)
        {
            this.repository = repository;
            InitializeComponent();
        }

        public ModelBase GetModel
        {
            get
            {
                return new Grade()
                {
                   GradeValue = gradeBox.SelectedIndex,
                   Work = workBox.SelectedItem as Work,
                   WorkId = (workBox.SelectedItem as Work).Id,
                   Student = studentBox.SelectedItem as Student,
                   StudentId = (studentBox.SelectedItem as Student).Id
                };
            }
        }


        public IDialog Instance =>  new GradeDialog(repository);

        public void Set(ModelBase model)
        {
            Grade grade = model as Grade;
            gradeBox.SelectedItem = grade.GradeValue;
            studentBox.SelectedItem = grade.Student;
            workBox.SelectedItem = grade.Work;
        }
        private void GradeDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var works = repository.context.Works.ToArray();
            workBox.ItemsSource = works;
            var students = repository.context.Students.ToArray();
            studentBox.ItemsSource = students;
            gradeBox.ItemsSource = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (repository.context.Works.Count() == 0)
            {
                MessageBox.Show("Error. Grade cannot be inserted, because works are not created");
                return;
            }
            else if (repository.context.Students.Count() == 0)
            {
                MessageBox.Show("Error. Grade cannot be inserted, because students are not created");
                return;
            }           
            else if (String.IsNullOrEmpty(gradeBox.Text))
            {
                MessageBox.Show("Error. You should choose grade."); return;
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
