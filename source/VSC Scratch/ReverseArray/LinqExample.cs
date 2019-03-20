using System.Collections.Generic;
using System.Linq;

namespace ReverseArray {
    public static class LinqExamples {
        /*
        LINQ:

            var a = int[] with the numbers 1 to 100

            Write a linq statement to
            1. Skip the first 25 numbers,
            2. Take the next 10 numbers,
            3. Multiply these numbers by 3,
            4. Return it as a List of Integers.

        
         */
        public static IList<int> LinqQuestion01 () 
        {
            var a = Enumerable.Range(1, 100);

            var results = a
                            .Skip(25)
                            .Take(10)
                            .Select(i=>i*3)
                            .ToList();
            
            return results;
        }
    }

}