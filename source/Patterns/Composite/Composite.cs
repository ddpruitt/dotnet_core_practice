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

            foreach (var child in _children)
            {
                child.WriteAllNames(depth + 1);
            }
        }
    }

}
