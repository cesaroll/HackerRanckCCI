using System;
using System.Collections.Generic;

namespace Trees
{

    public class MinIntHeap
    {
        private List<int> items;

        public MinIntHeap()
        {
            items = new List<int>();
        }

        private int getLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int getRightChildIndex(int parentindex) { return 2 * parentindex + 2; }
        private int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }

        private bool hasLeftChild(int index) { return getLeftChildIndex(index) < items.Count;}
        private bool hasRightChild(int index) { return getRightChildIndex(index) < items.Count; }
        private bool hasParent(int index) { return getParentIndex(index) >= 0; }

        private int leftChild(int index) { return items[getLeftChildIndex(index)]; }
        private int rightChild(int index) { return items[getRightChildIndex(index)]; }
        private int parent(int index) { return items[getParentIndex(index)]; }

        private void swap(int idxOne, int idxTwo)
        {
            int tmp = items[idxOne];
            items[idxOne] = items[idxTwo];
            items[idxTwo] = tmp;
        }

        public bool IsEmpty{
            get { return this.Length == 0;}
        }
        
        public int Length
        {
            get{return items.Count;}        
        }
        
        public int peek()
        {
            return items[0];
        }

        public int poll()
        {
            int item = items[0];

            int lastIdx = items.Count - 1;

            items[0] = items[lastIdx];
            items.RemoveAt(lastIdx);

            heapifyDown();

            return item;
        }

        public void add(int item)
        {
            items.Add(item);

            heapifyUp();
        }

        public void heapifyUp()
        {
            int index = items.Count - 1;

            while(hasParent(index) && parent(index) > items[index])
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);

            }
        }
	 
        public void heapifyDown()
        {
            int index = 0;

            while(hasLeftChild(index))
            {
                int smallerChildIndex = getLeftChildIndex(index);
                if(hasRightChild(index) && rightChild(index) < leftChild(index))
                {
                    smallerChildIndex = getRightChildIndex(index);
                }

                if(items[index] < items[smallerChildIndex])
                    break;
                else
                    swap(index, smallerChildIndex);

                index = smallerChildIndex;


            }
        }
         
    }

}
