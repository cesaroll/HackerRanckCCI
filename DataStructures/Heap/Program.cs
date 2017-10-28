using System;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Heaps!\n");


            TestMinHeap();

        }

        static void TestMinHeap() {

            Random rnd = new Random();

            var minHeap = new Ces.Collections.Heaps.MinHeap();

            for(int i=1; i<=10; i++) {
                minHeap.Push(rnd.Next(1,100));
            }

            while(minHeap.Lenght > 0) {
                Console.Write(minHeap.Pop() + " ");
            }

            Console.WriteLine();


        }
    }
}
