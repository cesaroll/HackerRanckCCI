using System;
using System.Collections.Generic;

namespace Ces.Collections.Heaps {

    public class MinHeap {

        private List<int> Elements {get;}

        public MinHeap() {
            Elements = new List<int>();
        }

        public int Lenght {
            get{
                return Elements.Count;
            }
        }
        public void Push(int value) {

            Elements.Add(value);
            HeapifyUp();

        }

        public int Peek {
            get {
                return Elements[0];
            }
        }

        public int Pop () {

            int value = Elements[0];

            int lastIdx = Lenght-1;
            Elements[0] = Elements[lastIdx];
            Elements.RemoveAt(lastIdx);
            
            HeapifyDown();

            return value;

        }

        

        //Private methods

        private void HeapifyUp() {

            int idx = Lenght-1;
            int value = Elements[idx];

            while(HasParent(idx) && value < ParentValue(idx)) {

                Swap(ParentIndex(idx), idx);
                idx = ParentIndex(idx);

            }

        }

        private void HeapifyDown(){

            int idx = 0;

            while(HasLeftChild(idx)) {

                int smallerChildIdx = LeftChildIndex(idx);

                if(HasRightChild(idx) && RightChildValue(idx) < LeftChildValue(idx))
                    smallerChildIdx = RightChildIndex(idx);

                if(Elements[smallerChildIdx] < Elements[idx]) {
                    Swap(smallerChildIdx, idx);
                    idx = smallerChildIdx;
                } else {
                    break;
                }

            }

        }

        private void Swap(int idx1, int idx2) {
            int tmp = Elements[idx1];
            Elements[idx1] = Elements[idx2];
            Elements[idx2] = tmp;
        }

        private int LeftChildIndex(int idx) { return idx * 2 + 1; }
        private int RightChildIndex(int idx) { return idx * 2 + 2; }
        private int ParentIndex(int idx) { return (idx-1)/2;}

        private bool HasLeftChild(int idx) { return LeftChildIndex(idx) < Lenght; }
        private bool HasRightChild(int idx) { return RightChildIndex(idx) < Lenght; }
        private bool HasParent(int idx) { return ParentIndex(idx) >=0; }

        private int LeftChildValue(int idx) { return Elements[LeftChildIndex(idx)]; }
        private int RightChildValue(int idx) { return Elements[RightChildIndex(idx)]; }
        private int ParentValue(int idx) { return Elements[ParentIndex(idx)];}

 

    }

}