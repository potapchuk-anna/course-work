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
    /// Interaction logic for ClassDialog.xaml
    /// </summary>
    public partial class ClassDialog : Window, IDialog
    {
        private ClassRepository repository;
        public ClassDialog(ClassRepository repository)
        {
            this.repository = repository;
            InitializeComponent();
        }

        public ModelBase GetModel
        {
            get
            {
                return new Class()
                {
                    Title = titleBox.Text,
                    Curator = teacherBox.SelectedItem as Teacher,
                    CuratorId = (teacherBox.SelectedItem as Teacher).Id
                };
            }
        }

        public IDialog Instance => new ClassDialog(repository);

        public void Set(ModelBase model)
        {
            Class form = model as Class;
            teacherBox.SelectedItem = form.Curator;
            titleBox.Text = form.Title;
        }
        private void ClassDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var teachers = repository.context.Teachers.ToArray();
            teacherBox.ItemsSource = teachers;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (repository.context.Teachers.Count() == 0)
            {
                MessageBox.Show("Error. Class cannot be inserted, because teachers are not created");
                return;
            }
            else if (String.IsNullOrEmpty(titleBox.Text))
            {
                MessageBox.Show("Error. Class`es title cannot be null."); return;
            }
            else if (String.IsNullOrEmpty(teacherBox.Text))
            {
                MessageBox.Show("Error. You should choose curator for class."); return;
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
