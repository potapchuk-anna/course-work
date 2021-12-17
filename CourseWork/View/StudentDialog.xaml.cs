using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CourseWork.Model;
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
    /// Interaction logic for StudentDialog.xaml
    /// </summary>
    public partial class StudentDialog : Window, IDialog
    {
        private StudentRepository repository;

        public ModelBase GetModel
        {
            get
            {
                return new Student()
                {
                    Name = nameBox.Text,
                    Surname = surnameBox.Text,
                    Class = (Class)classBox.SelectedItem,
                    ClassId = ((Class)classBox.SelectedItem).Id,
                    BirthDate = (DateTime)birthdate.SelectedDate
                };
            }
        }


        public IDialog Instance => new StudentDialog(repository);

        public StudentDialog(StudentRepository repository)
        {
            this.repository = repository;
            InitializeComponent();
        }

        private void StudentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var classes = repository.context.Classes.ToArray();
            classBox.ItemsSource = classes;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (repository.context.Classes.Count() == 0)
            {
                MessageBox.Show("Error. Student cannot be inserted, because classes are not created");
                return;
            }
            else if (String.IsNullOrEmpty(surnameBox.Text) || String.IsNullOrEmpty(nameBox.Text))
            {
                MessageBox.Show("Error. Name or surname cannot be null."); return;
            }
            else if(String.IsNullOrEmpty(classBox.Text))
            {
                MessageBox.Show("Error. You should choose class."); return;
            }           
            this.DialogResult = true;
            this.Close();
        }

        public void Set(ModelBase model)
        {
            Student student = model as Student;
            nameBox.Text = student.Name;
            surnameBox.Text = student.Surname;
            classBox.SelectedItem = student.Class;
            birthdate.SelectedDate = student.BirthDate;
        }
    }
}
