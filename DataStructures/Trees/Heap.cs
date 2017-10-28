using System;
using System.Collections.Generic;

namespace Trees
{
    public class Heap<T> where T : IComparable<T>
    {
        private List<T> Items {get;}

        private bool MaxHeap {get;}

        public Heap() : this(false)
        {
            
        }

        public Heap(bool maxHeap)
        {
            Items = new List<T>();

            MaxHeap = maxHeap;
        }

        private int getLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int getRightChildIndex(int parentindex) { return 2 * parentindex + 2; }
        private int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }

        private bool hasLeftChild(int index) { return getLeftChildIndex(index) < Items.Count;}
        private bool hasRightChild(int index) { return getRightChildIndex(index) < Items.Count; }
        private bool hasParent(int index) { return getParentIndex(index) >= 0; }

        private T leftChild(int index) { return Items[getLeftChildIndex(index)]; }
        private T rightChild(int index) { return Items[getRightChildIndex(index)]; }
        private T parent(int index) { return Items[getParentIndex(index)]; }

        private void Swap(int idxOne, int idxTwo)
        {
            T tmp = Items[idxOne];
            Items[idxOne] = Items[idxTwo];
            Items[idxTwo] = tmp;
        }

        public bool IsEmpty{
            get { return this.Length == 0;}
        }
        
        public int Length
        {
            get{return Items.Count;}        
        }
        
        public T Peek()
        {
            return Items[0];
        }

        public T Poll()
        {
            T item = Items[0];

            int lastIdx = Items.Count - 1;

            Items[0] = Items[lastIdx];
            Items.RemoveAt(lastIdx);

            HeapifyDown();

            return item;
        }

        public void Add(T item)
        {
            Items.Add(item);

            HeapifyUp();
        }

        public void HeapifyUp()
        {
            int index = Items.Count - 1;

            while(hasParent(index) && GT(parent(index), Items[index]))
            {
                Swap(getParentIndex(index), index);
                index = getParentIndex(index);

            }
        }
	 
        public void HeapifyDown()
        {
            int index = 0;

            while(hasLeftChild(index))
            {
                int childindex = getLeftChildIndex(index);
                
                if(hasRightChild(index) && LT(rightChild(index), leftChild(index)) )
                {
                    childindex = getRightChildIndex(index);
                }

                if(LT(Items[index], Items[childindex]))
                    break;
                else
                    Swap(index, childindex);

                index = childindex;


            }
        }
         
        private bool GT(T item1, T item2)
        {
            if(MaxHeap)
            {
                T tmp = item1;
                item1 = item2;
                item2 = tmp;
            }

            return item1.CompareTo(item2) > 0;

        }

        private bool LT(T item1, T item2)
        {
            if(MaxHeap)
            {
                T tmp = item1;
                item1 = item2;
                item2 = tmp;
            }
            
            return item1.CompareTo(item2) < 0;

        }

    }

}
