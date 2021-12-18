using LiveCharts;
using LiveCharts.Wpf;
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
using System.Windows.Shapes;

namespace CourseWork.View
{
    /// <summary>
    /// Interaction logic for StudentAnalysisDialog.xaml
    /// </summary>
    public partial class StudentAnalysisDialog : Window
    {
        public StudentAnalysisDialog(Dictionary<int, int> grades)
        {
            InitializeComponent();
            int value = 0;
            grades.TryGetValue(1, out value);
            value1.Text = value.ToString();
            grades.TryGetValue(2, out value);
            value2.Text = value.ToString();
            grades.TryGetValue(3, out value);
            value3.Text = value.ToString();
            grades.TryGetValue(4, out value);
            value4.Text = value.ToString();
            grades.TryGetValue(5, out value);
            value5.Text = value.ToString();
            grades.TryGetValue(6, out value);
            value6.Text = value.ToString();
            grades.TryGetValue(7, out value);
            value7.Text = value.ToString();
            grades.TryGetValue(8, out value);
            value8.Text = value.ToString();
            grades.TryGetValue(9, out value);
            value9.Text = value.ToString();
            grades.TryGetValue(10, out value);
            value10.Text = value.ToString();
            grades.TryGetValue(11, out value);
            value11.Text = value.ToString();
            grades.TryGetValue(12, out value);
            value12.Text = value.ToString();
            DataContext = this;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
