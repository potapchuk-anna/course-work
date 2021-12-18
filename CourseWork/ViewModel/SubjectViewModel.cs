using CourseWork.Model;
using CourseWork.View;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace CourseWork.ViewModel
{
    class SubjectViewModel
    {
        private SubjectRepository repository;

        private ObservableCollection<Subject> _subjectsList;

        public SubjectViewModel(SubjectRepository repository)
        {
            repository.context.Subjects.Include(s => s.Teacher);      
            _subjectsList = repository.context.Subjects.Local.ToObservableCollection();
            this.repository = repository;
        }
        public ObservableCollection<Subject> SubjectList
        {
            get
            {
                repository.context.Subjects.Load();
                repository.context.Subjects.Include(s => s.Teacher);
                return repository.context.Subjects.Local.ToObservableCollection();
            }
        }
        public ObservableCollection<Subject> Subjects
        {
            get { return _subjectsList; }
            set { _subjectsList = value; }
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
                SubjectDialog subjectDialog = new SubjectDialog(repository);
                if (mInserter == null)
                {
                    mInserter = new Insert(repository, subjectDialog);
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
                SubjectDialog subjectDialog = new SubjectDialog(repository);
                if (mUpdater == null)
                {
                    mUpdater = new Update(repository, subjectDialog);                    
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
            private SubjectRepository subjectRepository;
            public event EventHandler CanExecuteChanged;

            public AnalysisCommand(SubjectRepository subjectRepository)
            {
                this.subjectRepository = subjectRepository;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                SubjectAnalysisDialog dialog = new SubjectAnalysisDialog(subjectRepository.Analysis());
                dialog.ShowDialog();              
            }
        }

    }
}
