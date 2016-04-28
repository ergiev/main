/*
Нарисовать ёлочку.
С клавиатуры вводится количество ярусов и высота каждого яруса.
*/

using System;

namespace _2_NewYearTree
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Введите количество ярусов (не менее 3-х):");
                uint tier = Convert.ToUInt32(Console.ReadLine());
                Console.WriteLine("Введите высоту яруса (не менее 3-х):");
                uint height = Convert.ToUInt32(Console.ReadLine());

                if (tier < 3 || height < 3)
                {
                    Console.WriteLine("Введите число побольше, чтобы елочка была красивее!");
                    Main();
                }

                //определяем базовую ширину (нижнего ряда первого яруса)
                uint width = height + (height - 1);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;

                for (int x = 0; x < tier; x++)
                {
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width - height - i + (tier - x - 1); j++)
                        {
                            Console.Write(" ");
                        }
                        for (int j = 0; j < i + (i + 1) + x * 2; j++)
                        {
                            Console.Write("@");
                        }
                        Console.WriteLine();
                    }
                }

                //ножка
                Console.ForegroundColor = ConsoleColor.DarkRed;

                for (int i = 0; i < tier; i++)
                {
                    for (int j = 0; j < width - height + (tier - 2); j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("###");
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Это НЕ число!");
                Main();
            }

            catch (OverflowException)
            {
                Console.WriteLine("Из этого числа ёлочка не вырастит!");
                Main();
            }
        }
    }
}