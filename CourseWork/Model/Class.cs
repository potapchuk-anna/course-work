using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork.Model
{
    public class Class: ModelBase
    {
        private int id;
        private string title;
        private int curatorId;

        public virtual Teacher Curator { get; set; }
        public virtual ICollection<Student> Students { get; set; }

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
        public int CuratorId
        {
            get { return curatorId; }
            set
            {
                curatorId = value;
                OnPropertyChanged(nameof(CuratorId));
            }
        }
        public Class()
        {
            Students = new List<Student>();           
        }
        public override string ToString()
        {
            return $"{title}";
        }
       
    }
}
