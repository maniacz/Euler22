using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler22
{
    class Program
    {
        private static List<string> Names;

        static void Main(string[] args)
        {
            Names = createNamesArray(readFile());
            sortNames(Names);

            Console.WriteLine(findFinalResult(Names));
            Console.ReadKey();
        }

        private static string readFile()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\p022_names.txt";
            string fileContent = System.IO.File.ReadAllText(path);

            return fileContent;
        }

        /// <summary>
        /// Tworzy tablicę stringów z nazwami
        /// </summary>
        private static List<String> createNamesArray(string fileText)
        {
            string content = fileText.Replace("\"", "");
            string[] names = content.Split(',');

            return new List<String>(names);
        }

        private static void sortNames(List<string> namesToSort)
        {
            namesToSort.Sort();
        }

        private static int calculateNameScore(string name)
        {
            int score = 0;

            foreach(char c in name) 
            {
                score += c - 64;
            }

            return score;
        }

        private static ulong findFinalResult(List<string> names)
        {
            int nameIndex, nameValue;
            ulong finalResult = 0;

            foreach (string name in names)
            {
                nameIndex = names.IndexOf(name) + 1;
                nameValue = nameIndex * calculateNameScore(name);
                finalResult += (ulong)nameValue;
            }

            return finalResult;
        }
    }
}
