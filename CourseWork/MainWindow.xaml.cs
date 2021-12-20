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
            EducationalSystemContext main = EducationalSystemContext.Instance;
            EducationalSystemContext replica = new EducationalSystemContext("Host=localhost;Port=5432;Database=new_educational_system;Username=user;Password=12345;CommandTimeout=1000;Timeout=1000");
            replica.CreateSubscription();
            if(!(main.Classes.Any()&& main.Teachers.Any()&& main.Subjects.Any()&& main.Students.Any()
                && main.Works.Any()&&main.Grades.Any()))
            {
                main.Classes.AddRange(replica.Classes);
                main.Teachers.AddRange(replica.Teachers);
                main.Subjects.AddRange(replica.Subjects);
                main.Students.AddRange(replica.Students);
                main.Works.AddRange(replica.Works);
                main.Grades.AddRange(replica.Grades);
            }
            main.Classes.Load();       
            main.Teachers.Load();            
            main.Subjects.Load();                
            main.Students.Load();
            main.Works.Load();
            main.Grades.Load();
           
        }        
    }
}
