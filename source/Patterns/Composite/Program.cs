using System;
using System.Collections.Generic;

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

    internal abstract class Component
    {
        public string Name {get; set;}

        public Component(string name)
        {
            Name = name;
        }
        
        public abstract void WriteAllNames(int depth=0);

    }

    class Composite : Component
    {
        private List<Component> _children  = new List<Component>();
        public Composite(string name) : base(name) {}
        public Component Add(Component componnet)
        {
            _children.Add(componnet);
            return componnet;
        }

        public void Remove(Component componnet)
        {
            _children.Remove(componnet);
        }

        public override void WriteAllNames(int depth = 0)
        {
            System.Console.WriteLine($"{new string('-', depth)} {Name}");

            var stack = new Queue<Composite>();

            foreach (var child in _children)
            {
                if(child is Leaf) child.WriteAllNames(depth+1);
                else if(child is Composite) stack.Enqueue((Composite) child);
            }

            while (stack.Count>0)
            {
                stack.Dequeue().WriteAllNames(depth+1);
            }
        }
    }

    class Leaf : Component
    {
        public Leaf(string name) : base(name){}
        public override void WriteAllNames(int depth = 0)
        {
            System.Console.WriteLine($"{new string('-', depth )} {Name}");
        }
    }

}
