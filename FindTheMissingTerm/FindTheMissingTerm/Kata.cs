using System;
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
            Dsiplay(list);
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < list.Count - 1; i++)
            {
                int add = list[i + 1] - list[i];
                if (!dic.ContainsKey(add))
                {
                    dic[add] = 0;
                }
                dic[add]++;
            }



            var add1 = dic.FirstOrDefault(x => x.Value == dic.Values.Max()).Key;

            var count = dic.Where(x => x.Value == dic.Values.Max()).Count();
            if (count == 2)
            {
                add1 = dic.Keys.Min();
            }

            for (int i = 0; i < list.Count - 1; i++)
            {
                int next = list[i] + add1;
                if (next != list[i + 1])
                {
                    return next;
                }
            }

            return list[0];
        }

        static void Dsiplay(List<int> list)
        {
            Console.WriteLine(String.Join(",", list.Select(x => x)));
        }
    }
}
