using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseWork.Model;
using System.Threading.Tasks;
using System.Windows;
using CourseWork.Model;

namespace CourseWork.View
{
    public interface IDialog
    {
        public ModelBase GetModel { get; }
        public IDialog Instance { get; }
        public bool? ShowDialog();
        public void Set(ModelBase model);
        public bool? DialogResult { get; set; }
    }
}
