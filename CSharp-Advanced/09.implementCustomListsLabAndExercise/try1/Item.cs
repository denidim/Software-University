namespace try1
{

    public class Item<T>
    {
        public Item<T> Previous { get; set; }
        public Item<T> Next { get; set; }
        public T Value { get; set; }

        public Item(T value)
        {
            Value = value;
        }

    }
}
