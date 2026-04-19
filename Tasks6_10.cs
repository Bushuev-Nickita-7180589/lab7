using System;
using System.Collections.Generic;
using System.IO;

namespace lab7_1
{
    public struct Student
    {
        private string _name;
        private string[] _games;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string[] Games
        {
            get { return _games; }
            set { _games = value; }
        }
    }

    public class Tasks6_10
    {
        public static void SolveTask6(List<int> L, List<int> L1, List<int> L2)
        {
            if (L == null || L1 == null || L2 == null || L1.Count == 0 || L1.Count > L.Count) return;

            for (int i = 0; i <= L.Count - L1.Count; i++)
            {
                bool isMatch = true;
                for (int j = 0; j < L1.Count; j++)
                {
                    if (L[i + j] != L1[j])
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    L.RemoveRange(i, L1.Count);
                    L.InsertRange(i, L2);
                    break;
                }
            }
        }

        public static void SolveTask7(LinkedList<int> list)
        {
            if (list == null || list.Count < 2) return;

            bool swapped;
            do
            {
                swapped = false;
                LinkedListNode<int> current = list.First;

                while (current.Next != null)
                {
                    if (current.Value > current.Next.Value)
                    {
                        int temp = current.Value;
                        current.Value = current.Next.Value;
                        current.Next.Value = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
        }

        public static void SolveTask8(HashSet<string> allGames, Student[] students,
            out HashSet<string> allPlay, out HashSet<string> somePlay, out HashSet<string> nonePlay)
        {
            allPlay = new HashSet<string>(allGames);
            nonePlay = new HashSet<string>(allGames);
            somePlay = new HashSet<string>();

            for (int i = 0; i < students.Length; i++)
            {
                HashSet<string> studentGames = new HashSet<string>();
                if (students[i].Games != null)
                {
                    for (int j = 0; j < students[i].Games.Length; j++)
                    {
                        studentGames.Add(students[i].Games[j]);
                    }
                }

                allPlay.IntersectWith(studentGames);
                nonePlay.ExceptWith(studentGames);
            }

            somePlay = new HashSet<string>(allGames);
            somePlay.ExceptWith(allPlay);
            somePlay.ExceptWith(nonePlay);
        }

        public static void GenerateDataTask9(string filePath)
        {
            File.WriteAllText(filePath, "Простая строка текста для тестирования работы программы!");
        }

        public static void SolveTask9(string filePath)
        {
            char[] voicelessConsonantsArr = { 'к', 'п', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
            HashSet<char> missingInSomeWords = new HashSet<char>();

            string text = File.ReadAllText(filePath).ToLower();
            char[] separators = { ' ', '.', ',', '!', '?', '\n', '\r', '\t', ';', ':' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < voicelessConsonantsArr.Length; i++)
            {
                char consonant = voicelessConsonantsArr[i];

                for (int j = 0; j < words.Length; j++)
                {
                    bool foundInWord = false;
                    for (int k = 0; k < words[j].Length; k++)
                    {
                        if (words[j][k] == consonant)
                        {
                            foundInWord = true;
                            break;
                        }
                    }

                    if (!foundInWord)
                    {
                        missingInSomeWords.Add(consonant);
                        break;
                    }
                }
            }

            Console.WriteLine("Глухие согласные, не входящие хотя бы в одно слово:");
            for (int i = 0; i < voicelessConsonantsArr.Length; i++)
            {
                if (missingInSomeWords.Contains(voicelessConsonantsArr[i]))
                {
                    Console.Write(voicelessConsonantsArr[i] + " ");
                }
            }
            Console.WriteLine();
        }

        public static void GenerateDataTask10(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("4");
                writer.WriteLine("Петрова Ольга 25 18 16");
                writer.WriteLine("Калиниченко Иван 14 19 15");
                writer.WriteLine("Иванов Алексей 25 18 16");
                writer.WriteLine("Смирнов Олег 10 10 10");
            }
        }

        public static void SolveTask10(string filePath)
        {
            SortedList<int, List<string>> scoresDict = new SortedList<int, List<string>>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string firstLine = reader.ReadLine();
                if (string.IsNullOrEmpty(firstLine) || !int.TryParse(firstLine.Trim(), out int n)) return;

                for (int i = 0; i < n; i++)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line)) break;

                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 5)
                    {
                        string fullName = parts[0] + " " + parts[1];
                        int totalScore = int.Parse(parts[2]) + int.Parse(parts[3]) + int.Parse(parts[4]);

                        if (!scoresDict.ContainsKey(totalScore))
                        {
                            scoresDict.Add(totalScore, new List<string>());
                        }
                        scoresDict[totalScore].Add(fullName);
                    }
                }
            }

            if (scoresDict.Count > 0)
            {
                int maxScoreIndex = scoresDict.Count - 1;
                int maxScore = scoresDict.Keys[maxScoreIndex];
                List<string> winners = scoresDict.Values[maxScoreIndex];

                Console.WriteLine($"Победители (максимальный балл - {maxScore}):");
                for (int i = 0; i < winners.Count; i++)
                {
                    Console.WriteLine(winners[i]);
                }
            }
        }
    }
}