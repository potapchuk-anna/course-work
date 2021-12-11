using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Model
{
    class ClassRepository:Repository
    {
        public ClassRepository(EducationalSystemContext context) : base(context)
        {
        }
        public override void DataGeneration(int numberOfData)
        {
            Random random = new Random();
            List<Teacher> curators = context.Teachers.ToList();
            for (int i = 0; i < numberOfData; i++)
            {
                Teacher curator = curators[random.Next(curators.Count)];
                context.Classes.Add(new Class()
                {
                    Title = random.Next(1, 12) + "-" + (char)random.Next(65, 69),
                    Curator = curator,
                    CuratorId = curator.Id
                });
            }
            context.SaveChanges();
        }
       
        public override void Delete(ModelBase model)
        {
            context.Classes.Remove((Class)model);
            context.SaveChanges();
        }

        public override void Insert(ModelBase model)
        {
            context.Classes.Add((Class)model);
            context.SaveChanges();
        }

        public override void Update(ModelBase model)
        {
            context.Classes.Update((Class)model);
            context.SaveChanges();
        }
    }
}
