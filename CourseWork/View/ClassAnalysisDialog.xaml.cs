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
    /// Interaction logic for ClassAnalysisDialog.xaml
    /// </summary>
    public partial class ClassAnalysisDialog : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] BarLabels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public ClassAnalysisDialog(List<Tuple<string, double>> classes)
        {
            InitializeComponent();
            classes = classes.Where(v => v.Item2 != 0).ToList();
            SeriesCollection = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Title = "Classes rating",
                    Values = new ChartValues<double>(classes.Select(o => o.Item2))
                }

            };
            BarLabels = classes.Select(v=>v.Item1).ToArray();
            Formatter = o => o.ToString();
            DataContext = this;
        }
    }
}
