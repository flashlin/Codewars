using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnagramDetection;

namespace AnagramDetectionTests
{
    [TestFixture]
    public class Test1
    {
        [Test]
        [TestCase("foefet", "toffee", ExpectedResult = true)]
        [TestCase("Buckethead", "DeathCubeK", ExpectedResult = true)]
        [TestCase("Twoo", "Woot", ExpectedResult = true)]
        [TestCase("apple", "pale", ExpectedResult = false)]
        public bool FixedTest(string test, string original)
        {
            return Kata.IsAnagram(test, original);
        }
    }
}
