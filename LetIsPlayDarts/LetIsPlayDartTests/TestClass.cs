using LetIsPlayDarts.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetIsPlayDartTests
{
    [TestFixture]
    public class TestClass
    {
        [TestCase("X", -133.69, -147.38)]
        [TestCase("DB", 4.06, 0.71)]
        [TestCase("SB", 2.38, -6.06)]
        [TestCase("20", -5.43, 117.95)]
        [TestCase("7", -73.905, -95.94)]
        [TestCase("T2", 55.53, -87.95)]
        [TestCase("D9", -145.19, 86.53)]
        [TestCase("13", 87.868, 23.420)]
        public void GetScoreTest(string expected, double x, double y)
        {
            var dartboard = new Dartboard();
            Assert.AreEqual(expected, dartboard.GetScore(x, y));
        }
    }
}
