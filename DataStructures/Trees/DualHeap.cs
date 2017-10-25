namespace Trees
{

    public class DualHeap
    {

        private Heap<int> LowerHeap {get;} //Max Heap, get me the maximum of the lowest numbers
        private Heap<int> UpperHeap {get;} //Min heap, get me the minimum of the biggest numbers

        public DualHeap()
        {
            LowerHeap = new Heap<int>(true); // Max Heap
            UpperHeap = new Heap<int>(); // Min Heap
        }


        public decimal GetMedian()
        {
            if(Length % 2 != 0)
                return UpperHeap.Peek();
            else
                return ((decimal)(UpperHeap.Peek() + LowerHeap.Peek()))/2;
        } 

        public int Length
        {
            get {
                return LowerHeap.Length + UpperHeap.Length;
            }
        }

        public void Add(int val)
        {
            if(Length % 2 == 0)
                UpperHeap.Add(val);
            else
                LowerHeap.Add(val);

            Balance();

        }


        private void Balance()
        {
            if(!LowerHeap.IsEmpty && !UpperHeap.IsEmpty && LowerHeap.Peek() > UpperHeap.Peek() ) 
            {
                int lowerHead = LowerHeap.Poll();
                int upperHead = UpperHeap.Poll();

                LowerHeap.Add(upperHead);
                UpperHeap.Add(lowerHead);

            }
        

        }




    }

}