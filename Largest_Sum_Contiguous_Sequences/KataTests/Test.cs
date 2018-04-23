using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Largest_Sum_Contiguous_Sequences;

namespace KataTests
{
	[TestFixture]
	public class Test
	{
		[TestCase(new[] { -1, -2, -3 }, ExpectedResult = 0)]
		[TestCase(new int[0], ExpectedResult = 0)]
		[TestCase(new[] { 1, 2, 3, 4 }, ExpectedResult = 10)]
		[TestCase(new[] { 31, -41, 59, 26, -53, 58, 97, -93, -23, 84 }, ExpectedResult = 187)]
		public int TestFromDescription(int[] arr)
		{
			return Kata.LargestSum(arr);
		}
	}
}
