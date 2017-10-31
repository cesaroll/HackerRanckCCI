using System;

namespace _03_StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Stacks and Queues!\n");

            TowersOfHanoi();

        }


        private static void TowersOfHanoi() {
            int towerCount = 3;
            Console.WriteLine("Disk Number:");
            int diskCount = int.Parse(Console.ReadLine());
            var towers = new Ces.Collections.HanoiTowers.ITower[towerCount];

            //Create towers
            for(int i=0; i < towerCount; i++)
                towers[i] = new Ces.Collections.HanoiTowers.Tower(i);

            //Add disks to first tower (origin)
            for(int i = diskCount-1; i>= 0; i--)
                towers[0].AddDisk(i);

            //Start Disk movement
            var origin = towers[0];
            var buffer = towers[1];
            var destination = towers[2];

            origin.DisplayDisks();

            origin.MoveDisks(diskCount, destination, buffer);

            destination.DisplayDisks();


        }

    }
}
