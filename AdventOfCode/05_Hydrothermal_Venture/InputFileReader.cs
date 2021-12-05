using System.IO;

namespace _05_Hydrothermal_Venture
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
                Line.CreateLineFromInput(line);
            }
        }
    }
}
