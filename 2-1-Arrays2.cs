/*Ввести число в диапазоне от 0 до 1000000.
Озвучить его словами. Например, при вводе числа
35 показать на экране "двадцать пять".
*/

using System;

namespace _2_1_Arrays2
{
    class Program
    {
        static void Main()
        {
            string[] ot0do9 = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять", "ноль", "одна", "две" };
            string[] ot10do19 = { "ноль", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
            string[] ot20do90 = { "ноль", "ноль", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
            string[] ot100do900 = { "ноль", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
            string[] tichachiMillion = { "миллион", "тысяча", "тысячи", "тысяч" };

            Console.WriteLine("Введите число от 0 до 1 000 000:");

            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0 || number > 1000000)
                {
                    Console.WriteLine("Число не из диапазона!");
                    Main();
                }

                if (number==0)
                {
                    Console.WriteLine(ot0do9[0]);
                }
                else if ((number / 1000000) > 0)
                {
                    Console.WriteLine(ot0do9[1] + ' ' + tichachiMillion[0]);
                }
                else 
                {
                    int temp = number / 1000; //работаем с тысячами
                    if (temp / 100 > 0)
                    {
                        Console.Write(ot100do900[temp / 100] + ' ');
                    }
                    if (temp % 100 > 4 && temp % 100 < 10)
                    {
                        Console.Write(ot0do9[temp % 100] + ' ' + tichachiMillion[3]);
                    }
                    else if (temp % 100 == 1)
                    {
                        Console.Write(ot0do9[temp % 100 + 10] + ' ' + tichachiMillion[1]);
                    }
                    else if (temp % 100 == 2)
                    {
                        Console.Write(ot0do9[temp % 100 + 10] + ' ' + tichachiMillion[2]);
                    }
                    else if (temp % 100 > 2 && temp % 100 < 5)
                    {
                        Console.Write(ot0do9[temp % 100] + ' ' + tichachiMillion[2]);
                    }
                    else if (temp % 100 > 10 && temp % 100 < 20)
                    {
                        Console.Write(ot10do19[(temp % 100) % 10] + ' ' + tichachiMillion[3]);
                    }
                    else
                    {
                        if ((temp % 100) / 10 > 0)
                        {
                            Console.Write(ot20do90[(temp % 100) / 10] + ' ');
                        }
                        
                        if (((temp % 100) % 10) > 0)
                        {
                            Console.Write(ot0do9[(temp % 100) % 10] + ' ' + tichachiMillion[3]);
                        }
                        else if (temp > 0)
                        {
                            Console.Write(tichachiMillion[3]);
                        }
                    }
                    if (temp>0)
                    {
                        Console.Write(' ');
                    }
                    temp = number % 1000;//работаем до 1000
                    
                    if (temp / 100 > 0) 
                    {
                        Console.Write(ot100do900[temp / 100]);
                    }
                    if (temp % 100 > 0 && temp % 100 < 10)
                    {
                        Console.Write(ot0do9[temp % 100]);
                    }
                    else if (temp % 100 > 10 && temp % 100 < 20)
                    {
                        Console.Write(ot10do19[(temp % 100) % 10]);
                    }
                    else
                    {
                        if ((temp % 100) / 10 > 0)
                        {
                            Console.Write(' ' + ot20do90[(temp % 100) / 10] + ' ');
                        }
                        if (((temp % 100) % 10) > 0)
                        {
                            Console.Write(ot0do9[(temp % 100) % 10]);
                        }
                    }
                }
      
                Console.WriteLine();
            }
            catch(FormatException)
            {
                Console.WriteLine("Это не число!");
                Main();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Число не из диапазона!");
                Main();
            }
        }
    }
}
