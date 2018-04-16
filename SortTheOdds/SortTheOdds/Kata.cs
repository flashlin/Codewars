using System;
using System.Collections.Generic;

namespace SortTheOdds
{
    public class Kata
    {
        public static int[] SortArray(int[] array)
        {
            var odds = new List<int>();
            AddOddsToList(array, odds);

            odds.Sort();

            int idx = 0;
            var result = new List<int>();
            foreach (var number in array)
            {
                if (IsOdds(number))
                {
                    result.Add(odds[idx]);
                    idx++;
                }
                else
                {
                    result.Add(number);
                }
            }
            return result.ToArray();
        }

        private static void AddOddsToList(int[] array, List<int> odds)
        {
            foreach (var number in array)
            {
                if (IsOdds(number))
                {
                    odds.Add(number);
                }
            }
        }

        public static bool IsOdds(int number)
        {
            if (number == 0) return false;
            if (number % 2 == 0) return false;
            return true;
        }
    }
}
