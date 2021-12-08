using System;
using System.Collections.Generic;

namespace _08_7_Digit_Display
{
    class Program
    {
        static void Main(string[] args)
        {
            List<EncodedInput> input = EncodedInput.CreateEncodedInputFromFile(@"../../input.txt");
            Console.WriteLine("Count1478: " + Count1478(input));
            KeepConsoleOpen();
        }

        static int Count1478(List<EncodedInput> input)
        {
            int count = 0;
            input.ForEach(i => count += i.Count1478());
            return count;
        }

        private static void KeepConsoleOpen()
        {
            Console.WriteLine("Hit any key to continue...");
            Console.ReadKey();
        }
    }
}
