namespace _04_Bingo
{
    public class BingoField
    {
        public readonly int Number;
        private bool Drawn = false;

        public BingoField(int number) {
            Number = number;
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
