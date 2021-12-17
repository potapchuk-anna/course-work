using CourseWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CourseWork.View;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Type = CourseWork.Model.Type;

namespace CourseWork.View
{
    /// <summary>
    /// Interaction logic for WorkDialog.xaml
    /// </summary>
    public partial class WorkDialog : Window, IDialog
    {
        private WorkRepository repository;

        public ModelBase GetModel
        {
            get
            {
                return new Work()
                {
                   Title = titleBox.Text,
                   Type = (Type)typeBox.SelectedItem,
                   Theme = themeBox.Text,
                   Subject = subjectBox.SelectedItem as Subject,
                   SubjectId = (subjectBox.SelectedItem as Subject).Id

                };
            }
        }


        public IDialog Instance => new WorkDialog(repository);

        public WorkDialog(WorkRepository repository)
        {
            this.repository = repository;
            InitializeComponent();
        }

        private void WorkDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var subjects = repository.context.Subjects.ToArray();
            subjectBox.ItemsSource = subjects;
            typeBox.ItemsSource = Enum.GetValues(typeof(Type)).Cast<Type>();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (repository.context.Subjects.Count() == 0)
            {
                MessageBox.Show("Error. Work cannot be inserted, because subjects are not created");
                return;
            }
            else if (String.IsNullOrEmpty(titleBox.Text) || String.IsNullOrEmpty(themeBox.Text))
            {
                MessageBox.Show("Error. Title or theme cannot be null."); return;
            }
            else if(String.IsNullOrEmpty(typeBox.Text))
            {
                MessageBox.Show("Error. You should choose type of work."); return;
            }           
            this.DialogResult = true;
            this.Close();
        }

        public void Set(ModelBase model)
        {
            Work work = model as Work;
            titleBox.Text = work.Title;
            themeBox.Text = work.Theme;
            typeBox.SelectedItem = work.Type;
            subjectBox.SelectedItem = work.Subject;
        }
    }
}
