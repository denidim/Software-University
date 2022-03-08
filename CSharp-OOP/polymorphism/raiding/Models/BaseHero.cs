namespace raiding.Models
{
    public abstract class BaseHero:ICastable
    {
        private string name;
        private int power;

        protected BaseHero(string name)
        {
            Name = name;
            Power = power;
        }

        public string Name { get => name; private set => name = value; }
        public virtual int Power { get => power; private set => power = value; }

        public abstract string CastAbility();
            
    }
}
