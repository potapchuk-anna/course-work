using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Model
{
    class SubjectRepository:Repository
    {
        public SubjectRepository(EducationalSystemContext context) : base(context)
        {
        }
        public override void DataGeneration(int numberOfData)
        {
            Random random = new Random();           
            List<Teacher> teachers = context.Teachers.ToList();
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

        public override void Update(ModelBase model)
        {
            context.Subjects.Update((Subject)model);
            context.SaveChanges();
        }
    }
}
