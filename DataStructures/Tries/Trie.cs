using System;
using System.Collections.Generic;

namespace Tries {

    public class Trie {
    
        private Node Head {get;}
        
        public Trie() {
            Head = new Node();
        }
        
        ///Adding word
        public void Add(string word) {
            
            if(String.IsNullOrEmpty(word))
                return;
            
            var node = Head;
            foreach(var c in word) {
                
                if(node.Children == null)
                    node.Children = new Dictionary<char, Node>();
                
                var children = node.Children;
                Node child;
                
                if(!children.TryGetValue(c, out child)) {
                    child = new Node();
                    children[c] = child;
                }
                
                child.ChildWordCount++;
                node = child;
                
            }
            
            node.IsWord = true;
            
        }
        
        
        ///Counting all words that start with input value
        public long Count_StartingWith(string word) {
            
            if(string.IsNullOrEmpty(word))
                return 0;
            
            var node = Head;
            for(int i=0; i<word.Length; i++) {
                
                char c = word[i];
                
                if(node.Children == null || node.Children.Count == 0)
                    return 0;
                
                var children = node.Children;
                Node child;
                
                if(!children.TryGetValue(c, out child)) {
                    return 0;
                }
                
                node = child;
                
            }
            
            return Count_Words(node);
            
        }
        
        private long Count_Words(Node node) {
            
            if(node == null) return 0;
            
            return node.ChildWordCount;
            
            /*
            long count = (node.IsWord)? 1 : 0;
            
            if(node.Children != null) {
                
                foreach(var child in node.Children.Values) {
                    count += Count_Words(child);
                }
                
            }
            
            return count;
            */
            
        }
        
        class Node {
            public Dictionary<char, Node> Children {get; set;}
            public bool IsWord {get; set;}
            public long ChildWordCount {get; set;}
        }
    
    }

}