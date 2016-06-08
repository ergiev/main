/*
Напишите программу, которая найдет максимальное количество 
цифр, расположенных между двумя девятками в числе Pi. 
Ограничить этот поиск одним миллионом знаков после запятой. 
Например: в начале числа Pi, между двумя девятками находятся 
6 чисел, потом одно и т.д. 3,1415 9 265358 9 7 9 323846 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_4_Strings_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int dig = 10001; //знаки числа пи без точки
            int start = 0;
            int fixstart = 0;
            int end = 0;
            int fixend = 0;
            int diapazon = 0;
            string PI = piSpigot(dig);
            for (int i = 0; i < PI.Length; i++)
            {
                if (PI[i] == '9')
                {
                    if (start == 0)
                    {
                        start = i;
                    }
                    else
                    {
                        end = i;
                        if(end - start - 1 > diapazon)
                        {
                            diapazon = end - start - 1;
                            fixstart = start;
                            fixend = end;
                        }
                        start = end;
                    }
                }
            }

            Console.WriteLine(PI);
            Console.WriteLine();
            Console.WriteLine("Максимальное количество цифр между девятками - {0}. Находятся они между девятками на {1}-м и {2}-м местах после запятой числа ПИ",
                                diapazon.ToString(), (fixstart - 1).ToString(), (fixend - 1).ToString());

        }

        public static String piSpigot(int n)
        {
            // найденные цифры сразу же будем записывать в StringBuilder
            StringBuilder pi = new StringBuilder(n);
            int boxes = n * 10 / 3; // размер массива
            int []reminders = new int[boxes];
            // инициализируем масив двойками
            for (int i = 0; i < boxes; i++)
            {
                reminders[i] = 2;
            }
            int heldDigits = 0;    // счётчик временно недействительных цифр
            for (int i = 0; i < n; i++)
            {
                int carriedOver = 0;    // перенос на следующий шаг
                int sum = 0;
                for (int j = boxes - 1; j >= 0; j--)
                {
                    reminders[j] *= 10;
                    sum = reminders[j] + carriedOver;
                    int quotient = sum / (j * 2 + 1);   // результат деления суммы на знаменатель
                    reminders[j] = sum % (j * 2 + 1);   // остаток от деления суммы на знаменатель
                    carriedOver = quotient * j;   // j - числитель
                }
                reminders[0] = sum % 10;
                int q = sum / 10;   // новая цифра числа Пи
                                    // регулировка недействительных цифр
                if (q == 9)
                {
                    heldDigits++;
                }
                else if (q == 10)
                {
                    q = 0;
                    for (int k = 1; k <= heldDigits; k++)
                    {
                        int replaced = Int32.Parse(pi.ToString(i - k, 1));
                        if (replaced == 9)
                        {
                            replaced = 0;
                        }
                        else
                        {
                            replaced++;
                        }
                        pi.Remove(i - k, 1);
                        pi.Insert(i - k, replaced);
                    }
                    heldDigits = 1;
                }
                else
                {
                    heldDigits = 1;
                }
                pi.Append(q);   // сохраняем найденную цифру
            }
            if (pi.Length >= 2)
            {
                pi.Insert(1, '.');  // добавляем в строчку точку после 3
            }
            return pi.ToString();
        }
    }
}