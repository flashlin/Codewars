using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWordsTests
{
	[TestFixture]
	public class KataTest
	{
		[Test]
		public void Example()
		{
			Assert.AreEqual("sihT si na !elpmaxe", Kata.ReverseWords("This is an example!"));
		}
	}
}
