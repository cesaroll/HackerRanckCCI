using System;
using System.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Sort Type! \n1. BubbleSort\n2. QuickSort\n3. MergeSort.\n");

            int sortType = int.Parse(Console.ReadLine());

            string[] a_temp = Console.ReadLine().Split(' ');
            int[] array = Array.ConvertAll(a_temp,Int32.Parse);

            //var array = new int[] {10,6,8,9,3,2};
            Util.PrintArray("Unsorted", array);

            switch(sortType) {
                case 1:
                    Console.WriteLine("BubbleSort.");
                    BubbleSort.Sort(array);
                    break;
                case 2:
                    Console.WriteLine("QuickSort.");
                    QuickSort.Sort(array);
                    break;
                case 3:
                    Console.WriteLine("MergeSort.");
                    MergeSort.Sort(array);
                    break;
            }
            
            Util.PrintArray("  Sorted", array);
        }
    }
}
