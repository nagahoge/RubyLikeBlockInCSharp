using RubyLikeBlock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass()]
    public class IDictionaryExtensionsTest
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

        private IDictionary<string, int> numberDict;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            numberDict = new Dictionary<string, int>() {
                {"nothing", 0},
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"hundred", 100}
            };
        }

        [TestMethod()]
        public void EachTest()
        {
            int count = 0;
            var keyList = new List<string>();
            var valueList = new List<int>();

            var returnedValue = numberDict.Each((key, value) =>
            {
                count++;
                keyList.Add(key);
                valueList.Add(value);
            });

            Assert.AreEqual(6, count);
            Assert.IsTrue((new string[] {"nothing", "one", "two", "three", "four", "hundred"}).SequenceEqual(keyList));
            Assert.IsTrue((new int[] {0, 1, 2, 3, 4, 100}).SequenceEqual(valueList));
            Assert.AreSame(numberDict, returnedValue);
        }

        [TestMethod()]
        public void EachWithCountTest()
        {
            var keyList = new List<string>();
            var valueList = new List<int>();
            var countList = new List<long>();

            var returnedValue = numberDict.EachWithCount((key, value, count) =>
            {
                keyList.Add(key);
                valueList.Add(value);
                countList.Add(count);
            });

            Assert.IsTrue((new string[] { "nothing", "one", "two", "three", "four", "hundred" }).SequenceEqual(keyList));
            Assert.IsTrue((new int[] { 0, 1, 2, 3, 4, 100 }).SequenceEqual(valueList));
            Assert.IsTrue((new long[] { 0, 1, 2, 3, 4, 5 }).SequenceEqual(countList));
        }

        [TestMethod()]
        public void KeepIfTest()
        {
            var returnedValue = numberDict.KeepIf((key, val) =>
            {
                return val % 2 == 0; // keep even numbers. drop odd numbers.
            });

            var keyList = new List<string>();
            var valueList = new List<int>();
            int count = 0;

            numberDict.Each((key, val) =>
            {
                keyList.Add(key);
                valueList.Add(val);
                count++;
            });

            Assert.AreSame(numberDict, returnedValue);
            Assert.IsTrue((new string[] {"nothing", "two", "four", "hundred" }).SequenceEqual(keyList));
            Assert.IsTrue((new int[] { 0, 2, 4, 100}).SequenceEqual(valueList));
            Assert.AreEqual(4, numberDict.Count);
        }

        [TestMethod()]
        public void RemoveIfTest()
        {
            var returnedValue = numberDict.RemoveIf((key, val) =>
            {
                return val % 2 == 1; // keep even numbers. drop odd numbers.
            });

            var keyList = new List<string>();
            var valueList = new List<int>();
            int count = 0;

            numberDict.Each((key, val) =>
            {
                keyList.Add(key);
                valueList.Add(val);
                count++;
            });

            Assert.AreSame(numberDict, returnedValue);
            Assert.IsTrue((new string[] { "nothing", "two", "four", "hundred" }).SequenceEqual(keyList));
            Assert.IsTrue((new int[] { 0, 2, 4, 100 }).SequenceEqual(valueList));
            Assert.AreEqual(4, numberDict.Count);
        }
    }
}
