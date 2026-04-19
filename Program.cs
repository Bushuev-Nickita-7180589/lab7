using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using static lab7_1.Tasks1_5;
using static lab7_1.Tasks6_10;

namespace lab7_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск лабораторной работы (Задания 1-5)...\n");

            string file1 = "task1.txt";
            Tasks1_5.GenerateDataTask1(file1, 5);
            Console.WriteLine($"Задание 1: Сумма квадратов = {Tasks1_5.SolveTask1(file1)}");

            string file2 = "task2.txt";
            Tasks1_5.GenerateDataTask2(file2, 3, 4);
            Console.WriteLine($"Задание 2: Произведение элементов = {Tasks1_5.SolveTask2(file2)}");

            string file3In = "task3_in.txt";
            string file3Out = "task3_out.txt";
            File.WriteAllLines(file3In, new string[] { "hello", "hi", "world", "abc", "apple" });
            Tasks1_5.SolveTask3(file3In, file3Out, 5);
            Console.WriteLine($"Задание 3: Строки длиной 5 переписаны в {file3Out}");

            string file4 = "task4.bin";
            Tasks1_5.GenerateDataTask4(file4, 10);
            Console.WriteLine($"\nПроизведение нечетных отрицательных = {Tasks1_5.SolveTask4(file4)}");


            string file5 = "task5.xml";
            Passenger[] testPassengers = new Passenger[]
            {
                new Passenger { Items = new BaggageItem[] { new BaggageItem { Name = "Сумка", Mass = 5 } } },
                new Passenger { Items = new BaggageItem[] { new BaggageItem { Name = "Чемодан", Mass = 15 }, new BaggageItem { Name = "Коробка", Mass = 2 }, new BaggageItem { Name = "Пакет", Mass = 1 } } },
                new Passenger { Items = new BaggageItem[] { new BaggageItem { Name = "Рюкзак", Mass = 8 }, new BaggageItem { Name = "Ноутбук", Mass = 3 } } }
            };

            Tasks1_5.GenerateDataTask5(file5, testPassengers);

            int moreThanTwo;
            int aboveAvg;
            Tasks1_5.SolveTask5(file5, out moreThanTwo, out aboveAvg);
            Console.WriteLine($"Задание 5: Пассажиров с >2 ед. багажа: {moreThanTwo}, Пассажиров с багажом > среднего: {aboveAvg}");


            Console.WriteLine("\nЗапуск лабораторной работы (Задания 6-10)...\n");

            List<int> L = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> L1 = new List<int> { 3, 4 };
            List<int> L2 = new List<int> { 99, 88 };
            Console.WriteLine("Задание 6: \nСписок до замены: " + string.Join(", ", L));
            Tasks6_10.SolveTask6(L, L1, L2);
            Console.WriteLine("Список после замены: " + string.Join(", ", L));

            LinkedList<int> linkedList = new LinkedList<int>(new int[] { 5, 2, 9, 1, 5, 6 });
            Console.WriteLine("\nЗадание 7: \nСписок до сортировки: " + string.Join(", ", linkedList));
            Tasks6_10.SolveTask7(linkedList);
            Console.WriteLine("Отсортированный список: " + string.Join(", ", linkedList));

            HashSet<string> allGames = new HashSet<string> { "Dota 2", "CS:GO", "Minecraft", "The Witcher 3" };
            Student[] students = new Student[]
            {
                new Student { Name = "Иван", Games = new string[] { "Dota 2", "CS:GO" } },
                new Student { Name = "Петр", Games = new string[] { "Dota 2", "Minecraft" } }
            };

            Tasks6_10.SolveTask8(allGames, students, out HashSet<string> allPlay, out HashSet<string> somePlay, out HashSet<string> nonePlay);
            Console.WriteLine("\nЗадание 8:");
            Console.WriteLine("Играют все: " + string.Join(", ", allPlay));
            Console.WriteLine("Играют некоторые: " + string.Join(", ", somePlay));
            Console.WriteLine("Не играет никто: " + string.Join(", ", nonePlay));

            string file9 = "task9.txt";
            Tasks6_10.GenerateDataTask9(file9);
            Console.WriteLine("\nЗадание 9:");
            Tasks6_10.SolveTask9(file9);

            string file10 = "task10.txt";
            Tasks6_10.GenerateDataTask10(file10);
            Console.WriteLine("\nЗадание 10:");
            Tasks6_10.SolveTask10(file10);

            Console.ReadLine();
        }
    }
}
