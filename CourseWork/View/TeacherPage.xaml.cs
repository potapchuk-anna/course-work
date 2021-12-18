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
using CourseWork.Model;
using CourseWork.ViewModel;


namespace CourseWork.View
{
    /// <summary>
    /// Interaction logic for TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        private TeacherViewModel model;

        public TeacherPage()
        {
            InitializeComponent();
            DataContext = new TeacherViewModel(new Model.TeacherRepository(EducationalSystemContext.Instance));
            model = (TeacherViewModel)DataContext;
        }

        private void generate_Click(object sender, RoutedEventArgs e)
        {
            //GenerateWindow generateWindow = new GenerateWindow();
            //generateWindow.ShowDialog();
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(search.Text))
            {
                Table.ItemsSource = model.TeacherList;
            }
            else
            {
                Table.ItemsSource = model.Search.Execute(search.Text);
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Table.ItemsSource = model.TeacherList;
            MessageBox.Show("Item was deleted.");
            search.Text = "";
        }
    }
}
