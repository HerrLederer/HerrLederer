using System;
using System.Collections;
using System.Linq;

namespace _04_Bingo
{
    public class NumberSequence
    {
        private int[] Draws;
        private uint current = 0;

        public NumberSequence(string input)
        {
            Draws = input.Split(',').Select(v => int.Parse(v)).ToArray();
        }

        public int GetNext()
        {
            if (current == Draws.Length)
                return -1;

            return Draws[current++];
        }
    }
}

