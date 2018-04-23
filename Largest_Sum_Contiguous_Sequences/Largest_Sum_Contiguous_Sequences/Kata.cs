using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_Sum_Contiguous_Sequences
{
	public static class Kata
	{
		public static int LargestSum(int[] arr)
		{
			if (arr.Length <= 0)
			{
				return 0;
			}

			int max = 0;
			max = arr.Max(n => max = Math.Max(0, max + n));
			return max;
		}
	}
}
