using System;

namespace try1
{
    public class CustomList<T>
    {
        private Item<T> first = null;
        private Item<T> last = null;

        //Read-only property (get only)
        public int Count
        {
            get

            {
                var count = 0;
                //ToDo count elements
                var curr = first;
                while (curr != null)
                {
                    count++;
                    curr = curr.Next;
                }
                return count;
            }
        }
        //recursive count
        //int GetCount(Item<T> curr) -> GetCount(first)
        //{
        //    if (curr == null)
        //    {
        //        return 0;
        //    }

        //    return 1 + GetCount(curr.Next);
        //}

        public void AddFirst(T element)
        {
            var item = new Item<T>(element);

            if (first == null)
            {
                first = item; 
                last = item;
            }
            else
            {
                item.Next = first;  
                first.Previous = first;
                first = item;
            }
        }

        public void AddLast(T element)
        {
            var item = new Item<T>(element);

            if (last == null)
            {
                last = item;
                first = item;
            }
            else
            {
                last.Next = item;
                item.Previous = last;
                last = item;
            }
        }

        public T RemoveFirst()
        {
            //ToDo Throw  Exeption (error)
            if (first == null)
            {
                throw new InvalidOperationException("Linked list empty!");
            }
            var curr = first.Value;
            if (first == last)
            {
                first = null;
                last = null;
            }
            else
            {
                var newFirst = first.Next;
                newFirst.Previous = null;
                first = newFirst;
            }
            return curr;
        }

        public T RemoveLast()
        {
            //ToDo Throw  Exeption (error)
            if (last == null)
            {
                throw new InvalidOperationException("Linked list empty!");
            }
            var curr = last.Value;
            if (first == last)
            {
                first = null;
                last = null;
            }
            else
            {
                var newLast = last.Previous;
                newLast.Next = null;
                last = newLast;
            }
            return curr;
        }

        public void ForEach(Action<T> action)
        {
            var curr = first;
            while (curr!=null)
            {
                action(curr.Value);
                curr = curr.Next;
            }
        }

        public T[] ToArray()
        {
            var array = new T[Count];
            var curr = first;
            var index = 0;
            while (curr!=null)
            {
                array[index]= curr.Value;
                curr = curr.Next;
                index++;
            }
            return array;
        }
    }
}
