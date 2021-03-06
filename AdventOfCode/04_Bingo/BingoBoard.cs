using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_Bingo
{
    public class BingoBoard
    {
        private const uint Boardsize = 5;
        private readonly BingoField[,] BoardContent = new BingoField[Boardsize, Boardsize];
        private int? finalDraw = null;

        public BingoBoard(string[] input)
        {
            for(uint i = 0; i < Boardsize; i++)
            {
                InitializeRow(i, input[i]);
            }
        }

        public void DumpFinalResult()
        {
            Console.WriteLine("Value: " + CalculateValue());
        }

        public int CalculateValue()
        {
            int value = 0;
            for (uint row = 0; row < Boardsize; row++)
            {
                for (uint column = 0; column < Boardsize; column++)
                {
                    var field = BoardContent[row, column];
                    if (!field.WasAlreadyDrawn())
                        value += field.Number;
                }
            }

            return (finalDraw != null) ? value * finalDraw.Value : 0;
        }


        public void ProcessDraw(int draw)
        {
            // do nothing if board was already completed.
            if (Finished())
                return;

            foreach(var f in BoardContent)
            {
                f.EvaluateDraw(draw);
            }
        }

        private void InitializeRow(uint rowNumber, string rowContent)
        {
            int[] inputs = ParseRowInputString(rowContent);
            for(uint i = 0; i < inputs.Length; i++)
            {
                BoardContent[rowNumber,i] = new BingoField(inputs[i]);
            }
        }

        private int[] ParseRowInputString(string rowContent)
        {
            rowContent = Regex.Replace(rowContent, @"\s+", " ").Trim();
            int[] bingoFieldValues = rowContent.Split(' ').Select(v => int.Parse(v.Trim())).ToArray();
            Debug.Assert(bingoFieldValues.Length == Boardsize);
            return bingoFieldValues;
        }

        public bool Finished()
        {
            return finalDraw != null;
        }

        public bool Finished(int draw)
        {
            if (Finished())
                return true;

            if( RowsAreFinished() || ColumnsAreFinished())
            {
                finalDraw = draw;
                return true;
            }
            return false;
        }

        private bool RowsAreFinished()
        {
            for (uint row = 0; row < Boardsize; row++)
            {
                bool finished = true;
                for (uint column = 0; column < Boardsize; column++)
                {
                    finished &= BoardContent[row, column].WasAlreadyDrawn();
                }
                if (finished)
                    return true;
            }
            return false;
        }

        private bool ColumnsAreFinished()
        {
            for (uint column = 0; column < Boardsize; column++)
            {
                bool finished = true;
                for (uint row = 0; row < Boardsize; row++)
                {
                    finished &= BoardContent[row, column].WasAlreadyDrawn();
                }
                if (finished)
                    return true;
            }
            return false;
        }
    }
}
