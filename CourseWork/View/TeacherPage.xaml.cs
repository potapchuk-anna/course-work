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


namespace CourseWork.View
{
    /// <summary>
    /// Interaction logic for TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public bool isGenerationClicked { get; private set; }
        public TeacherPage()
        {
            InitializeComponent();
            DataContext = new TeacherViewModel(new Model.TeacherRepository(new Model.EducationalSystemContext()));
        }

        private void generate_Click(object sender, RoutedEventArgs e)
        {           
            isGenerationClicked = true;
        }

    }
}
