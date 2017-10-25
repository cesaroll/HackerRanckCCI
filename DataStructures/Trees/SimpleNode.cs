using System;

namespace Trees {

    public class SimpleNode<T> where T : IComparable, new()  {
        
        public T Data {get; set;}
        public SimpleNode<T> Left {get; set;}
        public SimpleNode<T> Right {get; set;}

        public SimpleNode(T data) {
            Data = data;
        }

    }

}
