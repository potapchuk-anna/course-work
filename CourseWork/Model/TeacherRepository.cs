using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            for (int i = 0; i < numberOfData; i++)
            {
                context.Teachers.Add(new Teacher()
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

        public override void Update(ModelBase model, ModelBase newModel)
        {
            var teacher = model as Teacher;
            var newTeacher = newModel as Teacher;
            teacher.Name = newTeacher.Name;
            teacher.Surname = newTeacher.Surname;
            context.Teachers.Update(teacher);
            context.SaveChanges();
        }

        public override ObservableCollection<ModelBase> Find(string parametr)
        {
            return new ObservableCollection<ModelBase>(GetTeachers(parametr));
        }

        List<Teacher> GetTeachers(string parametr)
        {
            return context.Teachers.Where(d => d.Id.ToString().StartsWith(parametr)||d.Name.StartsWith(parametr) || d.Surname.StartsWith(parametr)).OrderBy(c => c.Id).ToList();
        }
    }
}
