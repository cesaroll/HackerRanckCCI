using System;

namespace BitManipulations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello BitWise Shifts!\n");

            //PrintShifts();
            CountSetBits();
        }

        static void PrintShifts() {

            int val = 1;

            for(int i = 0; i < 31; i ++ ) {
                Console.WriteLine($"{Convert.ToString(val, 2).PadLeft(32, '0')}");
                val = (val << 1);                
            }

            Console.WriteLine($"{Convert.ToString(val, 2).PadLeft(32, '0')}");
            Console.WriteLine($"val: [{val}]");

            val = 1073741824;

            for(int i = 0; i <33; i ++ ) {
                Console.WriteLine($"{Convert.ToString(val, 2).PadLeft(32, '0')}");
                val = (val >> 1);
            }
                
        }

        static void CountSetBits() {

            while(true)
            {
                Console.WriteLine("Type number: ");

                int n = int.Parse(Console.ReadLine());

                int bitCount = 0;

                while(n >= 1) {

                    Console.WriteLine($"{Convert.ToString(n, 2).PadLeft(32, '0')} - {n}");

                    if((n & 1) == 1)
                        bitCount++;

                    n = n >> 1;

                }

                Console.WriteLine($"\nSet Bit Count: {bitCount}\n");
            }
            

        }


    }
}
