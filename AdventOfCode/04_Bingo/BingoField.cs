using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Bingo
{
    public class BingoField
    {
        public readonly int Number;
        private bool Drawn = false;

        public BingoField(int number) {
            Number = number;
        }

        public void Dump()
        {
            if (!Program.verbose)
                return;

            Console.Write((WasAlreadyDrawn() ? " *" : "  ") + (Number < 10? " " + Number : "" + Number));
        }

        public void EvaluateDraw(int number)
        {
            if (number == Number)
                Drawn = true;
        }

        public bool WasAlreadyDrawn()
        {
            return Drawn == true;
        }
    }
}
