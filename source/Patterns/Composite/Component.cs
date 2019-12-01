namespace Composite
{
    internal abstract class Component
    {
        public string Name {get; set;}

        public Component(string name)
        {
            Name = name;
        }
        
        public abstract void WriteAllNames(int depth=0);

    }

}
