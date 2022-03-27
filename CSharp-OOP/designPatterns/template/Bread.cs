namespace template
{
    public abstract class Bread
    {
        public abstract void MixIngredient();

        public abstract void Bakе();

        public virtual void Slice()
        {
            System.Console.WriteLine("Slicing the "+ GetType().Name+" bread!");
        }

        public void Make()
        {
            MixIngredient();
            Bakе();
            Slice();
        }


    }
}
