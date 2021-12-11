using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Model
{
    class WorkRepository:Repository
    {
        public WorkRepository(EducationalSystemContext context) : base(context)
        {
        }
        public override void DataGeneration(int numberOfData)
        {
            Random random = new Random();
            List<Subject> subjects = context.Subjects.ToList();
            for (int i = 0; i < numberOfData; i++)
            {
                Subject subject = subjects[random.Next(subjects.Count)];
                context.Works.Add(new Work()
                {
                    Title = GenerateString(random.Next(4, 8), random),
                    Theme = GenerateString(random.Next(4, 11), random),
                    Subject = subject,
                    SubjectId = subject.Id,
                    Type = (Type)random.Next(1,5)
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
            context.Works.Remove((Work)model);
            context.SaveChanges();
        }

        public override void Insert(ModelBase model)
        {
            context.Works.Add((Work)model);
            context.SaveChanges();
        }

        public override void Update(ModelBase model)
        {
            context.Works.Update((Work)model);
            context.SaveChanges();
        }
    }
}
