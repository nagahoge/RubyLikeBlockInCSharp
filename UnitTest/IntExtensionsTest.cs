using RubyLikeBlock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass()]
    public class IntExtensionsTest
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
        public void TimesTest_NoArguments()
        {
            int n = 100;
            5.Times(() => n += 5);

            Assert.AreEqual(125, n);
        }

        [TestMethod()]
        public void TimesTest_OneArgument()
        {
            int n = 100;
            5.Times(idx => n += idx);

            Assert.AreEqual(110, n);
        }

        [TestMethod()]
        public void ToTest()
        {
            Assert.AreEqual(35, 30.To(40).Find(n => n % 7 == 0));
            Assert.AreEqual(5, 5.To(9).Length);

            CollectionAssert.AreEqual(new int[] { 3, 2, 1 }, 3.To(1));
        }
    }
}
