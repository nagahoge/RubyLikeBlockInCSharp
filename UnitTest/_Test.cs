using Microsoft.VisualStudio.TestTools.UnitTesting;
using RubyLikeBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace UnitTest
{
    [TestClass()]
    public class _Test
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            { return testContextInstance; }
            set
            { testContextInstance = value; }
        }

        [TestMethod()]
        public void TestAry()
        {
            CollectionAssert.AreEqual(new string[] { "a", "b", "c" }, _.Ary("a", "b", "c"));
            CollectionAssert.AreEqual(new int[] { 1 }, _.Ary(1));
            CollectionAssert.AreEqual(new long[] { 2L, 3L }, _.Ary(2L, 3L));
            CollectionAssert.AreNotEqual(new int[] { 2, 3 }, _.Ary(2L, 3L));
        }
    }
}
