using System;
using System.Collections.Generic;

namespace _06_Lanternfish
{
    class LanternFishPool
    {
        public static IDictionary<int, ulong> AgePool = new Dictionary<int, ulong>();

        public static void Initialize()
        {
            // initialize age dict
            for(int i = 0; i <= LanternFish.InitialTimeTillReproduction; i++)
            {
                AgePool[i] = 0;
            }
        }

        public static void DumpStatus() {
            ulong ttlNumOfFish = 0;
            for (int i = 0; i <= LanternFish.InitialTimeTillReproduction; i++)
            {
                ulong numOfThisAge = AgePool[i];
                Console.WriteLine("Age: " + i + " ttl: " + numOfThisAge);
                ttlNumOfFish += numOfThisAge;
            }
            Console.WriteLine("ttl: " + ttlNumOfFish);
        }

        public static void Add(LanternFish newFish)
        {
            AgePool[newFish.InternalTimer]++;
        }

        public static void Age(int numberOfDaysToFinish)
        {
            while(numberOfDaysToFinish-- > 0)
            {
                FinishDay();
            }
        }

        public static void FinishDay()
        {
            ulong fishToReproduce = AgePool[0];

            for(int i = 0; i < LanternFish.InitialTimeTillReproduction; i++)
            {
                AgePool[i] = AgePool[i + 1];
            }

            // re-add the ones that reached 0
            AgePool[LanternFish.InitialTimeTillReproduction - 2] += fishToReproduce;

            // Add the new ones
            AgePool[LanternFish.InitialTimeTillReproduction] = fishToReproduce;
        }
    }
}
