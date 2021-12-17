using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CourseWork.Model
{
    public abstract class Repository
    {
        public string Name { get; }

        public EducationalSystemContext context;
        public Repository(EducationalSystemContext context)
        {
            this.context = context;
        }
        abstract public void Insert(ModelBase model);
        abstract public void Delete(ModelBase model);
        abstract public void Update(ModelBase model, ModelBase newModel);
        abstract public void DataGeneration(int numberOfData);
        abstract public ObservableCollection<ModelBase> Find(string parametr);
    }
}
