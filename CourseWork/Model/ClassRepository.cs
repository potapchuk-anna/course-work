using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Model
{
    public class ClassRepository:Repository
    {
        public ClassRepository(EducationalSystemContext context) : base(context)
        {
        }
        public override void DataGeneration(int numberOfData)
        {
            Random random = new Random();
            List<Teacher> curators = context.Teachers.ToList();
            if (curators.Count == 0) throw new Exception("Classes cannot be generated without teachers. Generate teachers first");
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

        public override ObservableCollection<ModelBase> Find(string parametr)
        {
            return new ObservableCollection<ModelBase>(GetClasses(parametr));
        }

        public 
        List<Class> GetClasses(string parametr)
        { 
             return context.Classes.Where(d => d.Id.ToString().StartsWith(parametr) || d.Title.StartsWith(parametr) || d.Curator.Name.StartsWith(parametr)||d.Curator.Surname.StartsWith(parametr)).OrderBy(c=>c.Id).ToList();
        }

        public override void Insert(ModelBase model)
        {
            context.Classes.Add((Class)model);
            context.SaveChanges();
        }

        public override void Update(ModelBase model, ModelBase newModel)
        {
            var classs = model as Class;
            var newClass = newModel as Class;
            classs.Title = newClass.Title;
            classs.CuratorId = newClass.CuratorId;
            context.Classes.Update(classs);
            context.SaveChanges();
        }
        public List<Tuple<string, double>> Analysis()
        {
            context.Classes.Include(s => s.Students).ThenInclude(w => w.Grades);
            return context.Classes.Select(s => new Tuple<string, double>
            (
                s.Title,
                s.Students.Any() ? s.Students.Average(w => w.Grades.Any() ? w.Grades.Average(g => g.GradeValue) : 0) : 0
            )).ToList();
        }
        public List<Class> FindClassesByTitle(string title)
        {
            return context.Classes.Where(s => s.Title == title).ToList();
        }
    }
}
