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
    /// Interaction logic for SubjectAnalysisDialog.xaml
    /// </summary>
    public partial class SubjectAnalysisDialog : Window
    {

        public SeriesCollection SeriesCollection { get; set; }
        public string[] BarLabels { get; set; }
        public Func<double, string> Formatter { get; set; }
      
        public SubjectAnalysisDialog(Dictionary<string,double> subjects)
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Title = "Subject grading",
                    Values = new ChartValues<double>(subjects.Values.Select(v => Math.Round(v,4)))
                }
                
            };
            BarLabels = subjects.Keys.ToArray();
            Formatter = o => o.ToString();
            DataContext = this;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
