using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ReverseArray {
    class Program {
        static void Main (string[] args) {
            //RunAllArrayReverserExamples ();

            //RunAllLinqQuestionExamples ();

            RunAllStringExamples ();
        }

        private static void RunAllArrayReverserExamples () {
            Console.WriteLine ("Examples of Reversing an Array");

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

        }

        private static void RunAllLinqQuestionExamples () {

            Console.WriteLine ("Linq Examples");

            WriteOutResults ("LinqQuestion01", LinqExamples.LinqQuestion01 ());
        }

        private static void RunAllStringExamples () {
            Console.WriteLine ("Examples of Reversing a String");

            var stringReverser = new ReverseStrings ();

            WriteOutStringExample (nameof (stringReverser.Reverse01), "This Is A Normal String", stringReverser.Reverse01);

            WriteOutStringExample (nameof (stringReverser.Reverse02), "This Is A Normal String", stringReverser.Reverse02);
        }
        private static void WriteOutStringExample (string resultName, string toReverse, Func<string, string> reverser) {
            System.Console.WriteLine ($"-> {resultName}\n\t- Input: {toReverse}\n\t- Output: {reverser(toReverse)}");
            System.Console.WriteLine ();
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