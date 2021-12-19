using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CourseWork.Model;
using CourseWork.ViewModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EducationalSystemContext context = EducationalSystemContext.Instance;           
            context.Classes.Load();       
            context.Teachers.Load();            
            context.Subjects.Load();                
            context.Students.Load();
            context.Works.Load();
            context.Grades.Load();
            EducationalSystemContext context1 = new EducationalSystemContext("Host=localhost;Port=5432;Database=new_educational_system;Username=user;Password=12345;CommandTimeout=1000;Timeout=1000");
            context1.CreateSubscription();
        }        
    }
}
