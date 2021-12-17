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
    /// Interaction logic for Insert.xaml
    /// </summary>
    public partial class TeacherDialog : Window, IDialog
    {
        public TeacherDialog()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(SurnameBox.Text) || String.IsNullOrEmpty(nameBox.Text))
            {
                MessageBox.Show("Error. Name or surname cannot be null."); return;
            }
            this.DialogResult = true;
            this.Close();           
        }


        public IDialog Instance
        {
            get
            {
                return new TeacherDialog();
            }
        }



        public ModelBase GetModel
        {
            get
            {
                return new Teacher()
                {
                    Name = nameBox.Text,
                    Surname = SurnameBox.Text
                };
            }
        }

        public void Set(ModelBase model)
        {
            Teacher teacher = model as Teacher;
            nameBox.Text = teacher.Name;
            SurnameBox.Text = teacher.Surname;
        }
        
    }
}
