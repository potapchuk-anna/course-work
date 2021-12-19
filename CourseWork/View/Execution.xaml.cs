using CourseWork.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for Execution.xaml
    /// </summary>
    public partial class Execution : Window
    {
        public Execution()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, long> time = new Dictionary<string, long>();
            ExecuteClasses(time);
            ExecuteGrades(time);
            ExecuteStudents(time);
            ExecuteSubjects(time);
            ExecuteTeachers(time);
            ExecuteWorks(time);

            new IndexDialog(time).ShowDialog(); 

        }

        private void ExecuteStudents(Dictionary<string,long> time)
        {
            StudentRepository studentRepository = new StudentRepository(EducationalSystemContext.Instance);          
            var result = studentRepository.FindStudentBySurname("a");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            result = studentRepository.FindStudentBySurname("a");
            sw.Stop();

            time.Add("students", sw.ElapsedMilliseconds);

            studentRepository.context.Database.ExecuteSqlRaw("CREATE INDEX student_surname_index\n" + "ON \"Students\" USING hash (\"Surname\");");

            sw = new Stopwatch();
            sw.Start();
            result = studentRepository.FindStudentBySurname("a");
            sw.Stop();

            time.Add("students_index", sw.ElapsedMilliseconds);

            studentRepository.context.Database.ExecuteSqlRaw("DROP INDEX student_surname_index");
        }
        private void ExecuteWorks(Dictionary<string, long> time)
        {
            WorkRepository workRepository = new WorkRepository(EducationalSystemContext.Instance);         
            var result = workRepository.FindWorkByTitle("A");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            result = workRepository.FindWorkByTitle("A");
            sw.Stop();

            time.Add("works", sw.ElapsedMilliseconds);

            workRepository.context.Database.ExecuteSqlRaw("CREATE INDEX work_title_index\n" + "ON \"Works\" USING hash (\"Title\");");

            sw = new Stopwatch();
            sw.Start();
            result = workRepository.FindWorkByTitle("A");
            sw.Stop();

            time.Add("works_index", sw.ElapsedMilliseconds);

            workRepository.context.Database.ExecuteSqlRaw("DROP INDEX work_title_index");
        }
        private void ExecuteSubjects(Dictionary<string, long> time)
        {
            SubjectRepository subjectRepository = new SubjectRepository(EducationalSystemContext.Instance);
            var result = subjectRepository.FindSubjectsByTitle("A");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            result = subjectRepository.FindSubjectsByTitle("A");
            sw.Stop();

            time.Add("subjects", sw.ElapsedMilliseconds);

            subjectRepository.context.Database.ExecuteSqlRaw("CREATE INDEX subject_title_index\n" + "ON \"Subjects\" USING hash (\"Title\");");

            sw = new Stopwatch();
            sw.Start();
            result = subjectRepository.FindSubjectsByTitle("A");
            sw.Stop();

            time.Add("subjects_index", sw.ElapsedMilliseconds);

            subjectRepository.context.Database.ExecuteSqlRaw("DROP INDEX subject_title_index");
        }
        private void ExecuteTeachers(Dictionary<string, long> time)
        {
            TeacherRepository teacherRepository = new TeacherRepository(EducationalSystemContext.Instance);
            var result = teacherRepository.FindTeacherBySurname("A");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            result = teacherRepository.FindTeacherBySurname("A");
            sw.Stop();

            time.Add("teachers", sw.ElapsedMilliseconds);

            teacherRepository.context.Database.ExecuteSqlRaw("CREATE INDEX teacher_surname_index\n" + "ON \"Teachers\" USING hash (\"Surname\");");

            sw = new Stopwatch();
            sw.Start();
            result = teacherRepository.FindTeacherBySurname("A");
            sw.Stop();

            time.Add("teachers_index", sw.ElapsedMilliseconds);

            teacherRepository.context.Database.ExecuteSqlRaw("DROP INDEX teacher_surname_index");
        }
        private void ExecuteGrades(Dictionary<string, long> time)
        {
            GradeRepository gradeRepository = new GradeRepository(EducationalSystemContext.Instance);
            var result = gradeRepository.FindGradeByValue(12);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            result = gradeRepository.FindGradeByValue(12);
            sw.Stop();

            time.Add("grades", sw.ElapsedMilliseconds);

            gradeRepository.context.Database.ExecuteSqlRaw("CREATE INDEX grade_value_index\n" + "ON \"Grades\" USING hash (\"GradeValue\");");

            sw = new Stopwatch();
            sw.Start();
            result = gradeRepository.FindGradeByValue(12);
            sw.Stop();

            time.Add("grades_index", sw.ElapsedMilliseconds);

            gradeRepository.context.Database.ExecuteSqlRaw("DROP INDEX grade_value_index");
        }
        private void ExecuteClasses(Dictionary<string, long> time)
        {
            ClassRepository classRepository = new ClassRepository(EducationalSystemContext.Instance);
            var result = classRepository.FindClassesByTitle("8-A");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            result = classRepository.FindClassesByTitle("8-A");
            sw.Stop();

            time.Add("classes", sw.ElapsedMilliseconds);

            classRepository.context.Database.ExecuteSqlRaw("CREATE INDEX class_title_index\n" + "ON \"Classes\" USING hash (\"Title\");");

            sw = new Stopwatch();
            sw.Start();
            result = classRepository.FindClassesByTitle("8-A");
            sw.Stop();

            time.Add("classes_index", sw.ElapsedMilliseconds);

            classRepository.context.Database.ExecuteSqlRaw("DROP INDEX class_title_index");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "./../../../../backup.bat",
                    Arguments = $"{DateTime.Now.ToFileTime()}",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Verb = "runas"
                }
            };

            process.Start();
            process.WaitForExit();
            MessageBox.Show("Backup was created");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                if (!File.Exists(dialog.FileName))
                {
                    return;
                }
                if (!dialog.FileName.EndsWith(".sql"))
                {
                    MessageBox.Show("You should choose sql-file");
                    return;
                }
                EducationalSystemContext.Instance.Database.CloseConnection();

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "./../../../../restore.bat",
                        Arguments = dialog.FileName,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        Verb = "runas"
                    }
                };

                process.Start();
                process.WaitForExit();
                MessageBox.Show("Database was restored. You should restart the application.");
                Application.Current.Shutdown();
            }
        }
    }
}
