using System;
using System.Collections.Generic;
using System.Text;
using  CourseWork.Model;
using CourseWork.View;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.ViewModel
{
    class TeacherViewModel
    {
        private TeacherRepository repository;

        private ObservableCollection<Teacher> _teachersList;

        public TeacherViewModel(TeacherRepository repository )
        {
            //repository.context.Teachers.Load();           
            this.repository = repository;
            _teachersList = repository.context.Teachers.Local.ToObservableCollection();
        }
        public ObservableCollection<Teacher> TeacherList
        {
            get
            {
                repository.context.Teachers.Load();
                return repository.context.Teachers.Local.ToObservableCollection();
            }
        }

        public ObservableCollection<Teacher> Teachers
        {
            get { return _teachersList; }
            set { _teachersList = value; }
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
                TeacherDialog teacherDialog = new TeacherDialog();
                if (mInserter == null)
                {                  
                    mInserter = new Insert(repository, teacherDialog); 
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
                TeacherDialog teacherDialog = new TeacherDialog();
                if (mUpdater == null)
                {
                    mUpdater = new Update(repository, teacherDialog);
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
