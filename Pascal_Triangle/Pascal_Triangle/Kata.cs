using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascal_Triangle
{
    public class Kata
    {
        public static List<int> PascalsTriangle(int n)
        {
            Console.WriteLine(n);
            return PascalsTriangleDeep(n);
        }

        public static List<int> PascalsTriangleDeep(int n)
        {
            if (n == 1)
            {
                return PascalsTriangleLevel(1);
            }

            if (n == 2)
            {
                var level2 = PascalsTriangleLevel(2);
                var level1 = PascalsTriangleLevel(1);
                level1.AddRange(level2);
                return level1;
            }

            var prev = PascalsTriangleDeep(n - 1);
            prev.AddRange(PascalsTriangleLevel(n));
            return prev;
        }

        public static List<int> PascalsTriangleLevel(int n)
        {
            if (n <= 0)
            {
                return new List<int>();
            }

            if (n == 1)
            {
                return new List<int> { 1 };
            }

            if (n == 2)
            {
                return new List<int> { 1, 1 };
            }

            var prevLevel = PascalsTriangleLevel(n - 1);
            var level = new List<int>();
            level.Add(1);
            for (int i = 0; i < prevLevel.Count - 1; i++)
            {
                var val = prevLevel[i] + prevLevel[i + 1];
                level.Add(val);
            }
            level.Add(1);
            return level;
        }
    }
}
