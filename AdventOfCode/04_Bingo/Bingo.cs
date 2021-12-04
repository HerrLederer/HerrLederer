using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Bingo
{
    class Bingo
    {
        public static void Start(string inputFile)
        {
            var fileReader = new InputFileReader(inputFile);
            NumberSequence numberSequence = fileReader.GetNumberSequence();

            IList<BingoBoard> boards = fileReader.GetBingoBoards();
            IList<BingoBoard> ranking = new List<BingoBoard>();

            while (true)
            {
                int draw = numberSequence.GetNext();

                if (draw == -1)
                {
                    // no more draws left
                    break;
                }

                UpdateBoards(boards, draw);
                UpdateRanking(boards, ranking, draw);

                if (AllBoardsDone(boards))
                {
                    Console.WriteLine("All boards done");
                    break;
                }
            }

            Console.WriteLine("\nFirstWinner:");
            ranking.First().DumpFinalResult();

            Console.WriteLine("\nLastWinner:");
            ranking.Last().DumpFinalResult();
        }

        private static void UpdateRanking(IList<BingoBoard> boards, IList<BingoBoard> ranking, int draw)
        {
            var finishedBoards = boards.Where(b => b.Finished(draw));

            foreach (var board in finishedBoards)
            {
                if (!ranking.Contains(board))
                    ranking.Add(board);
            }
        }

        private static void UpdateBoards(IList<BingoBoard> boards, int draw)
        {
            foreach (var board in boards)
            {
                board.ProcessDraw(draw);
            }
        }

        private static bool AllBoardsDone(IList<BingoBoard> boards)
        {
            return boards.All(b => b.Finished());
        }
    }
}
