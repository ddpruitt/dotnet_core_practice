using System;

namespace DC.Scratch.Fib01
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 n = 40;
            var fib = new Fibonacci();
            //fib.RunTimedTest(n);

            for (ulong i = 0; i <= 10000; i++)
            {
                fib.RunTimedTest(i, fib.Calculate);
            }

            Console.ReadLine();
        }
    }
}
