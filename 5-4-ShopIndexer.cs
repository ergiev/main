/*
добавить в пример с магазином возможность хранения не только ноутбуков, но также ещё и планшетов, мобильных телефонов, 
зарядок и чехлов. сделать базовый класс для всех устройств, который обладает свойствами Цена, Производитель, Категория, 
ГодВыпуска, Гарантия и Модель.

реализовать возможности:
- поиска по цене в указанном диапазоне (методом),
- поиска по названию модели (с применением индексатора и регулярных выражений),
- поиска по году выпуска (с применением индексатора),
- поиска по типу устройства (например, ищем все ноутбуки).

в результатах поиска должно быть не только первое найденное устройство, а все устройства, подходящие под выбранный критерий.
*/

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

abstract class Device
{
    protected Double price;
    protected String vendor;
    protected String category;
    protected DateTime productionDate;
    protected Byte warranty;
    protected String model;

    public Double Price
    {
        get
        {
            return price;
        }
        set
        {
            if (price > 0) price = value;
        }
    }

    public String Vendor
    {
        get
        {
            return vendor;
        }
        set
        {
            vendor = value;
        }
    }

    public String Category
    {
        get
        {
            return category;
        }
        set
        {
            category = value;
        }
    }

    public DateTime ProductionDate
    {
        get
        {
            return productionDate;
        }
        set
        {
            productionDate = value;
        }
    }

    public Byte Warranty
    {
        get
        {
            return warranty;
        }
        set
        {
            if (warranty > 0) warranty = value;
        }
    }

    public String Model
    {
        get
        {
            return model;
        }
        set
        {
            model = value;
        }
    }
}

class Laptop : Device
{
    public Laptop(Double price, String vendor, String category, DateTime productionDate, Byte warranty, String model)
    {
        this.price = price;
        this.vendor = vendor;
        this.category = category;
        this.productionDate = productionDate;
        this.warranty = warranty;
        this.model = model;
    }

    public override String ToString()
    {
        return "Vendor: " + vendor + ", model: " + model + ", price: $" + price + ", date of production: " 
            + productionDate.ToShortDateString() + ", warranty: " + warranty + " years.";
    }
}

class Tablet : Device
{
    public Tablet(Double price, String vendor, String category, DateTime productionDate, Byte warranty, String model)
    {
        this.price = price;
        this.vendor = vendor;
        this.category = category;
        this.productionDate = productionDate;
        this.warranty = warranty;
        this.model = model;
    }

    public override String ToString()
    {
        return "Vendor: " + vendor + ", model: " + model + ", price: $" + price + ", date of production: "
            + productionDate.ToShortDateString() + ", warranty: " + warranty + " years.";
    }
}

class Smartphone : Device
{
    public Smartphone(Double price, String vendor, String category, DateTime productionDate, Byte warranty, String model)
    {
        this.price = price;
        this.vendor = vendor;
        this.category = category;
        this.productionDate = productionDate;
        this.warranty = warranty;
        this.model = model;
    }

    public override String ToString()
    {
        return "Vendor: " + vendor + ", model: " + model + ", price: $" + price + ", date of production: "
            + productionDate.ToShortDateString() + ", warranty: " + warranty + " years.";
    }
}

class Charger : Device
{
    public Charger(Double price, String vendor, String category, DateTime productionDate, Byte warranty, String model)
    {
        this.price = price;
        this.vendor = vendor;
        this.category = category;
        this.productionDate = productionDate;
        this.warranty = warranty;
        this.model = model;
    }

    public override String ToString()
    {
        return "Vendor: " + vendor + ", model: " + model + ", price: $" + price + ", date of production: "
            + productionDate.ToShortDateString() + ", warranty: " + warranty + " years.";
    }
}

class Case : Device
{
    public Case(Double price, String vendor, String category, DateTime productionDate, Byte warranty, String model)
    {
        this.price = price;
        this.vendor = vendor;
        this.category = category;
        this.productionDate = productionDate;
        this.warranty = warranty;
        this.model = model;
    }

    public override String ToString()
    {
        return "Vendor: " + vendor + ", model: " + model + ", price: $" + price + ", date of production: "
            + productionDate.ToShortDateString() + ", warranty: " + warranty + " years.";
    }
}

//////////////////////////////////////////////////////////////////////////////////////

class Store
{
    private Device[] devices;

    public Store(int size)
    {
        devices = new Device[size];
    }

    public int Length
    {
        get
        {
            return devices.Length;
        }
    }

    public Device this[int index]
    {
        get
        {
            if (index < 0 || index >= devices.Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return devices[index];
            }
        }
        set
        {
            devices[index] = value;
        }
    }

    public Device this[Double price]
    {
        get
        {
            if (price <= 0.0)
            {
                throw new IndexOutOfRangeException();
            }

            return this[FindByPrice(price)];
        }
    }

    public IEnumerable<Device> this[String model]
    {
        get
        {
            if (model.Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            return FindByModel(model);
        }
    }

    private IEnumerable<Device> FindByYear(DateTime year)
    {
        foreach (Device dev in devices)
        {
            if (dev.ProductionDate.Year == year.Year)
            {
                yield return dev;
            }
        }
    }

    public IEnumerable<Device> this[DateTime year]
    {
        get
        {
            return FindByYear(year);
        }
    }

    private IEnumerable<Device> FindByModel(String model)
    {
        foreach (Device dev in devices)
        {
            if (dev.Model == model)
            {
                yield return dev;
            }
        }
    }

    public void FindByModelRE(String pattern)
    {
        RegexOptions option = RegexOptions.IgnoreCase;
        Regex newReg = new Regex(pattern, option);
        MatchCollection matches;
        for (int i = 0; i < devices.Length; i++)
        {
            matches = newReg.Matches(devices[i].Model);
            if (matches.Count > 0)
            {
                Console.WriteLine(devices[i].ToString());
            }
        }
    }

    public Int32 FindByPrice(Double price)
    {
        Int32 result = -1;

        for (Int32 i = 0; i < devices.Length; i++)
        {
            if (devices[i].Price == price)
            {
                result = i;
                break;
            }
        }

        return result;
    }

    public Int32[] FindByPrice(Double priceFrom, Double priceTo)
    {
        Int32 count = 0;

        for (Int32 i = 0; i < devices.Length; i++)
        {
            if (devices[i].Price >= priceFrom && devices[i].Price <= priceTo)
            {
                count++;
            }
        }
        Int32[] result = new Int32[count];

        for (Int32 i = 0, y = 0; i < devices.Length; i++)
        {
            if (devices[i].Price >= priceFrom && devices[i].Price <= priceTo)
            {
                result[y] = i;
                y++;
            }
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Store s = new Store(6);
        s[0] = new Laptop(5700, "Samsung", "Laptops", DateTime.Parse("2015.11.23"), 2, "AAA");
        s[1] = new Tablet(4700.25, "Asus", "Tablets", DateTime.Parse("2016.01.01"), 1, "BBB");
        s[2] = new Smartphone(3700, "HTC", "Smartphones", DateTime.Parse("2015.10.23"), 1, "CCC");
        s[3] = new Charger(150.55, "Hiawei", "Chargers", DateTime.Parse("2016.03.17"), 1, "DDD");
        s[4] = new Case(80, "no name", "Cases", DateTime.Parse("2015.08.08"), 0, "EEE");
        s[5] = new Laptop(6700, "Samsung", "Laptops", DateTime.Parse("2016.06.23"), 2, "DDD");

        //поиск по диапазону цены
        try
        {
            foreach(int el in s.FindByPrice(4000, 6000))
            {
                Console.WriteLine(s[el]);
            }
        }
        catch
        {
            Console.WriteLine("Ничего не найдено!");
        }

        //поиск по модели
        try
        {
            foreach (Device dev in s["DDD"])
            {
                Console.WriteLine(dev);
            }
        }
        catch
        {
            Console.WriteLine("Ничего не найдено!");
        }
        
        //поиск по модели с помощью регулярных выражений
        s.FindByModelRE("D");

        //поиск по году выпуска
        foreach (Device dev in s[DateTime.Parse("2016-01-01")])
        {
            Console.WriteLine(dev);
        }
        
        //поиск по типу 
        for (int i = 0; i < s.Length; i++)
        {
            if(s[i] is Laptop)
                Console.WriteLine(s[i]);
        }
    }
}