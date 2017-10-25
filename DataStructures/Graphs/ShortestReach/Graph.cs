using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.ShortestReach {


    public class Graph {

        private Dictionary<int, Node> Nodes {get; set;}

        /// <summary>
        /// Cosntructor
        /// </summary>
        public Graph() {
            Nodes = new Dictionary<int, Node>();
        }

        /// <summary>
        /// Shortest Reach BFS Breadth First Search.
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public List<int> ShortestReach(int start) {

            var queue = new Queue<List<Node>>();            
            var visited = new Dictionary<int, int>();
            var retList = new List<int>();

            Node n = GetNode(start);
            if(n != null) {
                var list = new List<Node>();
                list.Add(n);
                queue.Enqueue(list);

            } else {
                return retList;
            }
                
            int distance = 0;

            while(queue.Count > 0) {

                var nodes = queue.Dequeue();

                var allAdjacentNodes = new List<Node>();

                foreach(var node in nodes) {

                    if(!visited.ContainsKey(node.Data)) {
                        
                        visited[node.Data] = distance;

                        allAdjacentNodes.AddRange(node.AdjacentNodes);

                    }

                }

                allAdjacentNodes = allAdjacentNodes.Distinct().ToList();
                if(allAdjacentNodes.Count() > 0)
                    queue.Enqueue(allAdjacentNodes);

                distance++;

            }

            // Fore ach one except starting node, add its distance acording to visited to the returned list, ordered by node
            foreach(var key in Nodes.Keys.OrderBy(x => x))  {

                //Console.WriteLine(key);

                if(key == start)
                    continue;

                if(visited.TryGetValue(key, out distance) ) {
                    retList.Add(distance);
                } else {
                    retList.Add(-1);
                }

            }

            /* 
            Console.WriteLine("Visited:");
            foreach(var kvp in visited) {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }*/

            return retList;

        }


        /// <summary>
        /// Add single node
        /// </summary>
        /// <param name="data"></param>
        public void AddNode(int data) {
            if(!Nodes.TryGetValue(data, out Node node)) {
                Nodes[data] = new Node(data);
            }
        }

        /// <summary>
        /// Add Nodes from one to n (number of nodes)
        /// </summary>
        /// <param name="count"></param>
        public void AddNodes(int n) {
            for(int i=1; i <= n; i++) {
                AddNode(i);
            }
        }

        /// <summary>
        /// Add Edge from source to destination 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        public void AddEdge(int source, int dest) {

            var sourceNode = GetNode(source);
            if(sourceNode == null) return;
            var destNode = GetNode(dest);
            if(destNode == null) return;

            if(!sourceNode.AdjacentNodes.Contains(destNode))
                sourceNode.AdjacentNodes.Add(destNode);

            /* 
            if(!destNode.AdjacentNodes.Contains(sourceNode))
                destNode.AdjacentNodes.Add(sourceNode);
                */

        }

        /// <summary>
        /// Add group of edges
        /// </summary>
        /// <param name="edges"></param>
        public void AddEdges(int[,] edges){
            
            var m = edges.GetLength(0);
            
            for(var i=0; i<m; i++) {
                AddEdge(edges[i,0], edges[i,1]);
            }
        }

        /// <summary>
        /// Get Node object from data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private Node GetNode(int data) {
            Nodes.TryGetValue(data, out Node node);
            return node;
        }

        /// <summary>
        /// Node Class
        /// </summary>
        class Node : IComparable<Node> {

            public int Data {get; set;}
            public List<Node> AdjacentNodes{get; set;}

            public Node(int data) {
                this.Data = data;
                AdjacentNodes = new List<Node>();
            }

            public int CompareTo(Node other) {
                return Data.CompareTo(other.Data);
            }

        }


    }


}