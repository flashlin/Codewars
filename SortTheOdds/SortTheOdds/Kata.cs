using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SortTheOdds
{
    public class Kata
    {
        public static int[] SortArray(int[] array)
        {
            var odds = AddOddsToList(array);
            array = PutOddsToArray(odds, array);
            return array;
        }

        public class Odd
        {
            public int Index { get; set; }
            public int Number { get; set; }
            public override string ToString()
            {
                return $"[{Index}]{Number}";
            }
        }

        private static int[] PutOddsToArray(List<Odd> odds, int[] array)
        {
            var oddsIndex = odds;
            odds = odds.OrderBy(x => x.Number).ToList();
            var result = new List<int>(array);
            var item = odds.GetEnumerator();
            item.MoveNext();
            foreach (var indexer in oddsIndex)
            {
                int idx = indexer.Index;
                result[idx] = item.Current.Number;
                item.MoveNext();
            }
            return result.ToArray();
        }

        private static List<Odd> AddOddsToList(int[] array)
        {
            var result = new List<Odd>();
            for(int idx=0; idx<array.Length; idx++)
            {
                int number = array[idx];
                if (IsOdds(number))
                {
                    var item = new Odd()
                    {
                        Index = idx,
                        Number = number
                    };
                    result.Add(item);
                }
            }
            return result;
        }

        public static bool IsOdds(int number)
        {
            if (number == 0) return false;
            if (number % 2 == 0) return false;
            return true;
        }
    }
}
