/*
Заполнить трехмерный массив размерностью N x N x N нулями.
В получившийся куб вписать шар, состоящий из единиц. После
чего, разрезать куб на N слоев, и показать каждый слой в
виде двумерного массива N x N на экране консоли.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_2_Arrays_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 7;
            int[,,] array = new int[N, N, N];
            double radius = (N - 1) / 2.0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        if (Math.Sqrt((i - radius)*(i - radius) + (j - radius)*(j - radius) + (k - radius)*(k - radius)) <= radius)
                        {
                            array[i, j, k] = 1;
                        }
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        Console.Write("{0,4}", array[i, j, k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }


    }
}
