using System;
using System.Collections.Generic;

namespace Trees {

    public class SimpleLogic<T> where T : IComparable, new() {

        public bool IsBinarySearchTree(SimpleNode<T> root) {
            
            //return IsBinarySearchTreeTraversingAll(root);

            return IsBinarySearchTree_FasterOption(root);
 
        }

        /// Calls Recursive function to a faster traverse to
        /// figure it out if this is a Binary Search Tree
        private bool IsBinarySearchTree_FasterOption(SimpleNode<T> root) {
            T prev = default(T);
            return IsBinarySearchTree_Rec(root, ref prev);
        }
        
        /// Recursive Function to verify if this is a Binary Search Tree
        /// It does not traverse the whole tree.
        private bool IsBinarySearchTree_Rec(SimpleNode<T> node, ref T prev) {

            if(node == null)
                return true;
            // Left
            if(!IsBinarySearchTree_Rec(node.Left, ref prev))
                return false;
            

            // Compare Current to previous or MIN/Default
            if(prev.CompareTo(default(T)) != 0 && node.Data.CompareTo(prev) <= 0) {
                Console.Write($"{node.Data} ");
                return false;
            }                
            else {                
                prev = node.Data;
                Console.Write($"{prev} ");
            }
                

            //Right
            if(!IsBinarySearchTree_Rec(node.Right, ref prev))
                return false;
            
            return true;
        }


        /// 
        /// Compare items of Traversed in order List to verify if this is  a binary Search Tree
        ///
        private bool IsBinarySearchTreeTraversingAll(SimpleNode<T> root) {

            _list = new List<T>();

            TraverseInOrder(root);
            
            for(var idx=1; idx<_list.Count; idx++) {

                var prev = _list[idx-1];
                var current = _list[idx];
                
                if(prev.CompareTo(current) >= 0)
                    return false;                                   

            }

            return true;
        }

        private List<T> _list;

        /// trvese In Order and save into a List
        private void TraverseInOrder(SimpleNode<T> node) {

            if(node == null)
                return;            

            TraverseInOrder(node.Left);

            _list.Add(node.Data);

            TraverseInOrder(node.Right);

        }

    }

}
