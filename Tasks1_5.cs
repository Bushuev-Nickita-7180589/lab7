using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab7_1
{
    [Serializable]
    public struct BaggageItem
    {
        private string _name;
        private double _mass;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Mass
        {
            get { return _mass; }
            set { _mass = value; }
        }
    }

    [Serializable]
    public struct Passenger
    {
        private BaggageItem[] _items;

        public BaggageItem[] Items
        {
            get { return _items; }
            set { _items = value; }
        }
    }

    public class Tasks1_5
    {
        public static void GenerateDataTask1(string filePath, int count)
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.WriteLine(random.Next(-10, 11));
                }
            }
        }

        public static long SolveTask1(string filePath)
        {
            long sumOfSquares = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        sumOfSquares += number * number;
                    }
                }
            }
            return sumOfSquares;
        }

        public static void GenerateDataTask2(string filePath, int linesCount, int numbersPerLine)
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < linesCount; i++)
                {
                    for (int j = 0; j < numbersPerLine; j++)
                    {
                        writer.Write(random.Next(1, 6) + " ");
                    }
                    writer.WriteLine();
                }
            }
        }

        public static long SolveTask2(string filePath)
        {
            long product = 1;
            bool hasElements = false;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (int.TryParse(parts[i], out int number))
                        {
                            product *= number;
                            hasElements = true;
                        }
                    }
                }
            }
            return hasElements ? product : 0;
        }

        public static void SolveTask3(string inputFilePath, string outputFilePath, int m)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length == m)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        public static void GenerateDataTask4(string filePath, int count)
        {
            Random random = new Random();
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.Write(random.Next(-10, 10));
                }
            }
        }

        public static long SolveTask4(string filePath)
        {
            long product = 1;
            bool found = false;

            Console.WriteLine("Задание 4:");

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    int number = reader.ReadInt32();
                    Console.Write(number + " ");
                    if (number < 0 && number % 2 != 0)
                    {
                        product *= number;
                        found = true;
                    }
                }
            }
            return found ? product : 0;
        }


        public static void GenerateDataTask5(string filePath, Passenger[] passengers)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Passenger[]));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, passengers);
            }
        }

        public static void SolveTask5(string filePath, out int moreThanTwoCount, out int aboveAverageCount)
        {
            moreThanTwoCount = 0;
            aboveAverageCount = 0;
            Passenger[] passengers = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Passenger[]));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                passengers = (Passenger[])serializer.Deserialize(fs);
            }

            if (passengers == null || passengers.Length == 0)
            {
                return;
            }

            int totalItems = 0;
            for (int i = 0; i < passengers.Length; i++)
            {
                if (passengers[i].Items != null)
                {
                    totalItems += passengers[i].Items.Length;
                }
            }

            double averageItems = (double)totalItems / passengers.Length;

            for (int i = 0; i < passengers.Length; i++)
            {
                int currentItemsCount = 0;
                if (passengers[i].Items != null)
                {
                    currentItemsCount = passengers[i].Items.Length;
                }

                if (currentItemsCount > 2)
                {
                    moreThanTwoCount++;
                }

                if (currentItemsCount > averageItems)
                {
                    aboveAverageCount++;
                }
            }
        }
    }
}

