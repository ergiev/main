/*
Дана строка символов. Необходимо проверить, является ли эта строка палиндромом. Примеры палиндромов:

Ешь немытого ты меньше.
А роза упала на лапу Азора.
А роза упала не на лапу Азора.
Лёша на полке клопа нашёл.
У лип Лёша нашёл пилу.
Аргентина манит негра.
Нажал кабан на баклажан.
Я так нежен, Катя.
На вид енот - это не диван!
*/

using System;

namespace _2_4_Strings_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "На вид енот - это не диван!";
            string one = "";
            string two = "";

            foreach(char el in source)
            {
                if(Char.IsLetter(el))
                {
                    one += el;
                }
            }

            foreach (char el in one)
            {
                two = two.Insert(0, el.ToString());
            }

            if (two.Equals(one, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Строка \"{0}\" является палиндромом.", source);
            }
            else
            {
                Console.WriteLine("Строка \"{0}\" не является палиндромом.", source);
            }
        }
    }
}
