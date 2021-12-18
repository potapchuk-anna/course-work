using System.Collections.Generic;
using System.Text;
using CourseWork.Model;
using CourseWork.View;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace CourseWork.ViewModel
{
    class ClassViewModel
    {
        private ClassRepository repository;

        private ObservableCollection<Class> _classesList;

        public ClassViewModel(ClassRepository repository)
        {
            repository.context.Classes.Include(s => s.Curator);
            this.repository = repository;
            _classesList = ClassList;          
        }

        public ObservableCollection<Class> ClassList
        {
            get
            {
                repository.context.Classes.Load();
                return repository.context.Classes.Local.ToObservableCollection();
            }
        }

        public ObservableCollection<Class> Classs
        {
            get { return _classesList; }
            set { _classesList = value; }
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
                ClassDialog classDialog = new ClassDialog(repository);
                if (mInserter == null)
                {
                    mInserter = new Insert(repository, classDialog);
                }

                return mInserter;
            }
            set
            {
                mInserter = value;
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
            private ClassRepository classRepository;
            public event EventHandler CanExecuteChanged;

            public AnalysisCommand(ClassRepository classRepository)
            {
                this.classRepository = classRepository;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                ClassAnalysisDialog dialog = new ClassAnalysisDialog(classRepository.Analysis());
                dialog.ShowDialog();
            }
        }

        private ICommand mUpdater;
        public ICommand Update
        {
            get
            {
                ClassDialog classDialog = new ClassDialog(repository);
                if (mUpdater == null)
                {
                    mUpdater = new Update(repository, classDialog);
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
