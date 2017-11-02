using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs {

    public class Graph {
        
        private Dictionary<int, Node> nodeLookup;
        
        public Graph() {
            nodeLookup = new Dictionary<int, Node>();
        }

        public void AddNode(int id) {
            if(!nodeLookup.TryGetValue(id, out Node node)) {
                nodeLookup[id] = new Node(id);
            }
        }                                                                      m

        public void AddEdge(int source, int destination) {
            var s = GetNode(source);
            var d = GetNode(destination);
            s.AdjacentNodes.Add(d);
        }
        
        /*
            Depth First Search.
            Goes deep to children before going broad to neighbours.

        */
        public List<int> HasPathDFS(int source, int destination) {
            var s = GetNode(source);
            if(s == null) return null;
            var d = GetNode(destination);
            if(d == null) return null;

            return HasPathDFS(s, d, new HashSet<int>());
        }

        private List<int> HasPathDFS(Node s, Node d, HashSet<int> visited) {
        
            if(visited.Contains(s.Id) )
                return null;
            
            if(s == d) {
                var list = new List<int>();
                list.Add(d.Id);
                return list;
            }
                

            visited.Add(s.Id);

            foreach(var node in s.AdjacentNodes) {
                var list = HasPathDFS(node, d, visited);
                if( list != null) {
                    list.Add(s.Id);
                    return list;
                }
                    
            }

            return null;
        
        }

        /*
            Breadth First Search.
            Goes broad to neighbours before going deep.
        */
        public bool HasPathBFS(int source, int destination) {

            var s = GetNode(source);
            if(s == null) return false;
            var d = GetNode(destination);
            if(d == null) return false;

            return HasPathBFS(s, d);
        }

        private bool HasPathBFS(Node source, Node destination) {

            var queue = new Queue<Node>();
            queue.Enqueue(source);

            var visited = new HashSet<int>();

            while(queue.Count > 0) {

                var node = queue.Dequeue();

                if(node == destination) {
                    PrintVisited(visited);
                    return true;
                }
                
                if(visited.Contains(node.Id))
                    continue;

                visited.Add(node.Id);    
                    
                foreach(var item in node.AdjacentNodes) {
                    queue.Enqueue(item);   
                }

            }

            return false;

        }
        private void PrintVisited(HashSet<int> visited) {
            var str = string.Join(" ", visited.Select(x => x.ToString()));
            Console.WriteLine($"Visited: [{str}]");
        }

        private Node GetNode(int id) {
            nodeLookup.TryGetValue(id, out Node node);
            return node;
        }


        class Node {
            public int Id;
            public List<Node> AdjacentNodes = new List<Node>();

            public Node(int id) {
                Id = id;
            }
        }

    }

}
