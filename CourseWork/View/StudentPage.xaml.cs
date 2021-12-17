using System;
using System.Collections.Generic;
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
using CourseWork.ViewModel;
using CourseWork.Model;

namespace CourseWork.View
{
    /// <summary>
    /// Interaction logic for StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        private StudentViewModel model;

        public StudentPage()
        {
            InitializeComponent();
            DataContext = new StudentViewModel(new Model.StudentRepository(EducationalSystemContext.Instance));
            model = (StudentViewModel)DataContext;
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(search.Text))
            {
                Table.ItemsSource = model.StudentList;
            }
            else
            {
                Table.ItemsSource = model.Search.Execute(search.Text);
            }
        }
    }
}
