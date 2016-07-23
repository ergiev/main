/*
1. сделать так, чтобы класс Student реализовал интерфейс IComparable.
сделать в нём вложенные классы, реализующие  интерфейс IComparer (для сортировки по различным критериям).

2.сделать так, чтобы класс Group реализовал интерфейс IEnumerable.
добавить в класс метод печати группы Print, используя конструкцию foreach.
сделать метод Sort для сортировки по заданному критерию.
сделать метод Search для поиска студента по заданному критерию.

3. реализовать интерфейс IEnumerable для класса Student - перебираются все компоненты 
(поля, свойства, методы и тд), на экране отображаются идентификаторы компонентов и их 
текущие значения (для полей и свойств).
*/

using System;
using System.Collections;
using System.Threading;
using System.Reflection;

namespace _6_1_Student_Group_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(Console.BufferWidth, 32766);
            //Group group = new Group();
            //group.Sort();
            //group.Print();
            //group.Search("Иванов");

            Student s = new Student();
            foreach (var x in s)
            {
                Console.WriteLine(x);
            }
        }
    }

    class Student : IComparable//, IEnumerable
    {
        private string firstName;
        private string secondName;
        private string patronymic;
        private DateTime dateBirth;
        private string address;
        private string phone;

        private string[,] credit;
        private string[,] course;
        private string[,] exam;

        public Student()
        {
            firstName = "Максим";
            secondName = "Ергиев";
            patronymic = "Григорьевич";
            dateBirth = new DateTime(1979, 03, 26);
            address = "Одесса";
            phone = "0674852269";
            credit = new string[3, 2];
            credit[0, 0] = "Зачет 1";
            credit[1, 0] = "Зачет 2";
            credit[2, 0] = "Зачет 3";
            credit[0, 1] = "нет";
            credit[1, 1] = "нет";
            credit[2, 1] = "нет";
            course = new string[3, 2];
            course[0, 0] = "Курсовая 1";
            course[1, 0] = "Курсовая 2";
            course[2, 0] = "Курсовая 3";
            course[0, 1] = "нет";
            course[1, 1] = "нет";
            course[2, 1] = "нет";
            exam = new string[3, 2];
            exam[0, 0] = "Экзамен 1";
            exam[1, 0] = "Экзамен 2";
            exam[2, 0] = "Экзамен 3";
            exam[0, 1] = "нет";
            exam[1, 1] = "нет";
            exam[2, 1] = "нет";
        }

        public Student(string firstName, string secondName, string patronymic)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.patronymic = patronymic;
            credit = new string[3, 2];
            credit[0, 0] = "Зачет 1";
            credit[1, 0] = "Зачет 2";
            credit[2, 0] = "Зачет 3";
            credit[0, 1] = "нет";
            credit[1, 1] = "нет";
            credit[2, 1] = "нет";
            course = new string[3, 2];
            course[0, 0] = "Курсовая 1";
            course[1, 0] = "Курсовая 2";
            course[2, 0] = "Курсовая 3";
            course[0, 1] = "нет";
            course[1, 1] = "нет";
            course[2, 1] = "нет";
            exam = new string[3, 2];
            exam[0, 0] = "Экзамен 1";
            exam[1, 0] = "Экзамен 2";
            exam[2, 0] = "Экзамен 3";
            exam[0, 1] = "нет";
            exam[1, 1] = "нет";
            exam[2, 1] = "нет";
        }

        public Student(string firstName, string secondName, string patronymic, string address, string phone)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.patronymic = patronymic;
            this.address = address;
            this.phone = phone;
            credit = new string[3, 3];
            credit[0, 0] = "Зачет 1";
            credit[1, 0] = "Зачет 2";
            credit[2, 0] = "Зачет 3";
            credit[0, 1] = "нет";
            credit[1, 1] = "нет";
            credit[2, 1] = "нет";
            course = new string[3, 2];
            course[0, 0] = "Курсовая 1";
            course[1, 0] = "Курсовая 2";
            course[2, 0] = "Курсовая 3";
            course[0, 1] = "нет";
            course[1, 1] = "нет";
            course[2, 1] = "нет";
            exam = new string[3, 2];
            exam[0, 0] = "Экзамен 1";
            exam[1, 0] = "Экзамен 2";
            exam[2, 0] = "Экзамен 3";
            exam[0, 1] = "нет";
            exam[1, 1] = "нет";
            exam[2, 1] = "нет";
        }

        public Student(string firstName, string secondName, string patronymic, int year, int month, int day, string address, string phone)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.patronymic = patronymic;
            dateBirth = new DateTime(year, month, day);
            this.address = address;
            this.phone = phone;
            credit = new string[3, 3];
            credit[0, 0] = "Зачет 1";
            credit[1, 0] = "Зачет 2";
            credit[2, 0] = "Зачет 3";
            credit[0, 1] = "нет";
            credit[1, 1] = "нет";
            credit[2, 1] = "нет";
            course = new string[3, 2];
            course[0, 0] = "Курсовая 1";
            course[1, 0] = "Курсовая 2";
            course[2, 0] = "Курсовая 3";
            course[0, 1] = "нет";
            course[1, 1] = "нет";
            course[2, 1] = "нет";
            exam = new string[3, 2];
            exam[0, 0] = "Экзамен 1";
            exam[1, 0] = "Экзамен 2";
            exam[2, 0] = "Экзамен 3";
            exam[0, 1] = "нет";
            exam[1, 1] = "нет";
            exam[2, 1] = "нет";
        }

        public string FirstName
        {
            set
            {
                firstName = value;
            }
            get
            {
                return firstName;
            }
        }
        public string SecondName
        {
            set
            {
                secondName = value;
            }
            get
            {
                return secondName;
            }
        }
        public int Age
        {
            set
            {
                int age = value;
                dateBirth = new DateTime(DateTime.Now.Year - age, 0, 0);
            }
            get
            {
                return DateTime.Now.Year - dateBirth.Year;
            }
        }

        public string getFirstName()
        {
            return firstName;
        }
        public string getSecondName()
        {
            return secondName;
        }
        public string getPatronymic()
        {
            return patronymic;
        }
        public DateTime getDateBirth()
        {
            return dateBirth;
        }
        public string getAddress()
        {
            return address;
        }
        public string getPhone()
        {
            return phone;
        }
        public string[,] getCredits()
        {
            return credit;
        }
        public string[,] getCourses()
        {
            return course;
        }
        public string[,] getExams()
        {
            return exam;
        }

        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }
        public void setSecondName(string secondName)
        {
            this.secondName = secondName;
        }
        public void setPantonymic(string patronymic)
        {
            this.patronymic = patronymic;
        }
        public void setDateBirth(int year, int month, int day)
        {
            dateBirth = new DateTime(year, month, day);
        }
        public void setDateBirth(DateTime date)
        {
            dateBirth = new DateTime(date.Year, date.Month, date.Day);
        }
        public void setAddress(string address)
        {
            this.address = address;
        }
        public void setPhone(string phone)
        {
            this.phone = phone;
        }

        public void setFirstCredit(string first)
        {
            credit[0, 1] = first;
        }
        public void setSecondCredit(string second)
        {
            credit[1, 1] = second;
        }
        public void setThirdCredit(string third)
        {
            credit[2, 1] = third;
        }

        public void setFirstCourse(string first)
        {
            course[0, 1] = first;
        }
        public void setSecondCourse(string second)
        {
            course[1, 1] = second;
        }
        public void setThirdCourse(string third)
        {
            course[2, 1] = third;
        }

        public void setFirstExam(string first)
        {
            exam[0, 1] = first;
        }
        public void setSecondExam(string second)
        {
            exam[1, 1] = second;
        }
        public void setThirdExam(string third)
        {
            exam[2, 1] = third;
        }

        public void showAllInfo()
        {
            Console.WriteLine("ФИО студента: {1} {0} {2}", firstName, secondName, patronymic);
            Console.WriteLine("Дата рождения: {0}", dateBirth.ToShortDateString());
            Console.WriteLine("Домашний адрес: {0}", address);
            Console.WriteLine("Контактный телефон: {0}", phone);
            Console.WriteLine();
            Console.WriteLine("Зачеты:");
            Console.WriteLine("{0}: оценка - {1}", credit[0, 0], credit[0, 1]);
            Console.WriteLine("{0}: оценка - {1}", credit[1, 0], credit[1, 1]);
            Console.WriteLine("{0}: оценка - {1}", credit[2, 0], credit[2, 1]);
            Console.WriteLine();
            Console.WriteLine("Курсовые работы:");
            Console.WriteLine("{0}: оценка - {1}", course[0, 0], course[0, 1]);
            Console.WriteLine("{0}: оценка - {1}", course[1, 0], course[1, 1]);
            Console.WriteLine("{0}: оценка - {1}", course[2, 0], course[2, 1]);
            Console.WriteLine();
            Console.WriteLine("Экзамены:");
            Console.WriteLine("{0}: оценка - {1}", exam[0, 0], exam[0, 1]);
            Console.WriteLine("{0}: оценка - {1}", exam[1, 0], exam[1, 1]);
            Console.WriteLine("{0}: оценка - {1}", exam[2, 0], exam[2, 1]);
            Console.WriteLine();
        }

        // реализация интерфейса IComparable

        public int CompareTo(object obj)
        {
            return SecondName.CompareTo(obj);
        }

        //IComparer

        public class SortByFirstName : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Student m1 = (Student)ob1;
                Student m2 = (Student)ob2;
                return String.Compare(m1.firstName, m2.firstName);
            }
        }
        public class SortBySecondName : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Student m1 = (Student)ob1;
                Student m2 = (Student)ob2;
                return String.Compare(m1.secondName, m2.secondName);
            }
        }
        public class SortByPatronymic : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Student m1 = (Student)ob1;
                Student m2 = (Student)ob2;
                return String.Compare(m1.patronymic, m2.patronymic);
            }
        }
        public class SortByDateBirth : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Student m1 = (Student)ob1;
                Student m2 = (Student)ob2;
                return DateTime.Compare(m1.dateBirth, m2.dateBirth);
            }
        }

        /*
 реализовать интерфейс IEnumerable для класса Student - перебираются все компоненты 
(поля, свойства, методы и тд), на экране отображаются идентификаторы компонентов и их 
текущие значения (для полей и свойств).
Student s = new Student();
foreach (var x in s) {
	Console.WriteLine(x); // на экране пара "идентификатор - значение"
} 
*/

        //реализация интерфейса IEnumerable

        public StudentEnumerator GetEnumerator()
        {
            FieldInfo[] fields = typeof(Student).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            MethodInfo[] methods = typeof(Student).GetMethods();
            PropertyInfo[] properties = typeof(Student).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            string[] allDataName = new string[fields.Length + methods.Length + properties.Length];

            for (int i = 0; i < fields.Length; i++)
            {
                allDataName[i] = fields[i].Name + " - " + fields[i].GetValue(this);
            }
            for (int i = 0; i < methods.Length; i++)
            {
                allDataName[i+ fields.Length] = methods[i].Name;
            }
            for (int i = 0; i < properties.Length; i++)
            {
                allDataName[i + fields.Length + methods.Length] = properties[i].Name + " - " + properties[i].GetValue(this); 
            }
            return new StudentEnumerator(allDataName);
        }
    }

    class StudentEnumerator
    {
        string[] List;
        int position = -1;

        public StudentEnumerator(string[] allMethods)
        {
            List = allMethods;
        }

        public bool MoveNext()
        {
            position++;
            return (position < List.Length);
        }

        public string Current
        {
            get
            {
                return List[position];
            }
        }
    }

    class Group : IEnumerable
    {
        Student[] array;
        int people = 0;
        string name;
        string specialisation;
        int course;
        static string[] names = {"Александр", "Дмитрий", "Максим", "Даниил", "Кирилл", "Ярослав", "Денис",
            "Никита", "Иван", "Артём", "Тимофей", "Богдан", "Глеб", "Захар", "Матвей"};
        static string[] secondNames = {"Иванов", "Васильев", "Петров", "Смирнов", "Михайлов", "Фёдоров", "Соколов",
            "Яковлев", "Попов", "Андреев", "Алексеев", "Александров", "Лебедев", "Григорьев", "Степанов"};
        static string[] patronymics = {"Александрович", "Адамович", "Анатольевич", "Аркадьевич", "Алексеевич",
            "Андреевич", "Артёмович", "Альбертович", "Антонович", "Богданович", "Богуславович", "Борисович",
            "Вадимович", "Васильевич", "Владимирович"};
        static string[] cities = {"Киев", "Харьков", "Одесса", "Днепропетровск", "Донецк", "Запорожье", "Львов",
            "Кривой Рог", "Николаев", "Мариуполь", "Луганск", "Винница", "Макеевка", "Севастополь", "Симферополь"};

        private static Random gen = new Random();

        static DateTime RandomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        public Group()
        {
            array = new Student[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Student();
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i].setFirstName(names[new Random((int)DateTime.Now.Ticks).Next(0, names.Length)].ToString());
                array[i].setSecondName(secondNames[new Random((int)DateTime.Now.Ticks).Next(0, secondNames.Length)].ToString());
                array[i].setPantonymic(patronymics[new Random((int)DateTime.Now.Ticks).Next(0, patronymics.Length)].ToString());
                array[i].setAddress(cities[new Random((int)DateTime.Now.Ticks).Next(0, cities.Length)].ToString());
                DateTime temp = RandomDate();
                array[i].setDateBirth(temp);
                Thread.Sleep(10);
            }
            people = 10;
            name = "Группа по умолчанию";
            specialisation = "Специализация по умолчанию";
            course = 1;
        }

        public Group(int quantity)
        {
            array = new Student[quantity];
            for (int i = 0; i < array.Length; i++)
            {
                array[i].setFirstName(names[new Random((int)DateTime.Now.Ticks).Next(0, names.Length)]);
                array[i].setSecondName(secondNames[new Random((int)DateTime.Now.Ticks).Next(0, secondNames.Length)]);
                array[i].setPantonymic(patronymics[new Random((int)DateTime.Now.Ticks).Next(0, patronymics.Length)]);
                array[i].setAddress(cities[new Random((int)DateTime.Now.Ticks).Next(0, cities.Length)]);
                DateTime temp = RandomDate();
                array[i].setDateBirth(temp);
                Thread.Sleep(10);
            }
            people = quantity;
            name = "Группа c задаваемым количеством";
            specialisation = "Специализация c задаваемым количеством";
            course = 1;
        }

        public Group(Student[] arrayExisting)
        {
            array = new Student[arrayExisting.Length];
            arrayExisting.CopyTo(array, 0);
            people = arrayExisting.Length;
            name = "Группа из существующего массива";
            specialisation = "Специализация из существующего массива";
            course = 1;
        }

        public Group(Group existing)
        {
            array = new Student[existing.array.Length];
            existing.array.CopyTo(array, 0);
            people = existing.people;
            name = String.Copy(existing.name);
            specialisation = String.Copy(existing.specialisation);
            course = existing.course;
        }

        public int People
        {
            set
            {
                people = value;
            }
            get
            {
                return people;
            }
        }
        public string Specialization
        {
            set
            {
                specialisation = value;
            }
            get
            {
                return specialisation;
            }
        }
        public int Course
        {
            set
            {
                course = value;
            }
            get
            {
                return course;
            }
        }

        public Student[] getStudentArray()
        {
            return array;
        }

        public string getName()
        {
            return name;
        }

        public string getSpecialisation()
        {
            return specialisation;
        }

        public int getPeople()
        {
            return people;
        }

        public int getCourse()
        {
            return course;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setSpecialisation(string specialisation)
        {
            this.specialisation = specialisation;
        }

        public void setCourse(int course)
        {
            this.course = course;
        }

        public void setStudent(Student student, int index)
        {
            array[index] = student;
        }

        public void showAll()
        {
            Console.WriteLine("Группа: {0}", name);
            Console.WriteLine("Специализация: {0}", specialisation);
            Array.Sort(array, (p1, p2) => p1.getSecondName().CompareTo(p2.getSecondName()));
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("{0,2} {1} {2}", (i + 1).ToString(), array[i].getSecondName(), array[i].getFirstName());
            }
            Console.WriteLine();
        }

        public void addStudent(Student newStudent)
        {
            Student[] newArray = new Student[array.Length + 1];
            array.CopyTo(newArray, 0);
            newArray[array.Length] = newStudent;
            array = newArray;
        }

        // реализация интерфейса IEnumerable

        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }

        public void Print()
        {
            foreach (Student stud in this)
            {
                stud.showAllInfo();
            }
        }

        //сортировка по фамилии
        public void Sort()
        {
            Array.Sort(array, new Student.SortBySecondName());
        }

        //поиск по фамилии
        public void Search(string second)
        {
            foreach (Student stud in this)
            {
                if(stud.SecondName.Equals(second))
                {
                    stud.showAllInfo();
                }
            }
        }
    }
}