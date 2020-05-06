using System;
using System.Linq;
using StructureMap;

namespace POC.IoCItch.Con01
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Func<Type, string> nameOfInstance = instanceType =>
                {
                    var customAttributes = instanceType
                        .GetCustomAttributes(typeof(MathAttribute), false)
                        .Cast<MathAttribute>();

                    if (customAttributes.Any()) return customAttributes.First().ActionName;

                    if (instanceType.Name.EndsWith("Numbers")) return instanceType.Name.Replace("Numbers", "");
                
                    return instanceType.Name;
                };

                var container = new Container(_ =>
                {
                    // Automatically add all concrete classes of type IMathWorks to the container.
                    // If the class has a MathAttribute the use the ActionName for the class Name.
                    // If the class does not have the MathAttribute then remove the string "Numbers" from the class Name.
                    // Otherwise just use the Name.
                    _.Scan(x =>
                    {
                        x.TheCallingAssembly();
                        x.AddAllTypesOf<IMathWorks>()
                            .NameBy(name=> nameOfInstance(name));
                    });
                });

                // Get an instance of a given IMathWorks using either the Math.ActionName or the class name (without "Numbers")
                Console.WriteLine($"1 + 1 = {container.GetInstance<IMathWorks>("Add").Function(1, 1)}");
                Console.WriteLine($"5 - 3 = {container.GetInstance<IMathWorks>("Subtract").Function(5, 3)}");
                Console.WriteLine($"5 * 3 = {container.GetInstance<IMathWorks>("Multiply").Function(5, 3)}");
                Console.WriteLine($"15 / 3 = {container.GetInstance<IMathWorks>("Divide").Function(15, 3)}");
                
                Console.WriteLine();
                
                Console.WriteLine($"Polar Radius of (3,4) = {container.GetInstance<IMathWorks>("PolarCoordinateRadius").Function(3, 4)}");
                Console.WriteLine($"Polar Angle of (3,4)  = {container.GetInstance<IMathWorks>("PolarCoordinateAngle").Function(3, 4)}");
            
            
                // If the container cannot resolve an Instance for a given Name then an exception is thrown.
                Console.WriteLine($"This Should Fail {container.GetInstance<IMathWorks>("I Don't Really Exist").Function(3, 4)}");
            }
            catch (StructureMapException sme)
            {
                Console.WriteLine("");
                Console.WriteLine(sme.ToString());
            }

            Console.Read();
        }
    }

    public class MathAttribute : Attribute 
    {
        public string ActionName { get; private set; }

        public MathAttribute(string actionName)
        {
            ActionName = actionName;
        }
    }

    public interface IMathWorks
    {
        double Function(double x, double y);
    }

    [Math("Add")]
    public class AddNumbers : IMathWorks
    {
        public double Function(double x, double y) => x + y;
    }

    [Math("Subtract")]
    public class SubtractNumbers : IMathWorks
    {
        public double Function(double x, double y) => x - y;
    }

    [Math("Multiply")]
    public class MultiplyNumbers : IMathWorks
    {
        public double Function(double x, double y) => x * y;
    }
    
    [Math("Divide")]
    public class DivideNumbers : IMathWorks
    {
        public double Function(double x, double y) => y==0 ? double.NaN : x / y;
    }

    public class PolarCoordinateRadiusNumbers : IMathWorks
    {
        public double Function(double x, double y) =>  Math.Sqrt(x*x + y*y);
    }
    
    public class PolarCoordinateAngleNumbers : IMathWorks
    {
        public double Function(double x, double y) =>  x==0 ? double.NaN : Math.Atan(y/x);
    }

}
