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
        }

        private static void DoMagicStuff()
        {
            int[] fileContent = File.ReadAllLines(@"..\..\input.txt").Select(int.Parse).ToArray(); ;
            
            int count = 0;

            int length = fileContent.Length;

            for (int i = 0; i < length;)
            {
                int value = fileContent[i];
                if (++i < length)
                {
                    int nextValue = fileContent[i];
                    if (nextValue > value)
                        count++;
                }
            }
            Console.WriteLine("Ergebnis: " + count);
        }
    }
}
