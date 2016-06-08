/*
 Реализовать класс Student, который содержит поля 
для хранения фамилии, имени, отчества, даты рождения, 
домашнего адреса, телефонного номера. Также за каждым 
студентом закреплены 3 массива оценок – зачёты, 
курсовые работы, экзамены. Обязательные методы: 2-3 
версии конструктора с параметрами, геттеры и сеттеры 
для всех полей, показ всех данных о студенте.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3_1_Classes1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student B = new Student();
            B.showAllInfo();
            Student D = new Student("Иван", "Иванов", "Иванович");
            D.showAllInfo();
            Student A = new Student("Василий", "Ибрагимов", "Алибабаевич", 1970, 11, 23, "Махачкала", "0505055500");
            A.showAllInfo();

            Group group = new Group();
            group.addStudent(A);
            group.addStudent(B);
            group.addStudent(D);
            group.showAll();

            Student[] stuarr = { A, B, D };
            Group gr2 = new Group(stuarr);
            gr2.showAll();

            Group gr3 = new Group(gr2);
            gr3.addStudent(new Student("Василий", "Васильев", "Васильевич"));
            gr3.showAll();

            Group gr4 = new Group(gr2);

            gr3.transferStudent(gr3.getStudentArray().Length - 1, gr2);
            gr2.showAll();
            gr3.showAll();

            //отчисление несдавших
            gr3.studentExpulsion();

            //отчисление самого неуспевающего
            for (int i = 0; i < gr4.getStudentArray().Length; i++)
            {
                gr4.getStudentArray()[i].setFirstCredit((i + 4).ToString());
                gr4.getStudentArray()[i].setSecondCredit((i + 5).ToString());
                gr4.getStudentArray()[i].setThirdCredit((i + 6).ToString());
            }
            for (int i = 0; i < gr4.getStudentArray().Length; i++)
            {
                gr4.getStudentArray()[i].showAllInfo();
            }
            gr4.worstStudentExpulsion();
        }
    }

    class Student
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
            dateBirth =  new DateTime(1979, 03, 26);
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

        public Student (string firstName, string secondName, string patronymic)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.patronymic = patronymic;
            dateBirth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            address = "";
            phone = "";
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

        public Student(string firstName, string secondName, string patronymic, int year, int month, int day , string address, string phone)
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
        public string getFirstCreditName()
        {
            return credit[0, 0];
        }
        public string getSecondCreditName()
        {
            return credit[1, 0];
        }
        public string getThirdCreditName()
        {
            return credit[2, 0];
        }
        public string getFirstCourseName()
        {
            return course[0, 0];
        }
        public string getSecondCourseName()
        {
            return course[1, 0];
        }
        public string getThirdCourseName()
        {
            return course[2, 0];
        }
        public string getFirstExamName()
        {
            return exam[0, 0];
        }
        public string getSecondExamName()
        {
            return exam[1, 0];
        }
        public string getThirdExamName()
        {
            return exam[2, 0];
        }
        public string getFirstCreditMark()
        {
            return credit[0, 1];
        }
        public string getSecondCreditMark()
        {
            return credit[1, 1];
        }
        public string getThirdCreditMark()
        {
            return credit[2, 1];
        }
        public string getFirstCourseMark()
        {
            return course[0, 1];
        }
        public string getSecondCourseMark()
        {
            return course[1, 1];
        }
        public string getThirdCourseMark()
        {
            return course[2, 1];
        }
        public string getFirstExamMark()
        {
            return exam[0, 1];
        }
        public string getSecondExamMark()
        {
            return exam[1, 1];
        }
        public string getThirdExamMark()
        {
            return exam[2, 1];
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


    }

    /*
    Реализовать класс Group, который работает с массивом студентов. 
    Обязательные поля: ссылка на массив студентов, количество человек 
    в группе, название группы, специализация группы, номер курса. 
    Обязательные методы: конструктор по умолчанию на 10 студентов 
    (предусмотреть автоматическую генерацию фамилий, имён, возрастов 
    и других данных), конструктор с одним параметром типа int (задаётся 
    произвольное количество студентов), конструктор с параметром типа 
    Student[] (новая группа формируется на основании уже существующего 
    массива студентов), конструктор с параметром типа Group (создаётся 
    точная копия группы). Реализовать следующие методы: показ всех 
    студентов группы (сначала - название и специализация группы, затем - 
    порядковые номера, фамилии в алфавитном порядке и имена студентов), 
    добавление студента в группу, редактирование данных о студенте и 
    группе, перевод студента из одной группы в другую, отчисление всех 
    не сдавших сессию студентов, отчисление одного самого неуспевающего 
    студента.
    */

    class Group
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
            Console.WriteLine("На основе существующей группы.");
            array = new Student[existing.array.Length];
            existing.array.CopyTo(array, 0);
            people = existing.people;
            name = String.Copy(existing.name);
            specialisation = String.Copy(existing.specialisation);
            course = existing.course;
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

        public void setPeoplePlusOne()
        {
            people++;
        }
        public void setPeopleMinusOne()
        {
            people--;
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
            people++;
        }

        public void deleteStudent(int index)
        {
            Student[] newArray = new Student[array.Length - 1];
            if (index == 0)
            {
                for (int i = 1; i < array.Length; i++)
                    newArray[i - 1] = array[i];
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    newArray[i] = array[i];
                }
                for (int i = index + 1; i < array.Length; i++)
                {
                    newArray[i - 1] = array[i];
                }
            }
            array = newArray;
            people--;
        }

        public void editStudent()
        {
            Console.WriteLine("Редактировани данных о студенте");
            Console.WriteLine("Введите индекс студента:");
            int index = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Текущие данные по студенту:");
            array[index].showAllInfo();
            Console.WriteLine("Выберите данные для редактирования:");
            Console.WriteLine("(1) Имя (2) Фамилия (3) Отчество (4) дата рождения");
            Console.WriteLine("(5) адрес (6) телефон (7) оценки");
            int choise = Int32.Parse(Console.ReadLine());
            switch(choise)
            {
                case 1:
                    Console.WriteLine("Введите новое имя студента:");
                    array[index].setFirstName(Console.ReadLine());
                    Console.WriteLine("Новые данные по студенту:");
                    array[index].showAllInfo();
                    break;
                case 2:
                    Console.WriteLine("Введите новую фамилию студента:");
                    array[index].setSecondName(Console.ReadLine());
                    Console.WriteLine("Новые данные по студенту:");
                    array[index].showAllInfo();
                    break;
                case 3:
                    Console.WriteLine("Введите новое отчество студента:");
                    array[index].setPantonymic(Console.ReadLine());
                    Console.WriteLine("Новые данные по студенту:");
                    array[index].showAllInfo();
                    break;
                case 4:
                    Console.WriteLine("Введите новую дату рождения студента (год месяц день):");
                    array[index].setDateBirth(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()));
                    Console.WriteLine("Новые данные по студенту:");
                    array[index].showAllInfo();
                    break;
                case 5:
                    Console.WriteLine("Введите новый адрес студента:");
                    array[index].setAddress(Console.ReadLine());
                    Console.WriteLine("Новые данные по студенту:");
                    array[index].showAllInfo();
                    break;
                case 6:
                    Console.WriteLine("Введите новый телефон студента:");
                    array[index].setPhone(Console.ReadLine());
                    Console.WriteLine("Новые данные по студенту:");
                    array[index].showAllInfo();
                    break;
                case 7:
                    Console.WriteLine("Что изменить? (1) Зачеты (2) Курсовые (3) Экзамены");
                    int choise2 = Int32.Parse(Console.ReadLine());
                    switch(choise2)
                    {
                        case 1:
                            Console.WriteLine("Оценку к какому зачету поменять?");
                            Console.WriteLine("(1) {0} (2) {1} (3) {2}", array[index].getFirstCreditName(), array[index].getSecondCreditName(), array[index].getThirdCreditName());
                            int credit = Int32.Parse(Console.ReadLine());
                            switch(credit)
                            {
                                case 1:
                                    Console.WriteLine("Введите новую оценку по {0}:", array[index].getFirstCreditName());
                                    array[index].setFirstCredit(Console.ReadLine());
                                    Console.WriteLine("Новые данные по студенту:");
                                    array[index].showAllInfo();
                                    break;
                                case 2:
                                    Console.WriteLine("Введите новую оценку по {0}:", array[index].getSecondCreditName());
                                    array[index].setSecondCredit(Console.ReadLine());
                                    Console.WriteLine("Новые данные по студенту:");
                                    array[index].showAllInfo();
                                    break;
                                case 3:
                                    Console.WriteLine("Введите новую оценку по {0}:", array[index].getThirdCreditName());
                                    array[index].setThirdCredit(Console.ReadLine());
                                    Console.WriteLine("Новые данные по студенту:");
                                    array[index].showAllInfo();
                                    break;
                                default:
                                    Console.WriteLine("Неверный выбор");
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Оценку к какой курсовой поменять?");
                            Console.WriteLine("(1) {0} (2) {1} (3) {2}", array[index].getFirstCourseName(), array[index].getSecondCourseName(), array[index].getThirdCourseName());
                            int course = Int32.Parse(Console.ReadLine());
                            switch (course)
                            {
                                case 1:
                                    Console.WriteLine("Введите новую оценку по {0}:", array[index].getFirstCourseName());
                                    array[index].setFirstCourse(Console.ReadLine());
                                    Console.WriteLine("Новые данные по студенту:");
                                    array[index].showAllInfo();
                                    break;
                                case 2:
                                    Console.WriteLine("Введите новую оценку по {0}:", array[index].getSecondCourseName());
                                    array[index].setSecondCourse(Console.ReadLine());
                                    Console.WriteLine("Новые данные по студенту:");
                                    array[index].showAllInfo();
                                    break;
                                case 3:
                                    Console.WriteLine("Введите новую оценку по {0}:", array[index].getThirdCourseName());
                                    array[index].setThirdCourse(Console.ReadLine());
                                    Console.WriteLine("Новые данные по студенту:");
                                    array[index].showAllInfo();
                                    break;
                                default:
                                    Console.WriteLine("Неверный выбор");
                                    break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Оценку к какому экзамену поменять?");
                            Console.WriteLine("(1) {0} (2) {1} (3) {2}", array[index].getFirstExamName(), array[index].getSecondExamName(), array[index].getThirdExamName());
                            int exam = Int32.Parse(Console.ReadLine());
                            switch (exam)
                            {
                                case 1:
                                    Console.WriteLine("Введите новую оценку по {0}:", array[index].getFirstExamName());
                                    array[index].setFirstExam(Console.ReadLine());
                                    Console.WriteLine("Новые данные по студенту:");
                                    array[index].showAllInfo();
                                    break;
                                case 2:
                                    Console.WriteLine("Введите новую оценку по {0}:", array[index].getSecondExamName());
                                    array[index].setSecondExam(Console.ReadLine());
                                    Console.WriteLine("Новые данные по студенту:");
                                    array[index].showAllInfo();
                                    break;
                                case 3:
                                    Console.WriteLine("Введите новую оценку по {0}:", array[index].getThirdExamName());
                                    array[index].setThirdExam(Console.ReadLine());
                                    Console.WriteLine("Новые данные по студенту:");
                                    array[index].showAllInfo();
                                    break;
                                default:
                                    Console.WriteLine("Неверный выбор");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Неверный выбор");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }

        public void transferStudent(int index, Group groupToTransfer)
        {
            groupToTransfer.addStudent(array[index]);
            groupToTransfer.setPeoplePlusOne();
            deleteStudent(index);
            people--;
        }

        public void studentExpulsion()
        {
            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    if (Int32.Parse(array[i].getFirstCreditMark()) < 6 && Int32.Parse(array[i].getSecondCreditMark()) < 6 && Int32.Parse(array[i].getThirdCreditMark()) < 6 &&
                        Int32.Parse(array[i].getFirstCourseMark()) < 6 && Int32.Parse(array[i].getSecondCourseMark()) < 6 && Int32.Parse(array[i].getThirdCourseMark()) < 6 &&
                        Int32.Parse(array[i].getFirstExamMark()) < 6 && Int32.Parse(array[i].getSecondExamMark()) < 6 && Int32.Parse(array[i].getThirdExamMark()) < 6)
                    {
                        Console.WriteLine("Студент {0} {1} не сдал сессию и отчислен.", array[i].getFirstName(), array[i].getSecondName());
                        deleteStudent(i);
                        people--;
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Студент {0} {1} не сдал сессию и отчислен.", array[i].getFirstName(), array[i].getSecondName());
                    deleteStudent(i);
                    people--;
                }

            }
            Console.WriteLine("Текущий состав группы:");
            showAll();
        }

        public void worstStudentExpulsion()
        {
            int[] marks = new int[array.Length];
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (Int32.TryParse(array[i].getFirstCreditMark(), out result))
                    marks[i] += result;
                if (Int32.TryParse(array[i].getSecondCreditMark(), out result))
                    marks[i] += result;
                if (Int32.TryParse(array[i].getThirdCreditMark(), out result))
                    marks[i] += result;
                if (Int32.TryParse(array[i].getFirstCourseMark(), out result))
                    marks[i] += result;
                if (Int32.TryParse(array[i].getSecondCourseMark(), out result))
                    marks[i] += result;
                if (Int32.TryParse(array[i].getThirdCourseMark(), out result))
                    marks[i] += result;
                if (Int32.TryParse(array[i].getFirstExamMark(), out result))
                    marks[i] += result;
                if (Int32.TryParse(array[i].getSecondExamMark(), out result))
                    marks[i] += result;
                if (Int32.TryParse(array[i].getThirdExamMark(), out result))
                    marks[i] += result;
            }

            int worseIndex = Array.IndexOf(marks, marks.Min());
            Console.WriteLine("Студент {0} {1} оказался самым неуспевающим и отчислен.", array[worseIndex].getFirstName(), array[worseIndex].getSecondName());
            deleteStudent(worseIndex);
            people--;
        }
    }
}
