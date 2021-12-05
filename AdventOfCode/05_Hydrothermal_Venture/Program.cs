using System;
using System.Collections.Generic;
namespace _05_Hydrothermal_Venture
{
    class Program
    {
        static void Main(string[] args)
        {
            InputFileReader fr = new InputFileReader("../../input.txt");
            fr.ProcessFileContent();

            Point[] intersections = PointStorage.GetIntersections();
            Console.WriteLine("Intersections: " + intersections.Length);

            KeepConsoleOpen();
        }

        static void KeepConsoleOpen()
        {
            Console.WriteLine("Hit any key to exit ...");
            Console.ReadKey();
        }
    }
}
