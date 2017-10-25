using System;

namespace Sorting {

    public class QuickSort {

        public static void Sort(int[] array) {

            Sort(array, 0, array.Length-1);

        }

        private static void Sort(int[] array, int leftIdx, int rightIdx) {

            if(leftIdx >= rightIdx)
                return;

            int pivotIdx = leftIdx + (rightIdx - leftIdx) / 2;
            int pivotVal = array[pivotIdx];

            //Util.PrintArray(string.Format("pivotVal: {0}, leftIdx: {1}, rightIdx: {2}", pivotVal, leftIdx, rightIdx), array);
            //Console.ReadLine();
            int middleIdx = SortAndPartition(array, leftIdx, rightIdx, pivotVal);

            Sort(array, leftIdx, middleIdx-1);
            Sort(array, middleIdx, rightIdx);

        }

        private static int SortAndPartition(int[] array, int leftIdx, int rightIdx, int pivotVal) {

            while(leftIdx <= rightIdx) {

                while(array[leftIdx] < pivotVal)
                    leftIdx++;

                while(array[rightIdx] > pivotVal)
                    rightIdx--;

                if(leftIdx <= rightIdx) {
                    Util.Swap(array, leftIdx, rightIdx);
                    leftIdx++;
                    rightIdx--;
                }

            }

            return leftIdx;

        }

    }

}