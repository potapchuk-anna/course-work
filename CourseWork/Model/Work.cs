using System;
using System.Collections.Generic;
using System.Text;
using NpgsqlTypes;

namespace CourseWork.Model
{
    public enum Type
    {
        [PgName("current control")]
        CurrentControl,
        [PgName("module control work")]
        ModuleControlWork,
        [PgName("semester test")]
        SemestreTest,
        [PgName("individual work")]
        IndividualWork
    }
    public class Work:ModelBase
    {
        private int id;
        private string title;
        private string theme;
        private int subjectId;
        private Type type;
        public virtual Subject Subject { get; set; }
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
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                OnPropertyChanged(nameof(Theme));
            }
        }
        public int SubjectId
        {
            get { return subjectId; }
            set
            {
                subjectId = value;
                OnPropertyChanged(nameof(SubjectId));
            }
        }
        public Type Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        public override string ToString()
        {
            return $"{title}";
        }
    }
}
