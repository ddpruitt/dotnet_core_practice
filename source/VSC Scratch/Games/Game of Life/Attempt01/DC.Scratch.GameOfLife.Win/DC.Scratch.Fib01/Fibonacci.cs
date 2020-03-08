using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DC.Scratch.Fib01
{
    public class Fibonacci
    {
        public Dictionary<ulong, ulong> Cache { get; set; }

        public Fibonacci()
        {
            Cache = new Dictionary<ulong, ulong>();
        }

        public void RunTimedTest(ulong n)
        {
            var timer = new Stopwatch();
            
            timer.Start();
            var results = Calculate(n);
            timer.Stop();

            var elapsedTime = timer.ElapsedMilliseconds;

            timer.Reset();

            timer.Start();
            var resultsSlow = CalculateSlow(n);
            timer.Stop();
            var elapsedTimeSlow = timer.ElapsedMilliseconds;

            var outputTime = string.Format("n = {0}{1}Fibonacci(n) = {2}, Elapsed Time (ms): {3}{1}Slow:{1}Fibonacci(n) = {4}, Elapsed Time (ms): {5}{1}", n, Environment.NewLine, results, elapsedTime, resultsSlow, elapsedTimeSlow);

            Console.WriteLine(outputTime);

        }

        public void RunTimedTest(ulong n, Func<ulong, ulong> calculate)
        {
            var timer = new Stopwatch();
            
            timer.Start();
            var results = calculate(n);
            timer.Stop();

            var elapsedTime = timer.ElapsedMilliseconds;

            var outputTime = string.Format("Fibonacci({0}) = {1}, Elapsed Time (ms): {2}", n, results, elapsedTime);

            Console.WriteLine(outputTime);
        }

        public ulong Calculate(ulong n)
        {
            if (n < 3) return 1;

            if (Cache.ContainsKey(n))
            {
                //Console.WriteLine("Cache Hit {0}", n);
                return Cache[n];
            }

            return Cache[n] = Calculate(n - 1) + Calculate(n - 2);
        }

        public ulong CalculateSlow(ulong n)
        {
            if (n < 3) return 1;

            return CalculateSlow(n - 1) + CalculateSlow(n - 2);
        }
    }
}