using System;

namespace Memoization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Memoization!");

            var array = new bool[,] {{true, false, true},
                                    {true, true, true},
                                    {false, true, true}};

            Console.WriteLine(AllPosiblePaths.GetAllPosiblePaths(array));

        }
    }
}
