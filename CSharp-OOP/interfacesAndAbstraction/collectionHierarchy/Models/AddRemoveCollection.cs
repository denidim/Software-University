using System.Linq;
using System.Reflection.Metadata;
using collectionHierarchy.Interfaces;

namespace collectionHierarchy.Models
{
    public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
    {
        protected const int constant = 0;

        public override int Add(T element)
        {
            collection.Insert(constant, element);
            return constant;
        }

        public virtual T Remove()
        {
            T curr = collection[collection.Count - 1];

            collection.RemoveAt(collection.Count - 1);

            return curr;
        }
    }
}
