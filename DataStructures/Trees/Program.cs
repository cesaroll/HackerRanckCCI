using System;
using System.Collections.Generic;
using System.Linq;

namespace Trees {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello Trees!");
           
            //binarySearchTree();

            //IsBinarySearchTreeTest();

            //NodeDistanceTree_Tests();
    
            //ConvertTreeToDLL(); TODO: Not working yet

        }

        private static void ConvertTreeToDLL(){

            var tree = new Trees.TeeToDLL.Tree();
            var array = new int[] {10, 12, 15, 25, 30, 36};

            foreach(var item in array)
                tree.Insert(item);

            Trees.TeeToDLL.Node root = tree.ConvertToDLL();

            while(root != null) {
                Console.Write($"{root.Data} ");
                root = root.Right;
            }

        }


        /// Test Tree Node Distance
        private static void NodeDistanceTree_Tests() {

            Trees.Binary.NodeDistance.Tree tree = new Trees.Binary.NodeDistance.Tree();

            //Test Insert
            Insert_NodeDistanceTree(tree);

            //Test InOrder

            Console.WriteLine("Traversing");
            var list = tree.InOrderTraverse();
            Console.WriteLine(string.Join(" ", list.Select(x => x.ToString())));

            //Test Node Exist
            Console.WriteLine("Node 7 Exist: " + tree.NodeExist(7));
            Console.WriteLine("Node 16 Exist: " + tree.NodeExist(16));

            //Test Node Distance
            Console.WriteLine("testing Distances");
            var distance = tree.DistanceBetweenNodes(2, 6);
            Console.WriteLine("Distance between 2 and 6: " + distance);

            distance = tree.DistanceBetweenNodes(13, 3);
            Console.WriteLine("Distance between 13 and 3: " + distance);

            distance = tree.DistanceBetweenNodes(3, 10);
            Console.WriteLine("Distance between 3 and 10: " + distance);

            distance = tree.DistanceBetweenNodes(3, 4);
            Console.WriteLine("Distance between 3 and 4: " + distance);

            distance = tree.DistanceBetweenNodes(4, 4);
            Console.WriteLine("Distance between 4 and 4: " + distance);

        }

        private static void Insert_NodeDistanceTree(Trees.Binary.NodeDistance.Tree tree) {

            //Test Insert
            Console.WriteLine("Inserting");
            tree.Insert(8);
            tree.Insert(4);
            tree.Insert(12);
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(10);
            tree.Insert(14);

            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(11);
            tree.Insert(15);
            tree.Insert(13);
            tree.Insert(7);
            tree.Insert(5);


        }


        private static void IsBinarySearchTreeTest() {

            var logic = new SimpleLogic<int>();

            Console.WriteLine();
            var isBST = logic.IsBinarySearchTree(SimpleBalancedTree());
            Console.WriteLine($"\nIs Binary Search Tree? : [{isBST}]");

            Console.WriteLine();
            isBST = logic.IsBinarySearchTree(SimpleUnBalancedTree());
            Console.WriteLine($"\nIs Binary Search Tree? : [{isBST}]");
            

        }
        
        private static SimpleNode<int> SimpleUnBalancedTree() {

            var root = new SimpleNode<int>(3);
            root.Left = new SimpleNode<int>(2);
            root.Right = new SimpleNode<int>(6);
            root.Left.Left = new SimpleNode<int>(1);
            root.Left.Right = new SimpleNode<int>(4);
            root.Right.Left = new SimpleNode<int>(5);
            root.Right.Right = new SimpleNode<int>(7);

            return root;
        }

        private static SimpleNode<int> SimpleBalancedTree() {

            var root = new SimpleNode<int>(4);
            root.Left = new SimpleNode<int>(2);
            root.Right = new SimpleNode<int>(6);
            root.Left.Left = new SimpleNode<int>(1);
            root.Left.Right = new SimpleNode<int>(3);
            root.Right.Left = new SimpleNode<int>(5);
            root.Right.Right = new SimpleNode<int>(7);

            return root;
        }


        private static void binarySearchTree() {
            var node = new Node(10);
 
            node.insert(5);
            node.insert(15);
            node.insert(8);

            Console.WriteLine($"Contains '8'?: [{node.contains(8)}]");

            Console.WriteLine($"  InOrder: {node.printInOrder()}");
            Console.WriteLine($" PreOrder: {node.printPreOrder()}");
            Console.WriteLine($"PostOrder: {node.printPostOrder()}");
        }
    }

}
