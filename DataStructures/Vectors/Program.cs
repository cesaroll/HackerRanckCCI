using System;

namespace Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nVectors!\n");

            var a = Console.ReadLine();
            var b = Console.ReadLine();

            var vector = new Vector(26);

            foreach(var c in a) {  vector.Increase(c - 'a'); }

            foreach(var c in b) { vector.Decrease(c - 'a'); }

            int count = 0;
            foreach(int value in vector) { count += Math.Abs(value);}

            Console.WriteLine(count);

        }
    }
}
