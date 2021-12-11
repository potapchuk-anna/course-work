using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork.View;
namespace CourseWork.Model
{
    class TeacherRepository : Repository
    {
        public TeacherRepository(EducationalSystemContext context) : base(context)
        {

        }

        public override void DataGeneration(int numberOfData)
        {
            Random random = new Random();
            List<Class> classes = context.Classes.ToList();
            for (int i = 0; i < numberOfData; i++)
            {
                Class form = classes[random.Next(classes.Count)];
                context.Students.Add(new Student()
                {
                    Name = GenerateString(random.Next(4, 8), random),
                    Surname = GenerateString(random.Next(4, 11), random),
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
            context.Teachers.Remove((Teacher)model);
            context.SaveChanges();
        }

        public override void Insert(ModelBase model)
        {
            context.Teachers.Add((Teacher)model);
            context.SaveChanges();
        }

        public override void Update(ModelBase model)
        {
            context.Teachers.Update((Teacher)model);
            context.SaveChanges();
        }
    }
}
