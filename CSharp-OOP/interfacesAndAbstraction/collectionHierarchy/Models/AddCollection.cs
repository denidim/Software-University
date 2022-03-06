using System.Collections.Generic;
using collectionHierarchy.Interfaces;

namespace collectionHierarchy.Models
{
    public class AddCollection<T> : IAddCollection<T>
    {
        protected List<T> collection;

        public AddCollection()
        {
            collection = new List<T>();
        }


        public virtual int Add(T element)
        {
            collection.Add(element);
            return collection.Count - 1;
        }
    }
}
