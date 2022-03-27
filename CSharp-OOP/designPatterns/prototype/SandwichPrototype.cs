namespace prototype
{
    public abstract class SandwichPrototype
    {
        public abstract SandwichPrototype ShallowCopy();
        public abstract SandwichPrototype DeepCopy();
    }
}
