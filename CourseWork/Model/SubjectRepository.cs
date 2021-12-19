using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Model
{
   public class SubjectRepository:Repository
    {
        public SubjectRepository(EducationalSystemContext context) : base(context)
        {
        }
        public override void DataGeneration(int numberOfData)
        {
            Random random = new Random();           
            List<Teacher> teachers = context.Teachers.ToList();
            if (teachers.Count == 0) throw new Exception("Subjects cannot be generated without teachers. Generate teachers first");
            for (int i = 0; i < numberOfData; i++)
            {
                Teacher teacher = teachers[random.Next(teachers.Count)];
                context.Subjects.Add(new Subject()
                {
                  Title = GenerateString(random.Next(4, 8), random),
                  Teacher = teacher,
                  TeacherId = teacher.Id                 

                });
            }
            context.SaveChanges();
        }
        private string GenerateString(int number, Random random)
        {
            string str = "" + (char)random.Next(65, 91);
            for (int i = 0; i < number - 1; i++)
            {
                str += (char)random.Next(97, 123);
            }
            return str;
        }
        public override void Delete(ModelBase model)
        {      
            context.Subjects.Remove((Subject)model);
            context.SaveChanges();
        }

        public override void Insert(ModelBase model)
        {
            context.Subjects.Add((Subject)model);
            context.SaveChanges();
        }

        public override void Update(ModelBase model, ModelBase newModel)
        {
            var subject = model as Subject;
            var newSubject = newModel as Subject;
            subject.Title = newSubject.Title;
            subject.TeacherId = newSubject.TeacherId;
            context.Subjects.Update(subject);
            context.SaveChanges();
        }

        public override ObservableCollection<ModelBase> Find(string parametr)
        {
            return new ObservableCollection<ModelBase>(GetSubjects(parametr));
        }

        public
        List<Subject> GetSubjects(string parametr)
        {
            return context.Subjects.Where(d => d.Id.ToString().StartsWith(parametr)||d.Title.StartsWith(parametr) || d.Teacher.Name.StartsWith(parametr) || d.Teacher.Surname.StartsWith(parametr)).OrderBy(c => c.Id).ToList();
        }

        public Dictionary<string, double> Analysis()
        {
            context.Subjects.Include(s => s.Works).ThenInclude(w => w.Grades);
            return context.Subjects.Select(s => new
            {
                Title = s.Title,
                AvgGrade = s.Works.Any() ? s.Works.Average(w => w.Grades.Any() ? w.Grades.Average(g => g.GradeValue) : 0) : 0
            }).ToDictionary(o => o.Title, o => o.AvgGrade);
        }
        public List<Subject> FindSubjectsByTitle(string title)
        {
            return context.Subjects.Where(s => s.Title == title).ToList();
        }
    }
}
