using System;
using System.Collections.Generic;
using System.Linq;

namespace GetMax3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Get max 3!");

            var array = new int[] {45, 67, 89, 90, 3, 4, 1, 23, 32, 56, 789, 098, 89, 76, 54, 32, 12, 23, 1493, 3, 1, 67};

            Console.WriteLine(string.Join(" ",array.OrderByDescending(x => x).Take(3).Select(x => x.ToString())) );

        }
    }

    class MaxHeap {

        

        class Node {
            public int Data;
            public Node Left;
            public Node Right;

            public Node(int data) {
                Data = data;
            }
        }

    }
}
