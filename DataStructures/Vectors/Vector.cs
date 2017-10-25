using System;
using System.Collections.Generic;

namespace Vectors {

    public class Vector : IEnumerable<int> {

        private int[] _array;

        public int Length {get {return _array.Length;}}

        public Vector(int size) {
            _array = new int[size];
        }

        public int Increase(int index) {
            _array[index]++;
            return _array[index];
        }

        public int Decrease(int index) {
            _array[index]--;
            return _array[index];
        }

        public int this[int index] {
            get {
                return _array[index];
            }
            set {
                _array[index] = value;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach(int item in _array) {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }
        
        
    }

}
