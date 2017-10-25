using System;

namespace Sorting {

    public class MergeSort {

        public static void Sort(int[] array) {
            Sort(array, new int[array.Length], 0, array.Length-1);
        }

        private static void Sort(int[] array, int[] temp, int leftStartIdx, int rightEndIdx) {

            if(leftStartIdx >= rightEndIdx) return;

            int leftEndIdx = leftStartIdx + (rightEndIdx - leftStartIdx)/2;
            int rightStartIdx = leftEndIdx + 1;

            Sort(array, temp, leftStartIdx, leftEndIdx);
            Sort(array, temp, rightStartIdx, rightEndIdx);

            Merge(array, temp, leftStartIdx, leftEndIdx, rightStartIdx, rightEndIdx);

        }

        private static void  Merge(int[] array, int[] temp, int leftStartIdx, int leftEndIdx, int rightStartIdx, int rightEndIdx) {

            int leftPos = leftStartIdx;
            int rightPos = rightStartIdx;

            int tempIdx = leftStartIdx;

            while(leftPos <= leftEndIdx && rightPos <= rightEndIdx) {

                if(array[leftPos] <= array[rightPos])
                    temp[tempIdx++] = array[leftPos++];
                else 
                    temp[tempIdx++] = array[rightPos++];

            }


            // Copy what is left behind into temp, only one or the other will copy something
            ArrayCopy(array, leftPos, temp, tempIdx, leftEndIdx - leftPos + 1);
            ArrayCopy(array, rightPos, temp, tempIdx, rightEndIdx - rightPos + 1);

            //Copy back temp into array
            ArrayCopy(temp, leftStartIdx, array, leftStartIdx, rightEndIdx - leftStartIdx + 1);

        }

        private static void ArrayCopy(int[] source, int sourceIdx, int[] dest, int destIdx, int count) {

            while(count > 0) {

                dest[destIdx++] = source[sourceIdx++];

                count--;
            }

        }

    }

}