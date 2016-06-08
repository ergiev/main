/*
Напишите программу, которая выведет на экран все 
перестановки символов в исходной строке. Избежать 
повторений при перестановках. Примерами перестановки 
строки "AAB" могут быть "AAB", "ABA" и "BAA".
*/

using System;

namespace _2_4_Strings_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            char[] source = Console.ReadLine().ToCharArray();

            Console.WriteLine();
            do
            {
                Console.WriteLine(source);
            }
            while (Next(source));
        }

        static bool Next (char[] a)
        {
            if (a.Length < 2) return false;
            int k = a.Length - 2; //длина - 2

            while (k >= 0 && a[k].CompareTo(a[k + 1]) >= 0)
                k--;
            if (k < 0) return false;

            int l = a.Length - 1;
            while (l > k && a[l].CompareTo(a[k]) <= 0)
                l--;

            char tmp = a[k];
            a[k] = a[l];
            a[l] = tmp;

            int i = k + 1;
            int j = a.Length - 1;
            while (i < j)
            {
                tmp = a[i];
                a[i] = a[j];
                a[j] = tmp;
                i++;
                j--;
            }

            return true;
        }
    }
}
