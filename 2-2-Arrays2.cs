/*
Заполнить двумерный массив размерностью N x M следующим образом:
1   2  3  4  5  6
7   8  9 10 11 12
13 14 15 16 17 18
19 20 21 22 23 24
25 26 27 28 29 30
*/

using System;

namespace _2_2_Arrays_2
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
                for (int j = 0; j < M; j++)
                {
                    array[i, j] = value++;
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
