using System;

namespace Sorting {

    public class BubbleSort {

        public static void Sort(int[] array) {
            
            bool IsSorted = false;
            int lastIndex = array.Length-1;

            while(!IsSorted) {
                IsSorted = true;

                for(int i=0; i<lastIndex; i++) {
                
                    if(array[i] > array[i+1]) {
                        Util.Swap(array, i, i+1);

                        IsSorted = false;
                    }

                }

                lastIndex--;

            }

        }

    }

}
