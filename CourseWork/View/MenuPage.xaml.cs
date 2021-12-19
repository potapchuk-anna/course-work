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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWork.View
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void teacherButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TeacherPage());
        }

        private void classButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClassPage());
        }

        private void workButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WorkPage());
        }

        private void studentButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StudentPage());
        }

        private void subjectButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SubjectPage());
        }

        private void gradeButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GradePage());
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            Execution execution = new Execution();
            execution.ShowDialog();
        }
    }
}
