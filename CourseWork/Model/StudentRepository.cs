using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Model
{
    class StudentRepository:Repository
    {
        public StudentRepository(EducationalSystemContext context) : base(context)
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
            context.Students.Add((Student)model);
            context.SaveChanges();
        }

        public override void Update(ModelBase model)
        {
            context.Students.Update((Student)model);
            context.SaveChanges();
        }
    }
}
