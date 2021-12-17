using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork.Model
{
    public class Student:ModelBase
    {
        private int id;
        private string name;
        private string surname;
        private int classId;
        private DateTime birthdate;
        public virtual Class Class { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
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
        public int ClassId
        {
            get { return classId; }
            set
            {
                classId = value;
                OnPropertyChanged(nameof(ClassId));
            }
        }
        public DateTime BirthDate
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
        public Student()
        {
            Grades = new List<Grade>();
        }
        public override string ToString()
        {
            return $"{name} {surname}";
        }
    }
}
