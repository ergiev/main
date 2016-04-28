/*
Написать программу, которая будет считывать с консоли любое
число и выводить ее в виде большого числа, "нарисованного"
звездочками. Дополнительно: каждая "цифра" должна рисоваться
самой цифрой.
*/

using System;

namespace _3_Digits
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите число:");
            string number = Console.ReadLine();

            Array myArray = Array.CreateInstance(typeof(int), number.Length);

            for (int i = 0; i < number.Length; i++)
            {
                myArray.SetValue((int)Char.GetNumericValue(number[i]), i);
            }

            int x = 0;
            int y = 3;

            for (int i = 0; i < number.Length; i++)
            {
                DrawDigit((int)myArray.GetValue(i), ref x, ref y);
            }

            Console.SetCursorPosition(0, 11);
        }

        static void DrawDigit(int digit, ref int x, ref int y)
        {
            switch (digit)
            {
                case 0:
                    Console.SetCursorPosition(x, y);
                    Console.Write("  000");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(" 0   0");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("0     0");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("0     0");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("0     0");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(" 0   0");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("  000");
                    x += 9;
                    y -= 6;
                    Console.SetCursorPosition(x, y);
                    break;
                case 1:
                    Console.SetCursorPosition(x, y);
                    Console.Write("  1");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(" 11");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("1 1");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("  1");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("  1");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("  1");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("11111");
                    x += 7;
                    y -= 6;
                    Console.SetCursorPosition(x, y);
                    break;
                case 2:
                    Console.SetCursorPosition(x, y);
                    Console.Write(" 222");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("2   2");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("2  2");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("  2");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(" 2");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("2");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("22222");
                    x += 7;
                    y -= 6;
                    Console.SetCursorPosition(x, y);
                    break;
                case 3:
                    Console.SetCursorPosition(x, y);
                    Console.Write("333");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("   3");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("   3");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("333");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("   3");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("   3");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("333");
                    x += 6;
                    y -= 6;
                    Console.SetCursorPosition(x, y);
                    break;
                case 4:
                    Console.SetCursorPosition(x, y);
                    Console.Write("   4");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("  44");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(" 4 4");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("4  4");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("44444");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("   4");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("   4");
                    x += 7;
                    y -= 6;
                    Console.SetCursorPosition(x, y);
                    break;
                case 5:
                    Console.SetCursorPosition(x, y);
                    Console.Write(" 555");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("5");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("5");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(" 555");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("    5");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("    5");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(" 555");
                    x += 7;
                    y -= 6;
                    Console.SetCursorPosition(x, y);
                    break;
                case 6:
                    Console.SetCursorPosition(x, y);
                    Console.Write(" 666");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("6");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("6");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("6666");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("6   6");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("6   6");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("6666");
                    x += 7;
                    y -= 6;
                    Console.SetCursorPosition(x, y);
                    break;
                case 7:
                    Console.SetCursorPosition(x, y);
                    Console.Write("77777");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("    7");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("   7");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("  7");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(" 7");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("7");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("7");
                    x += 7;
                    y -= 6;
                    Console.SetCursorPosition(x, y);
                    break;
                case 8:
                    Console.SetCursorPosition(x, y);
                    Console.Write(" 888");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("8   8");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("8   8");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(" 888");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("8   8");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("8   8");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(" 888");
                    x += 7;
                    y -= 6;
                    Console.SetCursorPosition(x, y);
                    break;
                case 9:
                    Console.SetCursorPosition(x, y);
                    Console.Write(" 9999");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("9   9");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("9   9");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(" 9999");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("    9");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write("    9");
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(" 999");
                    x += 7;
                    y -= 6;
                    Console.SetCursorPosition(x, y);
                    break;
            }
        }
    }
}