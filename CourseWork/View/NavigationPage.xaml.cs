using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWork.View
{
    /// <summary>
    /// Interaction logic for NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Page
    {
        public NavigationPage()
        {
            InitializeComponent();
        }       
        private void comboBox_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            switch (comboBox.Text)
            {
                case "teachers":
                    Table.Content = new TeacherPage();
                    break;
                case "students":
                    Table.Content = new StudentPage();
                    break;
                case "subjects":
                    Table.Content = new SubjectPage();
                    break;
                case "grades":
                    Table.Content = new GradePage(); 
                    break;
                case "classes":
                    Table.Content = new ClassPage();
                    break;
                case "works":
                    Table.Content = new WorkPage();
                    break;
                default:
                    Table.Content = null;
                    break;
            }
        }
    }
}
