/*
Написать программу, проверяющую, является ли одна строка 
анаграммой для другой строки (строка может состоять из 
нескольких слов и символов пунктуации). Пробелы и пунктуация, 
разница в больших и маленьких буквах должны игнорироваться. 
Обе строки вводятся с клавиатуры.

Пример анаграммы:
Аз есмь строка, живу я, мерой остр. 
За семь морей ростка я вижу рост!
*/

using System;
using System.Linq;

namespace _2_4_Strings_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку:");
            string source1 = (Console.ReadLine()).ToLower();
            Console.WriteLine("Введите вторую строку:");
            string source2 = (Console.ReadLine()).ToLower();

            string result1 = "";
            string result2 = "";

            foreach (char el in source1)
            {
                if (Char.IsLetter(el))
                    result1 += el;
            }
            foreach (char el in source2)
            {
                if (Char.IsLetter(el))
                    result2 += el;
            }

            result1 = String.Concat(result1.OrderBy(x => x));
            result2 = String.Concat(result2.OrderBy(x => x));

            if (result1.Equals(result2))
                Console.WriteLine("Данные строки являются анаграммами.");
            else
                Console.WriteLine("Данные строки НЕ являются анаграммами.");
        }
    }
}