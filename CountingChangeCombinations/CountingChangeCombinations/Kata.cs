using System;
using System.Linq;

namespace CountingChangeCombinations
{
    public class Kata
    {
        public static int CountCombinations(int money, int[] coins)
        {
            int n = FindCombination(money, coins, 0);
            return n;
        }

        private static int FindCombination(int money, int[] coins, int checkIndex)
        {
            if (money == 0) return 1;

            if (money < 0 || coins.Length == checkIndex)
            {
                return 0;
            }

            int firstCoin = FindCombination(money - coins[checkIndex], coins, checkIndex);
            int withoutFirstCoin = FindCombination(money, coins, checkIndex + 1);
            return firstCoin + withoutFirstCoin;
        }

        void Display(int money, int[] coins)
        {
            Console.WriteLine("{0}-{1}", money, String.Join(",", coins.Select(x => x.ToString()).ToArray()));
        }
    }
}
