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
    class WorkViewModel
    {
        private WorkRepository repository;

        private ObservableCollection<Work> _worksList;

        public WorkViewModel(WorkRepository repository)
        {
            repository.context.Works.Include(s => s.Subject);
            _worksList = repository.context.Works.Local.ToObservableCollection();
            this.repository = repository;
        }
        public ObservableCollection<Work> WorkList
        {
            get
            {
                repository.context.Works.Load();
                return repository.context.Works.Local.ToObservableCollection();
            }
        }

        public ObservableCollection<Work> Works
        {
            get { return _worksList; }
            set { _worksList = value; }
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
                WorkDialog workDialog = new WorkDialog(repository);
                if (mInserter == null)
                {
                    mInserter = new Insert(repository, workDialog);
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
                WorkDialog workDialog = new WorkDialog(repository);
                if (mUpdater == null)
                {
                    mUpdater = new Update(repository, workDialog);
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
