namespace Composite
{
    class Leaf : Component
    {
        public Leaf(string name) : base(name){}
        public override void WriteAllNames(int depth = 0)
        {
            System.Console.WriteLine($"{new string('-', depth )} {Name}");
        }
    }

}
