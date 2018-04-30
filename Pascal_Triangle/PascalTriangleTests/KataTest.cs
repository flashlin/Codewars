using NUnit.Framework;
using Pascal_Triangle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangleTests
{
    [TestFixture]
    public class KataTest
    {
        [Test]
        public static void Level1()
        {
            CollectionAssert.AreEqual(
                new List<int> { 1 },
                Kata.PascalsTriangle(1));
        }

        [Test]
        public static void Level3()
        {
            CollectionAssert.AreEqual(
                new List<int> { 1, 1, 1, 1, 2, 1 },
                Kata.PascalsTriangle(3));
        }

        [Test]
        public static void Level5()
        {
            CollectionAssert.AreEqual(
                new List<int> {
                    1,
                    1, 1,
                    1, 2, 1,
                    1, 3, 3, 1,
                    1, 4, 6, 4, 1 },
                Kata.PascalsTriangle(5));
        }
    }
}
