using System;
using System.Collections.Generic;

namespace Memoization {

    public class AllPosiblePaths{


        public static int GetAllPosiblePaths(bool[,] array) {

            int rowCount = array.GetLength(0);
            int colCount = array.GetLength(1);

            return GetAllPosiblePaths(array, new int[rowCount,colCount], 0, 0);

        }

        private static int GetAllPosiblePaths(bool[,] array, int[,] paths, int row, int col) {

            

            if(!ValidSquare(array, row, col)) //Not valid square
                return 0;
            
            Console.WriteLine($"{row}, {col}");

            if(IsAtEnd(array, row, col))
                return 1;


            if(paths[row,col] == 0)
                paths[row,col] = GetAllPosiblePaths(array, paths, row, col+1) + GetAllPosiblePaths(array, paths, row+1, col);

            return paths[row, col];

        }

        private static bool ValidSquare(bool[,] array, int row, int col) {
            int rowCount = array.GetLength(0);
            int colCount = array.GetLength(1);

            if(row >= rowCount || col >= colCount)
                return false;

            if(!array[row,col]) //Not valid square
                return false;

            return true;

        }
        private static bool IsAtEnd(bool[,] array, int row, int col) {

            int rowCount = array.GetLength(0);
            int colCount = array.GetLength(1);

            if(row == rowCount-1 && col == colCount-1)
                return true;

            return false;

        }

    }

}