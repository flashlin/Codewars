using NUnit.Framework;
using SortTheOdds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTheOddsTests
{
    [TestFixture]
    public class Test1
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(new int[] { 1, 3, 2, 8, 5, 4 }, Kata.SortArray(new int[] { 5, 3, 2, 8, 1, 4 }));
            Assert.AreEqual(new int[] { 1, 3, 5, 8, 0 }, Kata.SortArray(new int[] { 5, 3, 1, 8, 0 }));
            Assert.AreEqual(new int[] { }, Kata.SortArray(new int[] { }));
        }
    }
}
