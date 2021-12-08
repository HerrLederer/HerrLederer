using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08_7_Digit_Display
{
    class EncodedInput
    {
        public EncodedInput(string[] encoding, string[] payload)
        {
            Encoding = encoding;
            Payload = payload;
        }

        public override string ToString()
        {
            return Serialize(Encoding) + "| " + Serialize(Payload);
        }

        private static string Serialize(string[] input)
        {
            string output = "";
            foreach (string pattern in input)
            {
                output += pattern + " ";
            }
            return output;
        }

        public static List<EncodedInput> CreateEncodedInputFromFile(string fileName)
        {
            List<EncodedInput> ret = new List<EncodedInput>();

            string[] fileContent = File.ReadAllLines(fileName);

            foreach (var line in fileContent)
            {
                int positionOfDelimiter = line.IndexOf('|');
                string encodingPart = line.Substring(0, positionOfDelimiter - 1);
                string trailingEnd = line.Substring(positionOfDelimiter + 1);
                string[] trailingEndArray = ConvertToSorted(trailingEnd.Trim().Split(' '));
                string[] encodingPartArray = ConvertToSorted(encodingPart.Trim().Split(' '));

                ret.Add(new EncodedInput(encodingPartArray, trailingEndArray));
            }
            return ret;
        }

        public string[] Encoding;
        public string[] Payload;

        public static string[] ConvertToSorted(string[] input)
        {
            string[] sortedOutput = { };
            foreach (string pattern in input)
            {
                string sortedPattern = SortPattern(pattern);
                sortedOutput = sortedOutput.Append(sortedPattern).ToArray();
            }
            return sortedOutput;
        }

        public static string SortPattern(string pattern)
        {
            char[] array = pattern.ToCharArray();
            Array.Sort(array);
            return new string(array);
        }

        public int Count1478()
        {
            return Payload.Where(i => decode(i) != -1).Count();
        }

        private static int decode(string encoding)
        {
            if (encoding.Length == 2)
                return 1;
            if (encoding.Length == 3)
                return 7;
            if (encoding.Length == 4)
                return 4;
            if (encoding.Length == 7)
                return 8;

            Console.WriteLine("Could not decode encoding '" + encoding + "'");
            return -1;
        }
    }
}
