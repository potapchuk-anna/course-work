using CourseWork.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork.ViewModel
{
    public class Search
    {
        private Repository repository;
        private string word;

        public string Word
        {
            get
            {
                return word;
            }
            set
            {
                word = value;
            }
        }
        public Search(Repository repository) { this.repository = repository; }
      
        public ObservableCollection<ModelBase> Execute(object parameter)
        {
            word = parameter.ToString();
            return repository.Find(word);
        }

      

    }
}
