using System;

namespace CustomDoublyLinkedList//customList
{
    public class List<T>
    {
        private const int DefaultCapacity = 2;

        private T[] items;

        public List()
        {
            items = new T[DefaultCapacity];
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count++] = element;
        }

        public T RemoveAt(int index)
        {
            IsInRange(index);

            T result = items[index];

            items[index] = default;
            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }
            Count--;
            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return result;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 && firstIndex >= Count && secondIndex < 0 && secondIndex >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                T firs = items[firstIndex];
                T second = items[secondIndex];
                items[firstIndex] = second;
                items[secondIndex] = firs;
            }
        }

        public T this[int i]
        {
            get
            {
                IsInRange(i);
                return items[i];
            }
            set
            {
                IsInRange(i);
                items[i] = value;
            }
        }

        private void Shrink()
        {

            T[] tempArray = new T[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                tempArray[i] = items[i];
            }

            items = tempArray;
        }

        private void Resize()
        {
            T[] tempArray = new T[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                tempArray[i] = items[i];
            }

            items = tempArray;
        }

        private void IsInRange(int i)
        {
            if (i < 0 || i >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

    }
}
