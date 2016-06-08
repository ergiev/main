/*
Написать программу, подсчитывающую количество слов, гласных и согласных 
букв в строке, введёной пользователем. Дополнительно выводить количество 
знаков пунктуации, цифр и др. символов. Пример вывода программы:

Всего символов – 38, из них:
Слов – 6
Гласных - 12
Согласных - 24
Знаков пунктуации - 2
Цифр – 0
Др. символов – 0
*/

using System;

namespace _2_4_Strings_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string source = Console.ReadLine();
            string vowel = "уеыаоэиюeyuioa";
            string consonant = "йцкнгшщзхфвпрлджчсмтбqwrtpsdfghjklzxcvbnm";
            string punctuation = ".,!;:?-()\"";

            source = source.ToLower();

            int symbols = 0;
            int spaces = 0;
            int vowels = 0;
            int consonants = 0;
            int punctuations = 0;
            int digits = 0;
            int other = 0;
            bool flag; //флаг для определения знака не из символа
            int words = 0;

            foreach (char el in source)
            {
                flag = false;
                if (el.Equals(' '))
                {
                    spaces++;
                    continue;
                }
                else
                    symbols++;
                foreach (char sym in vowel)
                {
                    if (el.Equals(sym))
                    {
                        vowels++;
                        continue;
                    }
                }
                foreach (char sym in consonant)
                {
                    if (el.Equals(sym))
                    {
                        consonants++;
                        continue;
                    }
                        
                }
                foreach (char sym in punctuation)
                {
                    if (el.Equals(sym))
                    {
                        punctuations++;
                        flag = true;
                        continue;
                    }
                }
                if (Char.IsDigit(el))
                {
                    digits++;
                    continue;
                }
                if (!Char.IsLetterOrDigit(el) && flag == false)
                {
                    other++;
                }
            }

            string[] wordsArray = source.Split(new[] { ' ', ',', ':', '?', '!', '-', ';', '(', ')', '\"' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in wordsArray)
            {
                foreach(char el in word)
                {
                    if (Char.IsDigit(el))
                        break;
                    else
                    {
                        words++;
                        break;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Всего символов – {0}, из них:", symbols);
            Console.WriteLine("Слов – {0},", words);
            Console.WriteLine("Гласных – {0},", vowels);
            Console.WriteLine("Согласных – {0},", consonants);
            Console.WriteLine("Знаков пунктуации – {0},", punctuations);
            Console.WriteLine("Цифр – {0},", digits);
            Console.WriteLine("Других символов – {0}.", other);
        }
    }
}
