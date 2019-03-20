using System.Collections.Generic;
using System.Linq;

namespace ReverseArray {

    public class ArrayReverser<T> {
        // this modifies the orginal array.
        public IEnumerable<T> Reverse01 (IEnumerable<T> array) {
            return array.Reverse ();
        }

        // this modifies the orginal array.
        public IList<T> Reverse02 (IList<T> array) {

            int count = array.Count;
            int countMinusOne = count - 1;
            for (int i = 0; i < count / 2; i++) {
                var tmp = array[i];
                array[i] = array[countMinusOne - i];
                array[countMinusOne - i] = tmp;
            }

            return array;
        }

        // this modifies the orginal array.
        public IList<T> Reverse03 (IList<T> array) {
            return array.Reverse ().ToList ();
        }

        public int[] Reverse04 (int[] array) {

            int count = array.Length;
            var newArray = new int[count];

            for (int i = 0, j = count - 1; i < count; i++, j--) {
                newArray[i] = array[j];
            }

            return newArray;
        }
        // this modifies the orginal array.
        public int[] Reverse05 (int[] array) {

            int count = array.Length;
            int countMinusOne = count - 1;
            for (int i = 0; i < count / 2; i++) {
                var tmp = array[i];
                array[i] = array[countMinusOne - i];
                array[countMinusOne - i] = tmp;
            }

            return array;
        }

        public int[] Reverse06 (int[] array) {
            var i = 0;
            var j = array.Length - 1;
            var newArray = new int[array.Length];

            while (j >= 0) {
                newArray[i++] = array[j--];
            }

            return newArray;
        }

        // this modifies the orginal array.
        public int[] Reverse07 (int[] array) {
            var i = 0;
            var j = array.Length - 1;

            while (j > i) {
                var tmp = array[i];
                array[i] = array[j];
                array[j] = tmp;
                i++;
                j--;
            }

            return array;
        }

        public int[] Reverse08 (int[] array) {
            return new Stack<int> (array).ToArray ();
        }
    }
}