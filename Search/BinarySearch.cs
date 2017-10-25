using System;

namespace Search {

    public class BinarySearch {


        public static bool Search(int[] array, int val) {

            int leftIdx = 0;
            int rightIdx = array.Length - 1;

            while(leftIdx <= rightIdx) {

                int midPointIdx = leftIdx + (rightIdx - leftIdx)/2;

                if(val == array[midPointIdx]) {
                    return true;
                } else if(val < array[midPointIdx]) {
                    rightIdx = midPointIdx - 1;
                } else {
                    leftIdx = midPointIdx + 1;
                }

            }

            return false;

        }

    }

}
