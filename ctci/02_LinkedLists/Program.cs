using System;

namespace _02_LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Linked Lists!\n");

            var p = new Program();
            p.IsPalindrome();

        }


        void IsPalindrome() {

            //Create List
            Node head = new Node('a');
            head.Next = new Node('b');
            head.Next.Next = new Node('c');
            head.Next.Next.Next = new Node('b');
            head.Next.Next.Next.Next = new Node('a');

            Node dummy = null;

            Console.WriteLine($"Is palindrome: {IsPalindrome(head, ref dummy, head)}");

        }

        /// <summary>
        /// Fins if Linked list in Palindrome using recursion
        /// </summary>
        /// <returns></returns>
        bool IsPalindrome(Node bNode, ref Node eNode, Node runner) {

            char bVal;
            char eVal;

            if(runner == null)
                return false;

            // If runner.Next == null then it is odd
            if(runner.Next == null) {
                eNode = bNode.Next;
                Print("Odd" ,bNode, eNode, runner);
                return true;
            }

            //If in the middle, compare and return
            if(runner.Next.Next == null) {
                bVal = bNode.Data;
                eVal = bNode.Next.Data;

                eNode = bNode.Next.Next;
                Print("Middle" ,bNode, eNode, runner);
                return bVal == eVal;
                
            }

            //Recursion
            if(!IsPalindrome(bNode.Next, ref eNode, runner.Next.Next)) {
                Print("Not pal returned" ,bNode, eNode, runner);
                return false;
            }

            Print("Comparison" ,bNode, eNode, runner);

            bVal = bNode.Data;
            eVal = eNode.Data;
            eNode = eNode.Next;
            return  bVal == eVal;


        } 

        void Print(string msg, Node bn, Node en, Node r) {
            Console.WriteLine($"{msg} bNode: {bn.Data} eNode: {en.Data} runner: {r.Data}");
        }

        class Node {
            public char Data;
            public Node Next;

            public Node(char data) {
                Data = data;
            }

        }

    }
}
