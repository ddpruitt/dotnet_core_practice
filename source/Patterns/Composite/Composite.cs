using System.Collections.Generic;

namespace Composite
{
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

}
