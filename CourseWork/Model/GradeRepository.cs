using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Model
{
    class GradeRepository:Repository
    {
        public GradeRepository(EducationalSystemContext context) : base(context)
        {
        }
        public override void DataGeneration(int numberOfData)
        {
            Random random = new Random();
            List<Work> works = context.Works.ToList();
            List<Student> students = context.Students.ToList();
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

        public override void Insert(ModelBase model)
        {
            context.Grades.Add((Grade)model);
            context.SaveChanges();
        }

        public override void Update(ModelBase model)
        {
            context.Grades.Update((Grade)model);
            context.SaveChanges();
        }
    }
}
