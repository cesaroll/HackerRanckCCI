using System;
using System.Collections.Generic;

namespace Ces.Collections.Generic {

    /// <summary>
    /// Binary Tree
    /// </summary>
    public class Tree {


        public Node Head {get; set;}

        public int Find_LCA(int a, int b) {

            var node = Find_LCA(Head, a, b);

            return node.Data;

        }

        private Node Find_LCA(Node node, int a, int b) {

            if(node == null)
                return null;

            if(node.Data == a || node.Data == b)
                return node;

            var foundInLeftSide = Find_LCA(node.Left, a, b);
            var foundInRightSide = Find_LCA(node.Right, a, b);

            if(foundInLeftSide != null && foundInRightSide != null)
                return node;

            

        }

        public void PrintInOrder(){
            PrintInOrder(Head);
        }

        private void PrintInOrder(Node node) {
            if(node == null)
                return;
            PrintInOrder(node.Left);
            Console.WriteLine($"{node.Data} ");
            PrintInOrder(node.Right);
        }

        public class Node {
            public int Data {get; set;}
            public Node Left{get; set;}
            public Node Right {get; set;}
            public Node(int data) {
                Data = data;
            }
        }
        

    }

    


}

