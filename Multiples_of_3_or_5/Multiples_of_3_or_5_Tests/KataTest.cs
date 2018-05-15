using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiples_of_3_or_5;

namespace Multiples_of_3_or_5_Tests
{
    [TestFixture]
    public class KataTest
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(23, Kata.Solution(10));
        }
    }
}
