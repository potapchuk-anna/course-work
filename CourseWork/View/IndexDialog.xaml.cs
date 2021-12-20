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
    /// Interaction logic for IndexDialog.xaml
    /// </summary>
    public partial class IndexDialog : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] BarLabels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public IndexDialog(Dictionary<string,long> time)
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Title = "Without indexes",
                    Values = new ChartValues<long>()
                    {
                        time["students"],
                        time["works"],
                        time["grades"],
                        time["teachers"],
                        time["classes"],
                        time["subjects"]
                    }                  
                },
                 new ColumnSeries()
                {
                    Title = "With indexes",
                    Values = new ChartValues<long>()
                    {
                        time["students_index"],
                        time["works_index"],
                        time["grades_index"],
                        time["teachers_index"],
                        time["classes_index"],
                        time["subjects_index"]
                    }
                }

            };
            BarLabels = time.Keys.ToArray();
            Formatter = o => o.ToString();
            DataContext = this;
        }
    }
}
