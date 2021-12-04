using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Bingo
{
    class Program
    {
        public static bool verbose = false;

        static void Main(string[] args)
        {
            StartGame(@"..\..\input.txt");
            KeepConsoleOpen();
        }

        static void KeepConsoleOpen()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        static void StartGame(string inputFile)
        {
            var fileReader = new InputFileReader(inputFile);
            NumberSequence numberSequence = fileReader.GetNumberSequence();

            IList<BingoBoard> boards = fileReader.GetBingoBoards();

            BingoBoard winnerBoard = null;
            BingoBoard loserBoard = null;

            while (true)
            {
                int draw = numberSequence.GetNext();

                if (draw == -1)
                {
                    if (Program.verbose)
                        Console.WriteLine("No more draws left");
                    break;
                }

                if (Program.verbose)
                    Console.WriteLine("\n############\ndraw: " + draw);

                foreach (var board in boards)
                {
                    board.ProcessDraw(draw);
                    board.Dump();
                }

                if (winnerBoard == null)
                    winnerBoard = boards.FirstOrDefault(b => b.Finished(draw));

                
                var lastWinnerBoardCandidate = boards.FirstOrDefault(b => b.Finished(draw));
                if (lastWinnerBoardCandidate != null)
                    loserBoard = lastWinnerBoardCandidate;

                if (AllBoardsDone(boards))
                {
                    Console.WriteLine("All boards done");
                    break;
                }
            }


            if (winnerBoard != null)
            {
                Console.WriteLine("\nFirstWinner:");
                winnerBoard.DumpFinalResult();
            }


            if (loserBoard != null)
            {
                Console.WriteLine("\nLastWinner:");
                loserBoard.DumpFinalResult();
            }
        }

        private static bool AllBoardsDone(IList<BingoBoard> boards)
        {
            return boards.All(b => b.Finished());
        }
    }
}
