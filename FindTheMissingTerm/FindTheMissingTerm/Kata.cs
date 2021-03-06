﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheMissingTerm
{
    public class Kata
    {
        public static int FindMissing(List<int> list)
        {
            var incrementCounter = new Dictionary<int, int>();
            ComputeIncrementCount(list, incrementCounter);

            int add = GetMissingIncrment(incrementCounter);

            for (int i = 0; i < list.Count - 1; i++)
            {
                int next = list[i] + add;
                if (next != list[i + 1])
                {
                    return next;
                }
            }

            return list[0];
        }

        private static void ComputeIncrementCount(List<int> list, Dictionary<int, int> incrementCounter)
        {
            int add;
            for (int i = 0; i < list.Count - 1; i++)
            {
                add = list[i + 1] - list[i];
                if (!incrementCounter.ContainsKey(add))
                {
                    incrementCounter[add] = 0;
                }

                incrementCounter[add]++;
            }
        }

        private static int GetMissingIncrment(Dictionary<int, int> incrementCounter)
        {
            int add;
            add = GetMostMissingIncrement(incrementCounter);
            if (IsIncrementSameCount(incrementCounter))
            {
                add = GetMissingMinIncrement(incrementCounter);
            }

            return add;
        }

        private static int GetMissingMinIncrement(Dictionary<int, int> incrementCounter)
        {
            return incrementCounter.Keys.Min();
        }

        private static int GetMostMissingIncrement(Dictionary<int, int> incrementCounter)
        {
            var add1 = incrementCounter.FirstOrDefault(x => x.Value == incrementCounter.Values.Max()).Key;
            return add1;
        }

        private static bool IsIncrementSameCount(Dictionary<int, int> incrementCounter)
        {
            var count = incrementCounter.Where(x => x.Value == incrementCounter.Values.Max()).Count();
            return count == 2;
        }

        static void Dsiplay(List<int> list)
        {
            Console.WriteLine(String.Join(",", list.Select(x => x)));
        }
    }
}
