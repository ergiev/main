/*
Заполнить двумерный массив размерностью N x M следующим образом:
1   2  3  4  5  6
12 11 10  9  8  7
13 14 15 16 17 18
24 23 22 21 20 19
25 26 27 28 29 30
*/

using System;

namespace _2_2_Arrays_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 5;
            int M = 6;
            int[,] array = new int[N, M];
            int value = 1;

            for (int i = 0; i < N; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < M; j++)
                    {
                        array[i, j] = value++;
                    }
                }
                else
                {
                    for (int j = M - 1; j >= 0; j--)
                    {
                        array[i, j] = value++;
                    }
                }
            }

            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}