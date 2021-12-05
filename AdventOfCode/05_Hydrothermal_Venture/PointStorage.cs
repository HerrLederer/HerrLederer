using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_
{
    static class PointStorage
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
