using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Sonar
{
    class Program
    {
        static void Main(string[] args)
        {
            DoMagicStuff();
            DoSmoothedMagicStuff();
        }

        private static void DoMagicStuff()
        {
            int[] fileContent = ReadFileContent();
            int count = Count(fileContent);
            PrintResult(count);
        }

        private static void DoSmoothedMagicStuff()
        {
            int[] fileContent = ReadFileContent();
            int[] smoothedFileContent = Smooth(fileContent);
            int count = Count(smoothedFileContent);
            PrintResult(count);
        }

        private static int Count(int [] input)
        {
            int count = 0;
            int length = input.Length;

            for (int i = 0; i < length;)
            {
                int value = input[i];
                if (++i < length)
                {
                    int nextValue = input[i];
                    if (nextValue > value)
                        count++;
                }
            }
            return count;
        }

        private static int[] Smooth(int[] input)
        {
            int[] fileContent = ReadFileContent();
            IList<int> smoothedFileContent = new List<int>();

            for (int i = 1; i < fileContent.Length - 1; i++)
            {
                int value = fileContent[i] + fileContent[i - 1] + fileContent[i + 1];
                smoothedFileContent.Add(value);
            }
            return smoothedFileContent.ToArray();
        }

        private static int[] ReadFileContent()
        {
            return File.ReadAllLines(@"..\..\input.txt").Select(int.Parse).ToArray();
        }

        private static void PrintResult(int count)
        {
            Console.WriteLine("Ergebnis: " + count);
        }

    }
}
