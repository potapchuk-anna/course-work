using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork.Model
{
    public class Subject: ModelBase
    {
        private int id;
        private string title;
        private int teacherId;
        public virtual ICollection<Work> Works { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public int TeacherId
        {
            get { return teacherId; }
            set
            {
                teacherId = value;
                OnPropertyChanged(nameof(TeacherId));
            }
        }
        public Subject()
        {
            Works = new List<Work>();
        }

        public override string ToString()
        {
            return $"{title}";
        }
    }
}
