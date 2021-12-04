using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05_
{
    public class InputFileReader
    {
        public InputFileReader(string fileName)
        {
            var fileContent = File.ReadAllLines(fileName);
        }
    }
}
