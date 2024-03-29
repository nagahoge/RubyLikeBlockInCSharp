﻿using RubyLikeBlock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass()]
    public class LongExtensionsTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void TestTimes()
        {
            long n = 100;
            5L.Times(() => n += 5);
            Assert.AreEqual(125, n);

            n = 100;
            5L.Times(idx => n += idx);
            Assert.AreEqual(110, n);
        }

        [TestMethod()]
        public void TestTo()
        {
            Assert.AreEqual(35, 30L.To(40L).Find(n => n % 7 == 0));
            Assert.AreEqual(5, 5L.To(9L).Length);

            CollectionAssert.AreEqual(new long[] { 1, 0, -1, -2 }, 1L.To(-2L));
        }
    }
}
