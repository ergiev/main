/*
Заполнить двумерный массив размерностью N x M по спирали. Число 1
ставится в центр массива, а затем массив заполняется по спирали 
против часовой стрелки значениями по возрастанию.
*/

using System;

namespace _2_2_Arrays_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 11;
            int M = 11;
            int[,] array = new int[N, M];

            array[N / 2, M / 2] = 1;

            int value = 1;
            for (int i = 0, a = 1, b = 2; i < N / 2; i++, a = a + 2, b = b + 2)
            {
                array[N / 2 - i, M / 2 - i - 1] = ++value;
                for (int c = 1; c <= a; ++c)
                {
                    array[N / 2 - i + c, M / 2 - i - 1] = ++value;
                }
                for (int c = 1; c <= b; ++c)
                {
                    array[N / 2 - i + a, M / 2 - i - 1 + c ] = ++value;
                }
                for (int c = 1; c <= a; ++c)
                {
                    array[N / 2 - i + a - c, M / 2 - i - 1 + b] = ++value;
                }
                array[N / 2 - i - 1, M / 2 + i + 1] = ++value;
                for (int c = 1; c <= b; ++c)
                {
                    array[N / 2 - i - 1, M / 2 - i - 1 + b - c] = ++value;
                }

            }

            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write("{0,4}",array[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}