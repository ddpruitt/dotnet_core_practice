using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Composite("root");
            var child1 = root.Add(new Composite("Child 1"));
            var child2 = root.Add(new Composite("Child 2"));
            var child3 = root.Add(new Composite("Child 3"));

            for (int i = 0; i < 10; i++)
            {
                ((Composite)child1).Add(new Leaf($"Child 1 Leaf {i:00}"));
            }

            for (int i = 0; i < 5; i++)
            {
                var c2Child = ((Composite)child1).Add(new Composite($"Child 2 Child {i:00}"));
                for (int j = 0; j < 10; j++)
                {
                    ((Composite)c2Child).Add(new Leaf($"{c2Child.Name} Leaf {i:00}"));
                }
            }

            root.WriteAllNames();
        }
    }

}
