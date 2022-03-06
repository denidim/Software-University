using System;
using collectionHierarchy.Interfaces;

namespace collectionHierarchy.Models
{
    public class MyList<T> : AddRemoveCollection<T>, IMyList
    {
        public int Used => collection.Count;

        public override int Add(T element)
        {
            return base.Add(element);
        }

        public override T Remove()
        {
            T curr = collection[constant];

            collection.RemoveAt(constant);

            return curr;
        }
    }
}
