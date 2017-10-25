using System;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sorted array to be search!");

            var array = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            Console.WriteLine("Enter value to search.");
            var value = int.Parse(Console.ReadLine());

            var isFound = BinarySearch.Search(array, value);

            Console.WriteLine($"Found: [{isFound}]");

        }
    }
}
