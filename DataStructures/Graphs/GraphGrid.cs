using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs {

    public class GraphGrid {

        private Dictionary<int, Node> Nodes {get;}

        public GraphGrid() {
            Nodes = new Dictionary<int, Node>();
        }

        public void AddNodes(int[][] items) {
            
            int n = items.Length;

            Console.WriteLine($"n: {n}");

            for(int i=0; i < n; i++) {
                
                int m = items[i].Length;
                Console.WriteLine($"m: {m}");

                for(int j=0; j < m; j++) {
                    
                    Console.WriteLine($"i: {i}, j: {j}");

                    if(items[i][j] == 1) {
                        int id = i*m + j;
                        var node = GetOrCreateNode(id);
                        Console.WriteLine($"Nodes count: {Nodes.Count}");
                        AddEdges(node, i, j, items);
                    }
                }
            }

        }

        private Node GetOrCreateNode(int id) {
            if(Nodes.TryGetValue(id, out Node node))
                return node;
            else {
                node = new Node(id);
                Nodes[id] = node;
                return node;
            }
        }

        /// Add Edges function
        private void AddEdges(Node node, int i, int j, int[][] items) {
            
            int  n = items.Length;

            foreach(var adj in AdjacentCalcValues) {

                int idxi = i+adj[0];
                int idxj = j+adj[1];

                if(idxi < 0 || idxj < 0 || idxi > (n-1) ) 
                    continue;

                int m = items[idxi].Length;

                if(idxj > (m-1) ) 
                    continue;
                
                if(items[idxi][idxj] != 1)
                    continue;

                int id = idxi*m + idxj;

                var adjacentNode = GetOrCreateNode(id);

                AddEdge(node, adjacentNode);

            }

        }

        private readonly List<int[]> AdjacentCalcValues = new List<int[]> {
                        new []{-1,-1}, new []{-1,0}, new []{-1,1},
                        new []{0,-1},               new []{0,1},
                        new []{1,-1},  new []{1,0},  new []{1,1}                 
                        }; 

        private void AddEdge(Node source, Node destination) {
            if( source != destination && !source.AdjacentNodes.Contains(destination)) {
                source.AdjacentNodes.Add(destination);
                Console.WriteLine($"Add edge: [{source.Id} , {destination.Id}]");
            }
        }

        /// Depth First Search
        /// Returns max count of adjacent elements
        public int GetMaxAdjacentCount() {
            var visited = new HashSet<int>();

            int maxCount = 0;

            while(visited.Count < Nodes.Count) {

                var node = Nodes.Where(x => !visited.Contains(x.Key)).Select(x => x.Value).FirstOrDefault();

                int count = GetMaxAdjacentCount(node, visited);

                if(count > maxCount)
                    maxCount = count;
                
            }

            return maxCount;

        }

        ///Recursive DFS
        private int GetMaxAdjacentCount(Node node, HashSet<int> visited) {

            if(visited.Contains(node.Id))
                return 0;

            visited.Add(node.Id);

            int count = 1;

            foreach(var item in node.AdjacentNodes) {
                count += GetMaxAdjacentCount(item, visited);
            }

            return count;

        }



        private class Node : IComparable<Node> {
            public int Id {get; set;}
            public List<Node> AdjacentNodes {get; set;}
            public Node(int id) {
                Id = id;
                AdjacentNodes = new List<Node>();
            }

            public int CompareTo(Node other) {
                return this.Id.CompareTo(other.Id);
            }

        }


    }


}
