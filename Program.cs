//Показать на экране лесенку. Количество ступенек указывает пользователь.

using System;

namespace _1_stairs
{
    class Program
    {
        static void Main()
        {
            //int step;

            Console.WriteLine("Введите количество ступенек:");

            try
            {
                UInt32 step = Convert.ToUInt32(Console.ReadLine());

                if (step < 2)
                {
                    Console.WriteLine("Из этого количества ступеней лестницу не построишь!");
                    Main();
                }

                Console.WriteLine("***");

                for (int i = 0; i < step - 1; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                     Console.Write("  ");
                    }
                    Console.WriteLine("*");

                    for (int j = 0; j <= i; j++)
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine("***");
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Это НЕ число!");
                Main();
            }

            catch(OverflowException)
            {
                Console.WriteLine("Из этого количества ступеней лестницу не построишь!");
                Main();
            }

        }
    }
}
