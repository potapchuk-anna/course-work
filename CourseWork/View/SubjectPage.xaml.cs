using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using CourseWork.ViewModel;
using CourseWork.View;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseWork.Model;

namespace CourseWork.View
{
    /// <summary>
    /// Interaction logic for SubjectPage.xaml
    /// </summary>
    public partial class SubjectPage : Page
    {
        private SubjectViewModel model;

        public SubjectPage()
        {
            InitializeComponent();
            DataContext = new SubjectViewModel(new Model.SubjectRepository(EducationalSystemContext.Instance));
            model = (SubjectViewModel)DataContext;
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(search.Text))
            {
                Table.ItemsSource = model.SubjectList;
            }
            else
            {
                Table.ItemsSource = model.Search.Execute(search.Text);
            }
        }
    }
}
