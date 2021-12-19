using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Model
{
    public class GradeRepository:Repository
    {
        public GradeRepository(EducationalSystemContext context) : base(context)
        {
        }
        public override void DataGeneration(int numberOfData)
        {
            Random random = new Random();
            List<Work> works = context.Works.ToList();
            List<Student> students = context.Students.ToList();
            if (works.Count == 0) throw new Exception("Grades cannot be generated without works. Generate works first");
            if (students.Count == 0) throw new Exception("Grades cannot be generated without students. Generate students first");
            for (int i = 0; i < numberOfData; i++)
            {
                Work work = works[random.Next(works.Count)];
                Student student = students[random.Next(students.Count)];
                context.Grades.Add(new Grade()
                {
                   Work = work,
                   WorkId=work.Id,
                   GradeValue = random.Next(1,13),
                   Student = student,
                   StudentId = student.Id
                });
            }
            context.SaveChanges();
        }

        public override void Delete(ModelBase model)
        {
            context.Grades.Remove((Grade)model);
            context.SaveChanges();
        }

        public override ObservableCollection<ModelBase> Find(string parametr)
        {
            return new ObservableCollection<ModelBase>(GetGrades(parametr));
        }

        List<Grade> GetGrades(string parametr)
        {
            return context.Grades.Where(d =>d.Id.ToString().StartsWith(parametr)|| d.Student.Name.StartsWith(parametr) || d.Student.Surname.StartsWith(parametr)|| d.Work.Title.StartsWith(parametr)||d.GradeValue.ToString().StartsWith(parametr)).OrderBy(c => c.Id).ToList();
        }

        public override void Insert(ModelBase model)
        {
            int m = context.Grades.Count();
            context.Grades.Add((Grade)model);
            int n = context.Grades.Count();
            context.SaveChanges();
        }

        public override void Update(ModelBase model, ModelBase newModel)
        {
            var grade = model as Grade;
            var newGrade = newModel as Grade;
            grade.WorkId = newGrade.WorkId;
            grade.GradeValue = newGrade.GradeValue;
            grade.StudentId = newGrade.StudentId;
            context.Grades.Update(grade);
            context.SaveChanges();
        }
        public List<Grade> FindGradeByValue(int grade)
        {
            return context.Grades.Where(s => s.GradeValue == grade).ToList();
        }
    }
}
