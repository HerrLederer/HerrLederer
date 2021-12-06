namespace _06_Lanternfish
{
    class LanternFish
    {
        public const int InitialTimeTillReproduction = 8;

        public int InternalTimer = InitialTimeTillReproduction;

        public LanternFish(int age)
        {
            InternalTimer = age;
        }

        public static LanternFish CreateFromInput(int input)
        {
            LanternFish newFish = new LanternFish(input);
            LanternFishPool.Add(newFish);
            return newFish;
        }
    }
}
