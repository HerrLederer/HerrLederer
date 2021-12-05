using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05_
{
    public class InputFileReader
    {
        private string fileName;

        public InputFileReader(string filename)
        {
            fileName = filename;
        }

        public void ProcessFileContent()
        {
            var fileContent = File.ReadAllLines(fileName);
            foreach (var line in fileContent)
            {
                new Line(line);
            }
        }
    }
}
