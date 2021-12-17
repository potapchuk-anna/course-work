using System.Collections.Generic;
using System.Text;
using CourseWork.Model;
using CourseWork.View;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.ViewModel
{
    class GradeViewModel
    {
        private GradeRepository repository;

        private ObservableCollection<Grade> _gradesList;

        public GradeViewModel(GradeRepository repository)
        {
            repository.context.Grades.Include(s => s.Work);
            repository.context.Grades.Include(s => s.Student);
            _gradesList = repository.context.Grades.Local.ToObservableCollection();
            this.repository = repository;
        }

        public ObservableCollection<Grade> GradeList
        {
            get
            {
                repository.context.Grades.Load();
                return repository.context.Grades.Local.ToObservableCollection();
            }
        }

        public ObservableCollection<Grade> Grades
        {
            get { return _gradesList; }
            set { _gradesList = value; }
        }

        private ICommand mRemover;
        public ICommand Remove
        {
            get
            {
                if (mRemover == null)
                {
                    mRemover = new Remove(repository);
                }

                return mRemover;
            }
            set
            {
                mRemover = value;
            }
        }
        private ICommand mInserter;
        public ICommand Insert
        {
            get
            {
                GradeDialog gradeDialog = new GradeDialog(repository);
                if (mInserter == null)
                {
                    mInserter = new Insert(repository, gradeDialog);
                }

                return mInserter;
            }
            set
            {
                mInserter = value;
            }
        }
        private ICommand mUpdater;
        public ICommand Update
        {
            get
            {
                GradeDialog gradeDialog = new GradeDialog(repository);
                if (mUpdater == null)
                {
                    mUpdater = new Update(repository, gradeDialog);
                }

                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
        private ICommand mGenerater;
        public ICommand Generate
        {
            get
            {
                if (mGenerater == null)
                {
                    mGenerater = new Generate(repository);
                }

                return mGenerater;
            }
            set
            {
                mGenerater = value;
            }
        }
        public Search Search
        {
            get
            {
                Search search = new Search(repository);
                return search;
            }
        }
    }
}
