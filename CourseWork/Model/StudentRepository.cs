using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Model
{
    public class StudentRepository:Repository
    {
        public StudentRepository(EducationalSystemContext context) : base(context)
        {
        }
        public override void DataGeneration(int numberOfData)
        {
            Random random = new Random();
            List<Class> classes = context.Classes.ToList();
            if (classes.Count == 0) throw new Exception("Students cannot be generated without classes");
            for (int i = 0; i < numberOfData; i++)
            {
                Class form = classes[random.Next(classes.Count)];
                context.Students.Add(new Student()
                {
                    Name=GenerateString(random.Next(4,8),random),
                    Surname= GenerateString(random.Next(4, 11), random),
                    BirthDate=RandomDay(random),                   
                    Class = form,
                    ClassId= form.Id,

                });
            }
            context.SaveChanges();
        }
        private string GenerateString(int number, Random random)
        {
            string str = ""+(char)random.Next(65,91);
            for (int i = 0; i < number-1; i++)
            {
                str += (char)random.Next(97, 123);
            }
            return str;
        }
        DateTime RandomDay(Random gen)
        {
            DateTime start = new DateTime(2007, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
        public override void Delete(ModelBase model)
        {
            context.Students.Remove((Student)model);
            context.SaveChanges();
        }

        public override void Insert(ModelBase model)
        {
            Student student = model as Student;
            context.Students.Add(student);
            context.SaveChanges();
        }

        public override void Update(ModelBase model, ModelBase newModel)
        {
            var student = model as Student;
            var newStudent = newModel as Student;
            student.Name = newStudent.Name;
            student.Surname = newStudent.Surname;
            student.ClassId = newStudent.ClassId;
            student.BirthDate = newStudent.BirthDate;
            context.Students.Update(student);
            context.SaveChanges();
        }

        public override ObservableCollection<ModelBase> Find(string parametr)
        {
            return new ObservableCollection<ModelBase>(GetStudent(parametr));
        }

        List<Student> GetStudent(string parametr)
        {
            return context.Students.Where(d => d.Id.ToString().StartsWith(parametr) || d.Name.StartsWith(parametr) || d.Surname.StartsWith(parametr) || d.Class.Title.StartsWith(parametr)).OrderBy(c => c.Id).ToList();
        }
        public Dictionary<int, int> Analysis(Student student)
        {
            context.Students.Include(s => s.Grades);
            var studentGrades = new Dictionary<int, int>();
            for (int i = 1; i <=12; i++)
            {
                studentGrades.Add(i, context.Grades.Where(g => g.GradeValue == i).Where(g => g.Student.Equals(student)).Count());
            }
            return studentGrades;
        }

        public List<Student> FindStudentBySurname(string surname)
        {
            return context.Students.Where(s => s.Surname == surname).ToList();
        }
    }
}
