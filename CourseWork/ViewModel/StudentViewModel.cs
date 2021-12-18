using System;
using System.Collections.Generic;
using System.Text;
using CourseWork.Model;
using CourseWork.View;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CourseWork.ViewModel
{
    class StudentViewModel
    {
        private StudentRepository repository;

        private ObservableCollection<Student> _studentsList;

        public StudentViewModel(StudentRepository repository)
        {
            //repository.context.Students.Load();
            _studentsList = repository.context.Students.Local.ToObservableCollection();
            this.repository = repository;
        }

        public ObservableCollection<Student> StudentList
        { 
            get
            {
                repository.context.Students.Load();
                return repository.context.Students.Local.ToObservableCollection(); 
            }
        }


        public ObservableCollection<Student> Students
        {
            get { return _studentsList; }
            set { _studentsList = value; }
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
                StudentDialog studentDialog = new StudentDialog(repository);
                if (mInserter == null)
                {
                    mInserter = new Insert(repository, studentDialog);
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
                StudentDialog studentDialog = new StudentDialog(repository);
                if (mUpdater == null)
                {
                    mUpdater = new Update(repository, studentDialog);
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
        private ICommand mAnalysis;
        public ICommand Analysis
        {
            get
            {
                if (mAnalysis == null)
                {
                    mAnalysis = new AnalysisCommand(repository);
                }

                return mAnalysis;
            }
            set
            {
                mAnalysis = value;
            }
        }

        class AnalysisCommand : ICommand
        {
            private StudentRepository studentRepository;
            public event EventHandler CanExecuteChanged;

            public AnalysisCommand(StudentRepository studentRepository)
            {
                this.studentRepository = studentRepository;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                if(parameter!=null)
                {
                    StudentAnalysisDialog dialog = new StudentAnalysisDialog(studentRepository.Analysis((Student)parameter));
                    dialog.ShowDialog();
                }
                if (parameter == null) MessageBox.Show("Choose student to have his/here analysis of grades.");
            }
        }
    }
}
