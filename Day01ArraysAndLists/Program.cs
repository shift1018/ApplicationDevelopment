using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01ArraysAndLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // possibly a jagged array, only the first dimension is allocated
            int[][] twoDimInt = new int[4][];
            // rectangular array
            int[,] twoDimIntRectangular = new int[4, 3];
            int[,,] threeDimIntRect = new int[4, 3, 2]; // 3D: 4 x 3 x 2 size

            int[,] data2dInts = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 18 } };
            int x = 0;
            float avg;
            float sum = 0;
            for ( int i = 0; i<data2dInts.GetLength(0); i++)
            {
                for (int j = 0; j < data2dInts.GetLength(1); j++)
                {
                    
                    sum += data2dInts[i, j];
                    x++;
                   
                }
            }
            avg = sum / x;
            Console.WriteLine(sum); 
            Console.WriteLine(x); 
            Console.WriteLine("{ avg: 000}");
            Console.WriteLine();
            Console.ReadKey();
        }
        
    } 
   
}
