using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Graph();

            //Grid();

            ShortestReach();

        }

        private static void ShortestReach() {

            Console.WriteLine("Graph: Shortest Reach.");

            int queries = int.Parse(Console.ReadLine());

            for(int i=0; i<queries; i++ ){

                var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                var n = input[0]; //Number of nodes
                var m = input[1]; //Number of edges.

                var graph = new Graphs.ShortestReach.Graph();

                graph.AddNodes(n); //Add number of nodes

                //Add Edges
                for(int j=0; j<m; j++) {
                    
                    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                    graph.AddEdge(input[0], input[1]);

                }

                var s = int.Parse(Console.ReadLine());
                var list = graph.ShortestReach(s);

                Console.WriteLine(string.Join(" ", list.Select(x => (x > 0)? x*6 : x ).Select(x => x.ToString())));

            }


            

        }

        private static void Grid() {

            /* 
            var array = new int[][]{ new[]{1,1,0,0},
                                     new[]{0,1,1,0},
                                     new[]{0,0,1,0},
                                     new[]{1,0,0,0}};
                                     */
            var array = new int[][]{ new[]{1,1,0,0},
                                     new[]{0,1,1,0},
                                     new[]{0,0,1,0},
                                     new[]{1,0,0,0},
                                     new[]{1,1,1,1},
                                     new[]{0,1,1,1}};
            
            var grid = new GraphGrid();

            grid.AddNodes(array);
            var maxAdjCount = grid.GetMaxAdjacentCount();
            Console.WriteLine($"Max Adjacent Count: [{maxAdjCount}]");

        }

        private static void Graph() {
            Console.WriteLine("Graph!");
            Console.WriteLine("Add nodes separated by space");

            var nodes = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var graph = new Graph();

            foreach(var node in nodes)
                graph.AddNode(node);
            
            var input = "";
            while(input != "quit") {
                PrintMenu();
            
                input = Console.ReadLine();

                if(input.StartsWith("q"))
                    break;

                var split = input.Split(' ');

                var source = int.Parse(split[1]);
                var dest = int.Parse(split[2]);

                switch(split[0]) {
                    case "edge":
                        graph.AddEdge(source, dest);
                        break;
                    case "dfs":
                        var list = graph.HasPathDFS(source, dest);
                        PrintResult("DFS", list);
                        break;
                    case "bfs":
                        Console.WriteLine($"BFS Found: [{graph.HasPathBFS(source, dest)}]");
                        break;
                }
                
            }
        }

        private static void PrintResult(string msg, List<int> list) {
            
            if(list == null) {
                Console.WriteLine($"{msg} NOT found.");
            }
            else {
                list.Reverse();
                var str = string.Join(' ', list.Select(x => x.ToString()));
                Console.WriteLine($"{msg} Found: {str}");
            }
            
        }

        private static void PrintMenu(){
            Console.WriteLine("\nEnter 'edge <source> <dest>' \n      'dfs/bfs <source> <dest>'\n      'quit'\n");
        }

    }
}
