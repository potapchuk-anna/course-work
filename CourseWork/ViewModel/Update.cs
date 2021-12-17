using System;
using CourseWork.Model;
using CourseWork.View;
using System.Windows.Input;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.ViewModel
{
    class Update:ICommand
    {

        private Repository repository;
        private IDialog insertWindow;
        public Update(Repository repository, IDialog insertWindow) { this.repository = repository; this.insertWindow = insertWindow; }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            IDialog dialog = insertWindow.Instance;
            if(parameter is ModelBase model)
            {
                dialog.Set(model);
                dialog.ShowDialog();
                if (dialog.DialogResult == true)
                {
                    repository.Update(model, dialog.GetModel);
                }
            }
        }
    }
}
