namespace wildFarm.Models
{
using wildFarm.Models.Interfaces;

    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; set; }
    }
}
