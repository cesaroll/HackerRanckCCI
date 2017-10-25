using System;

namespace Tries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nTries!\n");

            var trie = new Trie();

            var n = int.Parse(Console.ReadLine());

            for(var i=0; i<n; i++) {

                var strSplit = Console.ReadLine().Split(" ");
                var op = strSplit[0];
                var value = strSplit[1];

                if(op == "add")
                    trie.Add(value);
                else if(op == "find") {
                    var count = trie.Count_StartingWith(value);
                    Console.WriteLine(count);
                }

            }


            Console.WriteLine("\n\nEnd.\n");

        }
    }
}
