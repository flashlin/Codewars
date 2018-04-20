using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountingChangeCombinations;

namespace CountingChangeCombinationsTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public static void SimpleCase()
        {
            Assert.AreEqual(3, Kata.CountCombinations(4, new[] { 1, 2 }));
        }

        [Test]
        public static void AnotherSimpleCase()
        {
            Assert.AreEqual(4, Kata.CountCombinations(10, new[] { 5, 2, 3 }));
        }

        [Test]
        public static void NoChange()
        {
            Assert.AreEqual(0, Kata.CountCombinations(11, new[] { 5, 7 }));
        }

        [Test]
        public static void Anther1022Case()
        {
            Assert.AreEqual(1022, Kata.CountCombinations(300, new[] { 500, 5, 50, 100, 20, 200, 10 }));
        }
    }
}
