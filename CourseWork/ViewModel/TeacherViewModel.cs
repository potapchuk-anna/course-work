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
            repository.context.Teachers.Load();
            _teachersList = repository.context.Teachers.Local.ToObservableCollection();
            this.repository = repository;
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
                if (mInserter == null)
                {
                    mInserter = new Insert(repository); 
                }

                return mInserter;
            }
            set
            {
                mInserter = value;
            }
        }
        private ICommand mGenerater;

        private int ParseNumber(string num)
        {
            return int.TryParse(num, out int number) ? number : 0;
        }
        public ICommand Generate
        {
            get
            {
                TeacherPage teacherPage = new TeacherPage();
                if (mGenerater == null&&teacherPage.isGenerationClicked)
                {
                    GenerateWindow generateWindow = new GenerateWindow();
                    generateWindow.ShowDialog();
                    mGenerater = new Generate(repository,ParseNumber(generateWindow.Number));
                }

                return mGenerater;
            }
            set
            {
                mGenerater = value;
            }
        }
    }
}
