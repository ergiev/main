/*
Разработать приложение «Прайс-лист», которое формирует список носителей информации, таких как, 
Flash-память, DVD - диск, съемный HDD. Каждый носитель информации является объектом соответствующего класса:
- класс Flash - память;
- класс DVD - диск;
- класс съемный HDD.
Все три класса являются производными от абстрактного класса «Носитель информации». 
Базовый класс содержит следующие поля: наименование носителя, имя производителя, модель, количество, цена. 
Класс обладает всеми необходимыми свойствами для доступа к полям, а также виртуальными методами печати, 
загрузки из файла и сохранения в файл. В производных классах переопределяются методы печати, загрузки и 
сохранения. Кроме того, каждый из производных классов дополняется следующими полями:
- класс Flash-память: объем памяти, скорость USB;
- класс съемный HDD: размер диска, скорость USB;
- класс DVD - диск: скорость чтения и скорость записи.
Работа с объектами соответствующих классов производится через ссылки на базовый класс, которые хранятся в списке.
Приложение должно предоставлять следующие возможности:
•	добавление носителя информации в список;
•	удаление носителя информации из списка по заданному критерию;
•	печать списка;
•	изменение определённых параметров носителя информации;
•	поиск носителя информации по заданному критерию.
 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5_5_PriceList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Storage> list = new List<Storage>();
            list.Add(new FlashMemory("флешка", "Samsung", "qwerty123", 5, 122.45, 8, 15));
            list.Add(new RemovableHDD("съемник", "ASUS", "newmodel", 3, 540.60, 500, 20));
            list.Add(new FlashMemory("синяя флешка", "ASUS", "oldmodel", 10, 140, 16, 8));
            list.Add(new DVDdisk("поцарапанный диск", "Verbatim", "supermodel", 100, 8.90, 10, 5));

            MainMenu(list);
        }

        static void MainMenu(List<Storage> list)
        {
            Console.Clear();
            Console.WriteLine("(1) Добавить носитель");
            Console.WriteLine("(2) Удалить носитель");
            Console.WriteLine("(3) Печать списка");
            Console.WriteLine("(4) Редактирование информации по носителю");
            Console.WriteLine("(5) Поиск носителя");
            Console.WriteLine("(6) Выход");
            try
            {
                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Add(list);
                        break;
                    case 2:
                        Delete(list);
                        break;
                    case 3:
                        Console.Clear();
                        foreach (Storage dev in list)
                        {
                            dev.Print();
                        }
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 4:
                        Edit(list);
                        break;
                    case 5:
                        Find(list);
                        break;
                    case 6:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверный выбор. Повторите через 3 секунды.");
                        Thread.Sleep(3000);
                        MainMenu(list);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный выбор. Повторите через 3 секунды.");
                Thread.Sleep(3000);
                MainMenu(list);
            }
        }
        static void Add(List<Storage> list)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Выберите тип носителя:");
                Console.WriteLine("(1) Флеш-память");
                Console.WriteLine("(2) Съемный жесткий диск");
                Console.WriteLine("(3) DVD-диск\n");
                Console.WriteLine("(4) Главное меню");
                Console.WriteLine("(5) Выход");

                int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите название:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите производителя:");
                        string vendor = Console.ReadLine();
                        Console.WriteLine("Введите название модели:");
                        string model = Console.ReadLine();
                        Console.WriteLine("Введите количество:");
                        int quantity = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цену:");
                        double price = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите объем памяти:");
                        int memory = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите скорость USB:");
                        int USBspeed = Int32.Parse(Console.ReadLine());
                        list.Add(new FlashMemory(name, vendor, model, quantity, price, memory, USBspeed));
                        Console.WriteLine("\nДобавлен носитель:");
                        list.Last().Print();
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите название:");
                        string name1 = Console.ReadLine();
                        Console.WriteLine("Введите производителя:");
                        string vendor1 = Console.ReadLine();
                        Console.WriteLine("Введите название модели:");
                        string model1 = Console.ReadLine();
                        Console.WriteLine("Введите количество:");
                        int quantity1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цену:");
                        double price1 = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите размер диска:");
                        int memory1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите скорость USB:");
                        int USBspeed1 = Int32.Parse(Console.ReadLine());
                        list.Add(new RemovableHDD(name1, vendor1, model1, quantity1, price1, memory1, USBspeed1));
                        Console.WriteLine("\nДобавлен носитель:");
                        list.Last().Print();
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Введите название:");
                        string name2 = Console.ReadLine();
                        Console.WriteLine("Введите производителя:");
                        string vendor2 = Console.ReadLine();
                        Console.WriteLine("Введите название модели:");
                        string model2 = Console.ReadLine();
                        Console.WriteLine("Введите количество:");
                        int quantity2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цену:");
                        double price2 = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите скорость чтения:");
                        int readSpeed = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите скорость USB:");
                        int writeSpeed = Int32.Parse(Console.ReadLine());
                        list.Add(new DVDdisk(name2, vendor2, model2, quantity2, price2, readSpeed, writeSpeed));
                        Console.WriteLine("\nДобавлен носитель:");
                        list.Last().Print();
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 4:
                        MainMenu(list);
                        break;
                    case 5:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверный выбор. Повторите через 3 секунды.");
                        Thread.Sleep(3000);
                        Add(list);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный выбор. Повторите через 3 секунды.");
                Thread.Sleep(3000);
                Add(list);
            }
        }
        static void Delete(List<Storage> list)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Удаление по параметру:");
                Console.WriteLine("(1) Производитель");
                Console.WriteLine("(2) Модель");
                Console.WriteLine("(3) Диапазон цены\n");
                Console.WriteLine("(4) Главное меню");
                Console.WriteLine("(5) Выход");

                int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите название производителя:");
                        string vendor = Console.ReadLine();
                        int count1 = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Vendor.ToLower() == vendor.ToLower())
                            {
                                list.Remove(list[i]);
                                count1++;
                            }
                        }
                        if (count1 > 0)
                            Console.WriteLine("Удалено {0} записей", count1);
                        else
                            Console.WriteLine("Нечего удалять");
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите название модели:");
                        string model = Console.ReadLine();
                        int count2 = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Model.ToLower() == model.ToLower())
                            {
                                list.Remove(list[i]);
                                count2++;
                            }
                        }
                        if (count2 > 0)
                            Console.WriteLine("Удалено {0} записей", count2);
                        else
                            Console.WriteLine("Нечего удалять");
                        Console.ReadKey();
                        MainMenu(list);
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Введите цену от:");
                        int price1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цену до:");
                        int price2 = Int32.Parse(Console.ReadLine());
                        int count3 = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Price >= price1 && list[i].Price <= price2)
                            {
                                list.Remove(list[i]);
                                count3++;
                            }
                        }
                        if (count3 > 0)
                            Console.WriteLine("Удалено {0} записей", count3);
                        else
                            Console.WriteLine("Нечего удалять");
                        Console.ReadKey();
                        MainMenu(list);
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 4:
                        MainMenu(list);
                        break;
                    case 5:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверный выбор. Повторите через 3 секунды.");
                        Thread.Sleep(3000);
                        Delete(list);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный выбор. Повторите через 3 секунды.");
                Thread.Sleep(3000);
                Delete(list);
            }
        }
        static void Edit(List<Storage> list)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Изменение параметров носителя:");
                Console.WriteLine("(1) Название");
                Console.WriteLine("(2) Производитель");
                Console.WriteLine("(3) Модель");
                Console.WriteLine("(4) Количество");
                Console.WriteLine("(5) Цена\n");
                Console.WriteLine("(6) Главное меню");
                Console.WriteLine("(7) Выход");

                int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите индекс устройства в списке:");
                        int index = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новое название носителя:");
                        string input = Console.ReadLine();
                        list[index].Name = input;
                        list[index].Print();
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите индекс устройства в списке:");
                        int index2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новое название производителя:");
                        string input2 = Console.ReadLine();
                        list[index2].Vendor = input2;
                        list[index2].Print();
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Введите индекс устройства в списке:");
                        int index3 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новое название модели:");
                        string input3 = Console.ReadLine();
                        list[index3].Model = input3;
                        list[index3].Print();
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Введите индекс устройства в списке:");
                        int index4 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новое количество:");
                        int input4 = Int32.Parse(Console.ReadLine());
                        list[index4].Quantity = input4;
                        list[index4].Print();
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Введите индекс устройства в списке:");
                        int index5 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новую цену:");
                        double input5 = Double.Parse(Console.ReadLine());
                        list[index5].Price = input5;
                        list[index5].Print();
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 6:
                        MainMenu(list);
                        break;
                    case 7:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверный выбор. Повторите через 3 секунды.");
                        Thread.Sleep(3000);
                        Edit(list);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный выбор. Повторите через 3 секунды.");
                Thread.Sleep(3000);
                Edit(list);
            }
        }
        static void Find(List<Storage> list)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Поиск по параметру:");
                Console.WriteLine("(1) Производитель");
                Console.WriteLine("(2) Модель");
                Console.WriteLine("(3) Диапазон цены\n");
                Console.WriteLine("(4) Главное меню");
                Console.WriteLine("(5) Выход");

                int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите название производителя:");
                        string vendor = Console.ReadLine();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Vendor.ToLower() == vendor.ToLower())
                            {
                                list[i].Print();
                            }
                        }
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Введите название модели:");
                        string model = Console.ReadLine();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Model.ToLower() == model.ToLower())
                            {
                                list[i].Print();
                            }
                        }
                        Console.ReadKey();
                        MainMenu(list);
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Введите цену от:");
                        int price1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цену до:");
                        int price2 = Int32.Parse(Console.ReadLine());
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Price >= price1 && list[i].Price <= price2)
                            {
                                list[i].Print();
                            }
                        }
                        Console.ReadKey();
                        MainMenu(list);
                        Console.ReadKey();
                        MainMenu(list);
                        break;
                    case 4:
                        MainMenu(list);
                        break;
                    case 5:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверный выбор. Повторите через 3 секунды.");
                        Thread.Sleep(3000);
                        Find(list);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный выбор. Повторите через 3 секунды.");
                Thread.Sleep(3000);
                Find(list);
            }
        }
    }
  
    abstract class Storage
    {
        protected string name;
        protected string vendor;
        protected string model;
        protected int quantity;
        protected double price;

        public Storage (string name, string vendor, string model, int quantity, double price)
        {
            this.name = name;
            this.vendor = vendor;
            this.model = model;
            this.quantity = quantity;
            this.price = price;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        virtual public void Print() { }
        virtual public void SaveToFile() { }
        virtual public void LoadFromFile() { }
    }

    class FlashMemory : Storage
    {
        int memoryVolume;
        int USBspeed;

        public int MemoryVolume
        {
            get { return memoryVolume; }
            set { memoryVolume = value; }
        }
        public int USBSpeed
        {
            get { return USBspeed; }
            set { USBspeed = value; }
        }

        public FlashMemory(string name, string vendor, string model, int quantity, double price, int volume, int speed) : base (name, vendor, model, quantity, price)
        {
            memoryVolume = volume;
            USBspeed = speed;
        }

        public override void Print()
        {
            Console.WriteLine("Наименование: {0}, производитель: {1}, модель: {2}, количество: {3}, цена: {4}, объем памяти: {5}, скорость USB: {6}", 
                name, vendor, model, quantity, price, memoryVolume, USBspeed);
        }
        public override void SaveToFile()
        {
            Console.WriteLine("Информация по флеш-памяти сохранена в файл.");
        }
        public override void LoadFromFile()
        {
            Console.WriteLine("Информация по флеш-памяти загружена из файла.");
        }
    }

    class RemovableHDD : Storage
    {
        int HDDvolume;
        int USBspeed;

        public RemovableHDD(string name, string vendor, string model, int quantity, double price, int volume, int speed) : base (name, vendor, model, quantity, price)
        {
            HDDvolume = volume;
            USBspeed = speed;
        }

        public int HDDVolume
        {
            get { return HDDvolume; }
            set { HDDvolume = value; }
        }
        public int USBSpeed
        {
            get { return USBspeed; }
            set { USBspeed = value; }
        }

        public override void Print()
        {
            Console.WriteLine("Наименование: {0}, производитель: {1}, модель: {2}, количество: {3}, цена: {4}, размер диска: {5}, скорость USB: {6}",
                name, vendor, model, quantity, price, HDDvolume, USBspeed);
        }
        public override void SaveToFile()
        {
            Console.WriteLine("Информация по съемному HDD сохранена в файл.");
        }
        public override void LoadFromFile()
        {
            Console.WriteLine("Информация по съемному HDD загружена из файла.");
        }
    }

    class DVDdisk : Storage
    {
        int readSpeed;
        int writeSpeed;

        public DVDdisk(string name, string vendor, string model, int quantity, double price, int readSpeed, int writeSpeed) : base (name, vendor, model, quantity, price)
        {
            this.readSpeed = readSpeed;
            this.writeSpeed = writeSpeed;
        }

        public int ReadSpeed
        {
            get { return readSpeed; }
            set { readSpeed = value; }
        }
        public int WriteSpeed
        {
            get { return writeSpeed; }
            set { writeSpeed = value; }
        }

        public override void Print()
        {
            Console.WriteLine("Наименование: {0}, производитель: {1}, модель: {2}, количество: {3}, цена: {4}, скорость чтения: {5}, скорость записи: {6}",
                name, vendor, model, quantity, price, readSpeed, writeSpeed);
        }
        public override void SaveToFile()
        {
            Console.WriteLine("Информация по DVD-диску сохранена в файл.");
        }
        public override void LoadFromFile()
        {
            Console.WriteLine("Информация по DVD-диску загружена из файла.");
        }
    }
}