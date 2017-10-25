using System;
using System.Collections.Generic;

namespace Trees.Binary.NodeDistance {


    // Tree with Function to get Distance between nodes.
    public class Tree {

        private Node Head {get; set;}

        public void Insert(int data) {
            Node node = new Node(data);

            if(Head == null) {
                Head = node;
                return;
            }

            Insert(Head, node);
        }

        // Cyclic insert function
        private void Insert(Node parent, Node node) {

            while(node != null) {

                if(node.Data <= parent.Data) {

                    if(parent.Left == null) {
                        parent.Left = node;
                        return;
                    } else {
                        parent = parent.Left;
                    }

                } else {

                    if(parent.Right == null) {
                        parent.Right = node;
                        return;
                    } else {
                        parent = parent.Right;
                    }

                }

            }
            

            
        }

        // traverse In Order
        public List<int> InOrderTraverse() {

            var list = new List<int>();
            InOrderTraverse(Head, list);
            return list;

        }

        private void InOrderTraverse(Node node, List<int> list) {

            if(node == null)
                return;

            //Left Side
            InOrderTraverse(node.Left, list);

            list.Add(node.Data);

            //Rigth Side
            InOrderTraverse(node.Right, list);

        }


        //Distance Between Nodes
        public int DistanceBetweenNodes(int data1, int data2) {

            if(!NodeExist(data1) || !NodeExist(data2))
                return -1;

            Node ccaNode = GetClosestCommonAncestor(data1, data2);
            Console.WriteLine("Common Ancestor: " + ccaNode.Data);

            int dist1 = GetDistance(ccaNode, data1);
            //Console.WriteLine("data1 distance to Head: " + dist1);
            int dist2 = GetDistance(ccaNode, data2);
            //Console.WriteLine("data2 distance to Head: " + dist2);

            return dist1 + dist2;
        }
        
        private int GetDistance(Node node, int data) {
            
            if(node == null)
                return -1;

            if(node.Data == data)
                return 0;

            if(data < node.Data) {                
                return 1 + GetDistance(node.Left, data);
            } else {
                return 1 + GetDistance(node.Right, data);
            }

        }

        private Node GetClosestCommonAncestor(int data1, int data2) {

            if(data1 > data2) {
                int tmp = data1;
                data1 = data2;
                data2 = tmp;
            }

            return GetClosestCommonAncestor(Head, data1, data2);

        }

        private Node GetClosestCommonAncestor(Node node, int low, int high) {

            if(low == node.Data || high == node.Data)
                return node;
            
            if(low < node.Data && high > node.Data)
                return node;

            if(high < node.Data) {
                return GetClosestCommonAncestor(node.Left, low, high);
            } else {
                return GetClosestCommonAncestor(node.Left, low, high);
            }

        }


        public bool NodeExist(int data) {
            return NodeExist(Head, data);
        }

        private bool NodeExist(Node node, int data) {

            if(node == null)
                return false;

            if(node.Data == data)
                return true;
            
            if(NodeExist(node.Left, data) ) {
                return true;
            }

            if(NodeExist(node.Right, data)) {
                return true;
            }

            return false;

        }


        private class Node {

            public int Data {get; set;}
            public Node Left {get; set;}
            public Node Right {get; set;}

            public Node(int data) {
                Data = data;
            }

        }


    }


}