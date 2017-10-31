using System;
using System.Collections.Generic;
using System.Linq;

namespace Ces.Collections.HanoiTowers {

    public interface ITower {

        int TowerId {get;}
        void AddDisk(int diskId);
        void MoveDisks(int n, ITower destination, ITower buffer);

        void DisplayDisks();
    }
    public class Tower : ITower {
        public int TowerId{get;}
        private Stack<int> DiskStack {get;}

        public Tower(int towerId) {
            TowerId = towerId;
            DiskStack = new Stack<int>();
        }

        public void AddDisk(int diskId){
            if(DiskStack.Count == 0 || DiskStack.Peek() >= diskId)
                DiskStack.Push(diskId);
            else {
                string msg = $"Error inserting disk: {diskId} when top disk is: {DiskStack.Peek()}";
                DisplayMessage(msg);
                throw new Exception(msg);
            }

        }

        private void MoveTopTo(ITower t) {
            if(DiskStack.Count > 0) {
                int disk = DiskStack.Pop();
                t.AddDisk(disk);
                DisplayMessage($"Disk {disk} moved to Tower {t.TowerId}");
            }
        }

        public void MoveDisks(int discCount, ITower destination, ITower buffer) {

            if(discCount <= 0)
                return;

            MoveDisks(discCount-1, buffer, destination);
            MoveTopTo(destination);
            buffer.MoveDisks(discCount-1, destination, this);


        }


        private void DisplayMessage(string msg) {
            Console.WriteLine($"TowerId: {TowerId}. {msg}");
        }

        public void DisplayDisks() {

            var array = DiskStack.ToArray();
            DisplayMessage(string.Join(" ", array.Select(x => x.ToString())));
        }

    }


}