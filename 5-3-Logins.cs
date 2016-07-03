/*
создать класс-коллекцию логинов и паролей.
сделать в классе свойство Count.

реализовать возможности:
- просмотра существующих логинов,
- добавления нового пользователя,
- удаления пользователя по логину,
- редактирования пользователя по логину.

пароли хранить в зашифрованном виде (например, применить XOR).

для тестирования возможностей класса реализовать меню.

применить индексаторы (например, при просмотре пользователей).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_3_Logins
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection A = new MyCollection(5);
            A.AddUser("mylogin1", "mypass1");
            A.AddUser("mylogin2", "mypass2");
            A.AddUser("mylogin3", "mypass3");
            A.ShowLogins();
            

            int input = 0;
            string log;
            string pas;

            while (input != 5)
            {
                Console.Clear();
                Console.WriteLine("---КОЛЛЕКЦИЯ ЛОГИНОВ---");
                Console.WriteLine();
                Console.WriteLine("----------МЕНЮ----------");
                Console.WriteLine();
                Console.WriteLine("(1) Посмотреть все логины");
                Console.WriteLine("(2) Добавить нового пользователя");
                Console.WriteLine("(3) Удалить пользователя");
                Console.WriteLine("(4) Редактировать пользователя");
                Console.WriteLine("(5) Выход");
                Console.WriteLine();
                Console.Write("Ваш выбор? ");

                input = Int32.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        A.ShowLogins();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите логин: ");
                        log = Console.ReadLine();
                        Console.WriteLine("Введите пароль: ");
                        pas = Console.ReadLine();
                        A.AddUser(log, pas);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Введите логин: ");
                        log = Console.ReadLine();
                        A.DeleteUser(log);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Введите логин: ");
                        log = Console.ReadLine();
                        A.EditUser(log);
                        Console.ReadLine();
                        break;
                 }
            }
        }
    }
}

    class User
    {
        private string login;
        private string pass;
        private int key;

        public User()
        {
            key = 18;
            login = "login";
            pass = Encrypt ("password", key);
        }

        public User(string log, string pas) : this()
        {
            login = log;
            pass = Encrypt(pas, key);
        }

        public User(string log, string pas, int k) : this()
        {
            key = k;
            login = log;
            pass = Encrypt(pas, key);
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Pass
        {
            get { return Decrypt(pass, key); }
            set { pass = Encrypt (value, key); }
        }

        private int Key
        {
            get { return key; }
            set { key = value; }
        }

        private static string Encrypt(string message, int key)
        {
            string result = "";
            for (int i = 0; i < message.Length; i++)
                result += (char)(message[i] ^ key);
            return result;
        }
        private static string Decrypt(string message, int key)
        {
            return Encrypt(message, key);
        }

        public override string ToString()
        {
            return login;
        }
    }

    class MyCollection
    {
        private int count;
        private User[] array;

        public MyCollection(int x)
        {
            if (x > 0)
            {
                array = new User[x];
            }
            else
                throw new Exception("Больше нуля вводи, да?");
        }

        public int Count
        {
            get { return count; }
            private set { count = value; }
        }

        public int Length
        {
            get { return array.Length; }
        }

        public void ShowLogins()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                    Console.WriteLine(array[i].Login);
            }
        }
        public void AddUser(string login, string pass)
        {
            if (count >= array.Length)
            {
                User[] temp = new User[array.Length + 5];
                for (int i = 0; i < array.Length; i++)
                {
                    temp[i] = array[i];
                }
                array = temp;
            }
            array[count] = new User(login, pass);
            count++;
            Console.WriteLine("Текущий список:");
            ShowLogins();
        }

        public void DeleteUser(string login)
        {
            bool flag = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                    break;

                if (array[i].Login == login)
                {
                    flag = true;
                    array[i] = null;
                    for (int j = i; j < array.Length - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    count--;
                }
                    
            }
            if (flag == false) 
            {
                Console.WriteLine("Логин {0} в коллекции не найден!", login);
            }

            //уплотняем массив, если свободных ячеек более пяти
            if ((array.Length - count) > 5)
            {
                User[] temp = new User[array.Length - 5];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = array[i];
                }
                array = temp;
            }

            Console.WriteLine("Текущий список:");
            ShowLogins();
        }

        public void EditUser(string login)
        {
            bool flag = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                    break;

                if (array[i].Login == login)
                {
                    flag = true;
                    Console.WriteLine("Логин {0} найден!", login);
                    Console.WriteLine("Введите новый логин:");
                    array[i].Login = Console.ReadLine();
                    Console.WriteLine("Введите новый пароль:");
                    array[i].Pass = Console.ReadLine();
                    Console.WriteLine("Данные успешно изменены!");
                }

            }
            if (flag == false)
            {
                Console.WriteLine("Логин {0} в коллекции не найден!", login);
            }

            Console.WriteLine("Текущий список:");
            ShowLogins();
        }

        public User this[int i]
        {
            get
            {
                if (i >= array.Length || i < 0)
                    throw new IndexOutOfRangeException("Нет такого индекса");
                //if (i >= count)
                    //Console.WriteLine("По этому индексу пусто");
                return array[i];
            }
            set
            {
                if (i >= array.Length || i < 0)
                    throw new IndexOutOfRangeException("Нет такого индекса");
                array[i] = value;
            }
        }
    }
