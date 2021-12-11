using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork.Model
{
    class Grade: ModelBase
    {
        private int id;
        private int workId;
        private int grade;
        private int studentId;
        public virtual Student Student { get; set; }
        public virtual Work Work { get; set; }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public int WorkId
        {
            get { return workId; }
            set
            {
                workId = value;
                OnPropertyChanged(nameof(WorkId));
            }
        }
        public int GradeValue
        {
            get { return grade; }
            set
            {
                grade = value;
                OnPropertyChanged(nameof(Grade));
            }
        }
        public int StudentId
        {
            get { return studentId; }
            set
            {
                studentId = value;
                OnPropertyChanged(nameof(StudentId));
            }
        }
    }
}
