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

namespace CourseWork.ViewModel
{
    class Insert:ICommand
    {
        private Repository repository;
        private IDialog insertWindow;
        public Insert(Repository repository, IDialog insertWindow) { this.repository = repository;  this.insertWindow = insertWindow; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            IDialog dialog = insertWindow.Instance;
            dialog.ShowDialog(); 
            if(dialog.DialogResult==true)
            {
                repository.Insert(dialog.GetModel);
            }
            
        }
    }
}
