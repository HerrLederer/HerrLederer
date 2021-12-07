using System;
using System.IO;
using System.Linq;

namespace _07_Whales
{
    class CrabArray
    {
        int[] _crabPositions;

        int LeftMost { get; }
        int RightMost { get; }

        public CrabArray(int[] crabPositions)
        {
            _crabPositions = crabPositions;

            LeftMost = findMin(crabPositions);
            RightMost = findMax(crabPositions);
        }


        private static int findMin(int[] crabPositions)
        {
            int currentMin = int.MaxValue;
            foreach (var crabPos in crabPositions)
            {
                if (crabPos < currentMin)
                    currentMin = crabPos;
            }
            return currentMin;
        }

        private static int findMax(int[] crabPositions)
        {
            int currentMin = int.MinValue;
            foreach (var crabPos in crabPositions)
            {
                if (crabPos > currentMin)
                    currentMin = crabPos;
            }
            return currentMin;
        }

        private static int Abs(int input)
        {
            return (input > 0) ? input : -input;
        }

        private int findLeastSumOfDistances()
        {
            int bestPosition = int.MaxValue;
            int currentLeastFuelConnsumption = int.MaxValue;

            for (int pos = LeftMost; pos < RightMost; pos++)
            {
                int fuel = calculateFuelConsumptionForPosition(pos);
                if (fuel <= currentLeastFuelConnsumption)
                {
                    currentLeastFuelConnsumption = fuel;
                    bestPosition = pos;
                }
            }
            return bestPosition;
        }

        private int calculateFuelConsumptionForPosition(int destinationPosition)
        {
            int fuelSum = 0;

            foreach (var pos in _crabPositions.ToList())
            {
                fuelSum += CalculateFuelConsumption(Abs(pos - destinationPosition));
            }
            return fuelSum;
        }
        private static int CalculateFuelConsumption(int distance)
        {
            int fuel = 0;
            while (distance > 0)
            {
                fuel += distance--;
            }
            return fuel;
        }

        public int CalculateLowestPossibleConsumption()
        {
            int bestPosition = findLeastSumOfDistances();
            int bestConsumption = calculateFuelConsumptionForPosition(bestPosition);
            return bestConsumption;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CrabArray array = new CrabArray(ReadFileContent(@"../../input.txt"));
            int bestConsumption = array.CalculateLowestPossibleConsumption();
            Console.WriteLine("Best Consumption: " + bestConsumption);
            KeepConsoleOpen();
        }

        private static void KeepConsoleOpen()
        {
            Console.WriteLine("Hit any key to continue...");
            Console.ReadKey();
        }

        private static int[] ReadFileContent(string fileName)
        {
            var fileContent = File.ReadAllLines(fileName)[0].Split(',').Select(int.Parse).ToArray();
            return fileContent;
        }
    }
}
