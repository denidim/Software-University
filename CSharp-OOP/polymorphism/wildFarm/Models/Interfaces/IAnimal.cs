namespace wildFarm.Models.Interfaces
{
    public interface IAnimal
    {
        //ProduseSound()
        //string Name, double Weight, int FoodEaten
        string Name { get; set; }
        double Weight { get; set; }
        int FoodEaten { get; set; }
        //int Count { get; set; }
        public string ProduseSound();
    }
}
