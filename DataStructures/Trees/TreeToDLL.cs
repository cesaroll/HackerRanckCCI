using System;
using System.Collections.Generic;
using System.Linq;

namespace Trees.TeeToDLL {

    public class Tree {

        private Node Root{get; set;}
        public void Insert(int data) {
            Node node = new Node(data);

            if(Root == null) {
                Root = node;
                return;
            }

            Insert(Root, node);
        }

        private void Insert(Node parent, Node child) {
            
            if(child.Data <= parent.Data)
                if(parent.Left == null)
                    parent.Left = child;
                else
                    Insert(parent.Left, child);
            else
                if(parent.Right == null)
                    parent.Right = child;
                else
                    Insert(parent.Right, child);
            //Console.WriteLine(data);
        }

        public Node ConvertToDLL() {

            var list = new List<Node>();
            
            InOrder(Root, list);

            //Console.WriteLine(string.Join(" ", list.Select(x => x.Data.ToString())));

            //COnvert to DLL

            for(int idx = 0; idx < list.Count-1; idx++) {
                Node current = list[idx];
                Node next = list[idx+1];

                current.Right = next;
                next.Left = current;
            }

            
            return (list[0] != null)? list[0] : null;
        }

        private void InOrder(Node node, List<Node> list) {

            if(node == null)
                return;
            //Console.WriteLine(node.Data);
            InOrder(node.Left, list);

            list.Add(node);

            InOrder(node.Right, list);

        }

    }

    public class Node {
        public int Data;
        public Node Left;
        public Node Right;

        public Node(int data) {
            Data = data;
        }
    }

}
