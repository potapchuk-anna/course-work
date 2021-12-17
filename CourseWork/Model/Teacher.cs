using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CourseWork.Model
{
    public class Teacher:ModelBase
    {
        private int id;
        private string name;
        private string surname;
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

       public Teacher()
        {
            Subjects = new List<Subject>();
        }

        public override string ToString()
        {
            return $"{name} {surname}";
        }
    }
}
