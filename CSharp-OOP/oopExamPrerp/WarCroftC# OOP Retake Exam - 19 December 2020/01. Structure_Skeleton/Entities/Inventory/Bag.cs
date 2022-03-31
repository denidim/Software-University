using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;

        protected Bag(int capacity) 
        {
            this.Capacity = capacity;
            items = new List<Item>();
        }

        public IReadOnlyCollection<Item> Items => items;

        public int Capacity { get; set; } = 100;

        public int Load => items.Sum(x => x.Weight);

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidCastException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {

            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item curr = items.FirstOrDefault(x => x.GetType().Name == name);

            if (curr == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            items.Remove(curr);

            return curr;
        }
    }
}
