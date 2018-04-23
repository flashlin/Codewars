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
			int max = 0, tmp = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				tmp += arr[i];

				if (max < tmp)
				{
					max = tmp;
				}

				if (tmp < 0)
				{
					tmp = 0;
				}
			}
			return max;
		}
	}
}
