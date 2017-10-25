using System;
using System.Linq;

namespace Sorting {
    public static class Util {

        public static void Swap(int[] array, int idx1, int idx2) {

            int tmp = array[idx1];
            array[idx1] = array[idx2];
            array[idx2] = tmp;
        }

        public static void PrintArray(string msg, int[] array) {
            Console.WriteLine($"\n{msg} : {string.Join(" ", array.Select(x => x.ToString()))}\n");
        }

    }

}