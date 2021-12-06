using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Lanternfish
{
    class InputReader
    {
        public static int[] ReadInput(string inputFileName)
        {
            string[] input = File.ReadAllLines(inputFileName);
            int[] inputAsIntArray = input[0].Split(',').Select(int.Parse).ToArray();
            return inputAsIntArray;
        }
    }
}
