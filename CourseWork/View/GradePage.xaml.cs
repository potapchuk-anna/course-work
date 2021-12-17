using CourseWork.Model;
using CourseWork.ViewModel;
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
    /// Interaction logic for GradePage.xaml
    /// </summary>
    public partial class GradePage : Page
    {
        private GradeViewModel model;

        public GradePage()
        {
            InitializeComponent();
            DataContext = new GradeViewModel(new Model.GradeRepository(EducationalSystemContext.Instance));
            model = (GradeViewModel)DataContext;
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(search.Text))
            {
                Table.ItemsSource = model.GradeList;
            }
            else
            {
                Table.ItemsSource = model.Search.Execute(search.Text);
            }
        }
    }
}
