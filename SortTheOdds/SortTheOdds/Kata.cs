using System;
using System.Collections.Generic;

namespace SortTheOdds
{
    public class Kata
    {
        public static int[] SortArray(int[] array)
        {
            var odds = new List<int>();
            var oddsIndex = new List<int>();
            AddOddsToList(array, odds, oddsIndex);
            odds.Sort();
            PutOddsToArray(odds, oddsIndex, array);
            return array;
        }

        private static void PutOddsToArray(List<int> odds, List<int> oddsIndex, int[] array)
        {
            for (int n = 0; n < odds.Count; n++)
            {
                int idx = oddsIndex[n];
                array[idx] = odds[n];
            }
        }

        private static void AddOddsToList(int[] array, List<int> odds, List<int> oddsIndex)
        {
            for(int idx=0; idx<array.Length; idx++)
            {
                int number = array[idx];
                if (IsOdds(number))
                {
                    oddsIndex.Add(idx);
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
