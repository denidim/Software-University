using System.Collections.Generic;

namespace component
{
    public class CompositeGift : GiftBase, IGiftOperations
    {

        private readonly HashSet<GiftBase> giftBases;

        public CompositeGift(string name, int price) : base(name, price)
        {
            this.giftBases = new HashSet<GiftBase>();
        }

        public void Add(GiftBase gift) => giftBases.Add(gift);

        public override decimal CalculateTotalPrice()
        {
            decimal sum = 0;

            foreach (var item in giftBases)
            {
                sum += item.CalculateTotalPrice();
            }

            return sum;

        }

        public void Remove(GiftBase gift) => giftBases.Remove(gift);
    }
}
