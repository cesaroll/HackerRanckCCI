using System;
using Ces.Collections.Generic;

namespace LowestCommonAncestor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Tree, Find distance between nodes using Lowest Common Ancestor\n");

            FindLCA_Method1();

        }

        private static void FindLCA_Method1() {

            var tree = new Tree();

            tree.Head = new Tree.Node(1);
            tree.Head.Left = new Tree.Node(2);
            tree.Head.Right = new Tree.Node(3);
            tree.Head.Left.Left = new Tree.Node(4);
            tree.Head.Left.Right = new Tree.Node(5);
            tree.Head.Right.Left = new Tree.Node(6);
            tree.Head.Right.Right = new Tree.Node(7);

            //tree.PrintInOrder();

            Console.WriteLine(tree.Find_LCA(4, 5));


        }
    
    }

}
