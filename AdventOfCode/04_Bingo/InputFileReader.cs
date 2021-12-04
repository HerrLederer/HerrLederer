using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Bingo
{
    public class InputFileReader
    {
        public InputFileReader(string fileName)
        {
            var fileContent = File.ReadAllLines(fileName);
            var firstLine = fileContent[0];
            NumberSequence = new NumberSequence(firstLine);
            fileContent = fileContent.Skip(1).ToArray();

            IList<string> boardContent = new List<string>();

            foreach(string line in fileContent)
            {
                if(line.Length <= 1)
                {
                    // this is an empty line. Close the current board.
                    if (boardContent.Count > 1)
                    {
                        Boards.Add(new BingoBoard(boardContent.ToArray()));
                        boardContent.Clear();
                    }
                }
                else if(line == fileContent[fileContent.Length - 1] && line.Length > 1)
                {
                    // for the very last line without \n at the end
                    boardContent.Add(line);
                    Boards.Add(new BingoBoard(boardContent.ToArray()));
                }
                else
                    boardContent.Add(line);
            }
        }

        private IList<BingoBoard> Boards = new List<BingoBoard>();

        public IList<BingoBoard> GetBingoBoards()
        {
            return Boards;
        }

        private NumberSequence NumberSequence = null;

        public NumberSequence GetNumberSequence()
        {
            return NumberSequence;
        }
    }
}
