using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ReverseArray {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Examples of Reversing and Array");

            //  void _<T> (Func<IEnumerable<T>, IEnumerable<T>> reverseFunction, string name) {
            //      var array = Enumerable.Range (1, 11);

            //      System.Console.WriteLine (name);
            //      System.Console.Write (@"{ ");
            //      System.Console.Write (
            //          string.Join (", ",
            //              reverseFunction (array).Select (a => a.ToString ())
            //          ));
            //      System.Console.WriteLine (@" }");
            //  }

            var arrayReverser = new ArrayReverser<int> ();

            WriteOutResults ("Initial Array", Enumerable.Range (1, 11));
            WriteOutResults ("Reverser01", arrayReverser.Reverse01 (Enumerable.Range (1, 11).ToList<int> ()));
            WriteOutResults ("Reverser02", arrayReverser.Reverse02 (Enumerable.Range (1, 11).ToList<int> ()));
            WriteOutResults ("Reverser03", arrayReverser.Reverse03 (Enumerable.Range (1, 11).ToList<int> ()));
            WriteOutResults ("Reverser04", arrayReverser.Reverse04 (Enumerable.Range (1, 11).ToArray<int> ()));

            // Arrays are passed by reference so the orginal array is updated.
            var orginalArray = Enumerable.Range (1, 11).ToArray<int> ();
            WriteOutResults ("Reverser05 - orginalArray (before update)", orginalArray);

            var updatedArray = arrayReverser.Reverse05 (orginalArray);
            WriteOutResults ("Reverser05 - updatedArray\t\t", updatedArray);
            WriteOutResults ("Reverser05 - orginalArray (after update)", orginalArray);

            WriteOutResults ("Reverser06", arrayReverser.Reverse06 (Enumerable.Range (1, 11).ToArray<int> ()));
            WriteOutResults ("Reverser07", arrayReverser.Reverse07 (Enumerable.Range (1, 11).ToArray<int> ()));
            WriteOutResults ("Reverser08", arrayReverser.Reverse08 (Enumerable.Range (1, 11).ToArray<int> ()));

            WriteOutResults ("LinqQuestion01", LinqExamples.LinqQuestion01 ());

        }

        private static void WriteOutResults<T> (string resultName, IEnumerable<T> results) {

            System.Console.Write (resultName);
            System.Console.Write ("\t");
            System.Console.Write (@"{ ");
            System.Console.Write (
                string.Join (", ", results.Select (a => a.ToString ())));
            System.Console.WriteLine (@" }");
            System.Console.WriteLine ();
        }
    }
}