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
    class Generate : ICommand
    {
        private Repository repository;
        private int number;
        public Generate(Repository repository, int number) { this.repository = repository; this.number = number; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {            
            repository.DataGeneration(number);
        }
    }
}
