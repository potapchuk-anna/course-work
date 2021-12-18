using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using CourseWork.ViewModel;
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
    /// Interaction logic for ClassPage.xaml
    /// </summary>
    public partial class ClassPage : Page
    {
        private ClassViewModel model;
        public ClassPage()
        {
            InitializeComponent();
            DataContext = new ClassViewModel(new Model.ClassRepository(EducationalSystemContext.Instance));
            model = (ClassViewModel)DataContext;
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(String.IsNullOrEmpty(search.Text))
            {
                Table.ItemsSource = model.ClassList;
            }
            else
            {
                Table.ItemsSource = model.Search.Execute(search.Text);
            }
            
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Table.ItemsSource = model.ClassList;
            MessageBox.Show("Item was deleted.");
            search.Text = "";
        }

    }
}
