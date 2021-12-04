using System;

namespace _04_Bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            Bingo.Start(@"..\..\input.txt");
            KeepConsoleOpen();
        }

        static void KeepConsoleOpen()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
