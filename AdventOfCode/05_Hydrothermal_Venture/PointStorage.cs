
using System.Collections.Generic;
using System.Linq;

namespace _05_Hydrothermal_Venture
{
    static internal class PointStorage
    {
        private static IDictionary<Point, int> storage = new Dictionary<Point, int>();

        public static void Add(Point p)
        {
            if(storage.ContainsKey(p))
            {
                storage[p]++;
            }
            else
            {
                storage.Add(p, 1);
            }
        }

        public static Point[] GetIntersections()
        {
            return storage.Where(p => p.Value > 1).Select(p => p.Key).ToArray();
        }
    }
}
