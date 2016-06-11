/*
Дана последовательность:
1, 11, 21, 1211, 111221, 312211, 13112221, 1113213211...
Ввести число N. Показать N-й по счету элемент
последовательности.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1_Arrays3
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите положительное целое число больше нуля:");
            string N = Console.ReadLine();

            string[] array = new string[Convert.ToInt32(N) + 1];
            array[0] = "1";
            int count;

            for (int i = 1; i < array.Length; ++i)
            {
                for (int j = 0; j < array[i - 1].Length; ++j)
                {
                    count = 1;

                    if (j > 0 && (array[i - 1])[j] == (array[i - 1])[j - 1])
                        continue;

                    if ((j < (array[i - 1].Length) - 1) && (array[i - 1])[j] == (array[i - 1])[j + 1])
                    {
                        count++;
                        if ((j < (array[i - 1].Length) - 2) && (array[i - 1])[j + 1] == (array[i - 1])[j + 2])
                        {
                            count++;
                        }
                    }
                    array[i] = array[i] + count.ToString() + (array[i - 1])[j];
                }
            }

            Console.Write("На позиции {0} находится число ", N);
            Console.WriteLine(array[Convert.ToInt32(N) - 1] + '.');
        }
    }
}
