using System;
using System.Linq;

namespace ProjectEulerSolutions
{
    public class Problem01
    {
        /*
            If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

            Find the sum of all the multiples of 3 or 5 below 1000.
         */

        public int FindAnswer()
        {
            var result = Enumerable.Range(0, 1000)
                .Where(r => r % 3 == 0 || r % 5 == 0)
                .Sum();

            return result;
        }
    }
}