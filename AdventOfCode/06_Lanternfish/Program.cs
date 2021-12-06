using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Lanternfish
{
    class Program
    {
        static void Main(string[] args)
        {
            LanternFishPool.Initialize();

            CreateInitialPopulation(InputReader.ReadInput(@"../../input.txt"));

            // age for 80 days for task 1
            const int task1Age = 80;
            LanternFishPool.Age(task1Age);
            LanternFishPool.DumpStatus();
          
            // age some more for task 2
            const int task2Age = 256;
            LanternFishPool.Age(task2Age - task1Age);
            LanternFishPool.DumpStatus();

            KeepConsoleOpen();
        }

        private static void CreateInitialPopulation(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
                LanternFish.CreateFromInput(input[i]);
        }

        private static void KeepConsoleOpen()
        {
            Console.WriteLine("Hit any key to exit ...");
            Console.ReadKey();
        }
    }
}
