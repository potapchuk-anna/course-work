using System;
using System.Collections.Generic;
using System.Text;
using CourseWork.Model;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.ViewModel
{
    class Remove : ICommand
    {
        private Repository repository;
        public Remove(Repository repository) { this.repository = repository; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ModelBase model)
            {
                repository.Delete(model);
            }
        }
    }

}
