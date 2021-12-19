using System;
using System.Collections.Generic;
using System.Text;
using CourseWork.Model;
using CourseWork.View;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace CourseWork.ViewModel
{
    class Generate : ICommand
    {
        private Repository repository;
        public Generate(Repository repository) { this.repository = repository; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        private int ParseNumber(string num)
        {
            return int.TryParse(num, out int number) ? number : 0;
        }
        public void Execute(object parameter)
        {
            try
            {
                GenerateWindow generateWindow = new GenerateWindow();
                generateWindow.ShowDialog();
                repository.DataGeneration(ParseNumber(generateWindow.Number));
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error. {ex.Message}");
            }
        }
    }
}
