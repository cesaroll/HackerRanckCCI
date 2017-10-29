using System;

namespace _01_ArraysAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Arrays and Strings!\n");

            var prog = new Program();

            //prog.IsStringUnique();
            
            //prog.IsPermutation_Sorting();
            prog.IsPermutation_Counting();

        }
    
    void IsPermutation_Counting() {

        Action<string, string> isPermutation = (s1, s2) => {
            if(s1.Length != s2.Length) {
                Console.WriteLine($"{s1}\n{s2}\nSize is different, permutation is false.\n");
            } else {
                var array = new int[256];
                bool isPerm = true;

                foreach(var c in s1)
                    array[c]++;

                foreach(var c in s2) {
                    array[c]--;
                    if(array[c] < 0) {
                        isPerm = false;
                        break;
                    }
                        
                }

                Console.WriteLine($"{s1.ToString()}\n{s2}\nPermutation is [{isPerm}]\n");
            }

        };

        isPermutation("car", "rca");
        isPermutation("flaca", "calaca");
        isPermutation("flaca", "flaco");

    }
    void IsPermutation_Sorting() {

        Func<string, string> orderString = (str) => {
            var array = str.ToCharArray();
            Array.Sort(array);
            return new string(array);
        };

        Action<string, string> isPermutation = (s1, s2) => {
            if(s1.Length != s2.Length) {
                Console.WriteLine($"{s1}\n{s2}\nSize is different, permutation is false.\n");
            } else {
                s1 = orderString(s1);
                s2 = orderString(s2);
                Console.WriteLine($"{s1.ToString()}\n{s2}\nPermutation is [{s1.Equals(s2)}]\n");
            }
        };

        isPermutation("car", "rca");
        isPermutation("flaca", "calaca");
        isPermutation("flaca", "flaco");

    }

    void IsStringUnique() {

        var str = "aBCde";
        Console.WriteLine($"Is '{str}' unique? [{IsStringUnique(str)}]");

        str = "aBCbeC";
        Console.WriteLine($"Is '{str}' unique? [{IsStringUnique(str)}]");

        str = "abcde";
        Console.WriteLine($"Is '{str}' unique? [{IsStringUniqueLow(str)}]");

        str = "abcbe";
        Console.WriteLine($"Is '{str}' unique? [{IsStringUniqueLow(str)}]");

            
    }

     // ASCII and 
     bool IsStringUnique(string str) {
    
        var array = new bool[256];

        for(var idx=0; idx < str.Length; idx++) {
            int value = str[idx];
            if(array[value])
                return false;
            array[value] = true;     
        }
        
        return true;

     }

        //ASCII and lowercase
        bool IsStringUniqueLow(string str) {
            int checker=0;

            for(var idx=0; idx < str.Length; idx++) {

                Console.WriteLine($"Check: {Convert.ToString(checker, 2).PadLeft(8,'0')}");

                int val = str[idx] - 'a';

                Console.WriteLine($"Check: {Convert.ToString((1 << val), 2).PadLeft(8,'0')}");

                if( (checker & (1 << val)) > 0) {

                    return false; 
                }
                
                checker |= (1 << val); 
                Console.WriteLine();
            }

            return true;

        }

    }

}
