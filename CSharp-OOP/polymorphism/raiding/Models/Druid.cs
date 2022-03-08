namespace raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
        }

        public override int Power => 80;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
