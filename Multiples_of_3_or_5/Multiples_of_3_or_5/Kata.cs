using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiples_of_3_or_5
{
    public class Kata
    {
        public static int Solution(int value)
        {
            if (value <= 0)
            {
                return 0;
            }
            var data = Enumerable.Range(1, value - 1);
            var query = from tb1 in data
                where tb1 % 3 == 0 || tb1 % 5 == 0
                select tb1;
            return query.Sum();
        }
    }
}
