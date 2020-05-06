using System;
using System.Linq;
using StructureMap;

namespace POC.IoCItch.Con01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var container = new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.TheCallingAssembly();

                    x.AddAllTypesOf<IFantasySeries>();

                    // or

                    //x.AddAllTypesOf(typeof(IFantasySeries))
                    //    .NameBy(type => type.Name.ToLower());
                });
            });

            var classNames = container.Model.For<IFantasySeries>()
                .Instances.Select(x => new { TypeName=x.ReturnedType.Name, CustomAttributes=x.ReturnedType.GetCustomAttributes(false)});

        }
    }

    public interface IFantasySeries { }

    [Test(TestName = "Test1")]
    public class WheelOfTime : IFantasySeries { }

    [Test(TestName = "Test2")]
    public class GameOfThrones : IFantasySeries { }

    [Test(TestName = "Test3")]
    public class BlackCompany : IFantasySeries { }

    public class TestAttribute : Attribute
    {
        public string TestName { get; set; }

    }
}
