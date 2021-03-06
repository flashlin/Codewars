﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleFun57_RunnersMeetings.Models;

namespace RunnersMeetingsTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void BasicTests()
        {
            var kata = new Kata();

            Assert.AreEqual(3, kata.RunnersMeetings(new int[] { 1, 4, 2 }, new int[] { 27, 18, 24 }));

            Assert.AreEqual(2, kata.RunnersMeetings(new int[] { 1, 4, 2 }, new int[] { 5, 6, 2 }));

            Assert.AreEqual(-1, kata.RunnersMeetings(new int[] { 1, 2, 3 }, new int[] { 1, 1, 1 }));

            Assert.AreEqual(2, kata.RunnersMeetings(new int[] { 1, 1000 }, new int[] { 23, 22 }));
        }

        [Test]
        public void RandomTest()
        {
            var kata = new Kata();

            Assert.AreEqual(2, kata.RunnersMeetings(
                new int[] { -42, 14, -41, -4 },
                new int[] { 18, 3, 29, 7 }));
        }

        [Test]
        public void RandomTest2()
        {
            var kata = new Kata();

            Assert.AreEqual(2, kata.RunnersMeetings(
                new int[] { 18, -17, 53, 42, -1, -38, -50, -49 },
                new int[] { 15, 28, 1, 29, 8, 13, 1, 20 }));
        }
    }
}
