using System;

namespace zoom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Zoom!");

            /*var image = new string[]{"0000",
                                     "0#00",
                                     "00#0",
                                     "0000"};
            */

            var image = new string[]{"   #####   ", 
                                     "  ##   ##  ", 
                                     " ##     ## ", 
                                     "##       ##", 
                                     "##       ##", 
                                     "##       ##", 
                                     "##       ##", 
                                     "##       ##", 
                                     " ##     ## ", 
                                     "  ##   ##  ", 
                                     "   #####   "};

            var prog = new Program();

            prog.Print(image);
            image = prog.zoom(image);
            prog.Print(image);

        }



        string[] zoom(string[] image) {

            var newImg = new string[image.Length * 2];
            
            
            for(int row = 0; row < image.Length; row++) {

                var arr = image[row].ToCharArray();
                var narr1 = new char[arr.Length * 2];
                var narr2 = new char[arr.Length * 2];

                for(int col=0, ncol=col*2; col < arr.Length; col++, ncol=col*2) {

                    narr1[ncol] = (narr1[ncol] == '#')? narr1[ncol] : arr[col] ;
                    narr1[ncol + 1] = arr[col];

                    narr2[ncol] = arr[col];
                    narr2[ncol + 1] = arr[col];

                    if(narr1[ncol] == '#' && row > 0 && ((ncol-1) >= 0 || (ncol+2) < narr1.Length ) ) {
                        
                        var parr = newImg[row*2 - 1].ToCharArray();
                        bool updt = false;

                        //Console.WriteLine($"Previous Line: >{new string(parr)}< ");
                        //Console.WriteLine($" Current Line: >{new String(narr1)}< \t ncol: {ncol} \t Length: {narr1.Length}");

                        if( ((ncol-1) >= 0) && parr[ncol-1] == '#') {
                            parr[ncol] = '#';
                            updt = true;

                            narr1[ncol-1] = '#';
                        }

                        if( ((ncol+2) < narr1.Length) &&  parr[ncol+2] == '#') {
                            parr[ncol+1] = '#';
                            updt = true;

                            narr1[ncol+2] = '#';

                            //Console.WriteLine("Updated:");

                            //Console.WriteLine($"Previous Line: >{new String(parr)}< ");
                            //Console.WriteLine($" Current Line: >{new String(narr1)}< \t ncol: {ncol+2} \t Length: {narr1.Length} \n");
                        }

                        if(updt)
                            newImg[row*2 - 1] = new String(parr);

                    }


                }

                newImg[row*2] = new String(narr1);
                newImg[row*2 + 1] = new String(narr2);
            }

            
            return newImg;
        }


        private void Print(string[] image) {

            Console.WriteLine();

            foreach (var item in image) {
                foreach(var c in item)
                    Console.Write(c + " ");
                
                Console.WriteLine();
            }
        }

    }
}
