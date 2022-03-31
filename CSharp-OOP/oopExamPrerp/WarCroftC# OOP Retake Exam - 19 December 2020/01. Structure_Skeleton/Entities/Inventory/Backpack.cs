using System;
namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int constCapacity = 100;

        public Backpack() : base(constCapacity)
        {
        }
    }
}
