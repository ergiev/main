/*Создать массив строк на 4000 элементов.
Заполнить римскими цифрами от 1 до 3999.
Показать на экране все элементы.
*/

using System;

namespace _2_1_Arrays1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringArray = new string[4000];

            for (int i = 1; i < 4000; ++i) 
            {
                if (i <= 10) 
                {
                    doDesati(i, i, stringArray);
                }
                else if (i > 10 && i < 101) 
                {
                    doSta(i, i / 10, stringArray);
                    doDesati(i, i % 10, stringArray);
                }
                else if (i > 100 && i < 1001)
                {
                    doTychachi(i, i / 100, stringArray);
                    doSta(i, (i % 100) / 10, stringArray);
                    doDesati(i, (i % 100) % 10, stringArray);
                }
                else if (i > 1000 && i < 4000)
                {
                    bolsheTychachi(i, i / 1000, stringArray);
                    doTychachi(i, (i % 1000) / 100, stringArray);
                    doSta(i, ((i % 1000) % 100) / 10, stringArray);
                    doDesati(i, ((i % 1000) % 100) % 10, stringArray);
                }
            }

            Console.SetBufferSize(Console.BufferWidth, stringArray.Length + 1);

            foreach (string a in stringArray)
            {
                Console.WriteLine(a);
            }
        }

        static void doDesati(int i, int temp, string[] stringArray)
        {
            if (temp == 1) stringArray[i - 1] = stringArray[i - 1] + "I";
            else if (temp == 2) stringArray[i - 1] = stringArray[i - 1] + "II";
            else if (temp == 3) stringArray[i - 1] = stringArray[i - 1] + "III";
            else if (temp == 4) stringArray[i - 1] = stringArray[i - 1] + "IV";
            else if (temp == 5) stringArray[i - 1] = stringArray[i - 1] + "V";
            else if (temp == 6) stringArray[i - 1] = stringArray[i - 1] + "VI";
            else if (temp == 7) stringArray[i - 1] = stringArray[i - 1] + "VII";
            else if (temp == 8) stringArray[i - 1] = stringArray[i - 1] + "VIII";
            else if (temp == 9) stringArray[i - 1] = stringArray[i - 1] + "IX";
            else if (temp == 10) stringArray[i - 1] = stringArray[i - 1] + "X";
        }
        static void doSta(int i, int temp, string[] stringArray)
        {
            if (temp == 1) stringArray[i - 1] = stringArray[i - 1] + "X";
            else if (temp == 2) stringArray[i - 1] = stringArray[i - 1] + "XX";
            else if (temp == 3) stringArray[i - 1] = stringArray[i - 1] + "XXX";
            else if (temp == 4) stringArray[i - 1] = stringArray[i - 1] + "XL";
            else if (temp == 5) stringArray[i - 1] = stringArray[i - 1] + "L";
            else if (temp == 6) stringArray[i - 1] = stringArray[i - 1] + "LX";
            else if (temp == 7) stringArray[i - 1] = stringArray[i - 1] + "LXX";
            else if (temp == 8) stringArray[i - 1] = stringArray[i - 1] + "LXXX";
            else if (temp == 9) stringArray[i - 1] = stringArray[i - 1] + "XC";
            else if (temp == 10) stringArray[i - 1] = stringArray[i - 1] + "C";
        }
        static void doTychachi(int i, int temp, string[] stringArray)
        {
            if (temp == 1) stringArray[i - 1] = stringArray[i - 1] + "C";
            else if (temp == 2) stringArray[i - 1] = stringArray[i - 1] + "CC";
            else if (temp == 3) stringArray[i - 1] = stringArray[i - 1] + "CCC";
            else if (temp == 4) stringArray[i - 1] = stringArray[i - 1] + "CD";
            else if (temp == 5) stringArray[i - 1] = stringArray[i - 1] + "D";
            else if (temp == 6) stringArray[i - 1] = stringArray[i - 1] + "DC";
            else if (temp == 7) stringArray[i - 1] = stringArray[i - 1] + "DCC";
            else if (temp == 8) stringArray[i - 1] = stringArray[i - 1] + "DCCC";
            else if (temp == 9) stringArray[i - 1] = stringArray[i - 1] + "CM";
            else if (temp == 10) stringArray[i - 1] = stringArray[i - 1] + "M";
        }
        static void bolsheTychachi(int i, int temp, string[] stringArray)
        {
            if (temp == 1) stringArray[i - 1] = stringArray[i - 1] + "M";
            else if (temp == 2) stringArray[i - 1] = stringArray[i - 1] + "MM";
            else if (temp == 3) stringArray[i - 1] = stringArray[i - 1] + "MMM";
        }
    }
}