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
    /// Interaction logic for GenerateWindow.xaml
    /// </summary>
    public partial class GenerateWindow : Window
    {
        public GenerateWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            int n = 0;
            if(!int.TryParse(numberBox.Text,out n))
            {
                MessageBox.Show("You should enter the number.");
                return;
            }
            else if(n<0)
            {
                MessageBox.Show("Number should be positive.");
                return;
            }
            this.DialogResult = true;
        }

        public string Number
        {
            get { return numberBox.Text; }
        }
    }
}
