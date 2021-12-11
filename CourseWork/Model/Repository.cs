using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork.Model
{
    abstract class Repository
    {
        public string Name { get; }

        public EducationalSystemContext context;
        public Repository(EducationalSystemContext context)
        {
            this.context = context;
        }
        abstract public void Insert(ModelBase model);
        abstract public void Delete(ModelBase model);
        abstract public void Update(ModelBase model);
        abstract public void DataGeneration(int numberOfData);
        //abstract public ModelBase Find<T>(string coloumn, T parametr);
    }
}
