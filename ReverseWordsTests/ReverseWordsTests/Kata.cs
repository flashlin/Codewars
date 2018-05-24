using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWordsTests
{
	public static class Kata
	{
		public static string ReverseWords(string str)
		{
			string[] words = str.Split(' ');
			var q1 = words.Select(x => Reverse(x));
			return string.Join(" ", q1);
		}

		public static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
	}
}
