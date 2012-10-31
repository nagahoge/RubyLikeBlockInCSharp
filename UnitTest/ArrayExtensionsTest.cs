using RubyLikeBlock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass()]
    public class ArrayExtensionsTest
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
        public void EachTest()
        {
            string[] stringArray = new string[] {"1", "2", "100", "-100"};
            IList<int> list = new List<int>();

            stringArray.Each(item => {
                list.Add(int.Parse(item));
            });

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(100, list[2]);
            Assert.AreEqual(-100, list[3]);
        }

        [TestMethod()]
        public void EachWithIndexTest()
        {
            string[] stringArray = new string[] {"David", "Koizumi", "Mike"};
            IList<string> list = new List<string>();

            stringArray.EachWithIndex((str, idx) => {
                list.Add("No." + idx + " " + str);
            });

            Assert.AreEqual("No.0 David", list[0]);
            Assert.AreEqual("No.1 Koizumi", list[1]);
            Assert.AreEqual("No.2 Mike", list[2]);
        }


        [TestMethod()]
        public void FindTest_StringArray()
        {
            string[] stringArray = new String[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            Assert.AreEqual("Tue", stringArray.Find(item => item.StartsWith("T")));
            Assert.IsNull(stringArray.Find(item => item.StartsWith("Z")));
        }

        [TestMethod()]
        public void FindTest_IntArray()
        {
            int[] intArray = new int[] { 4, 5, 6, 7, 8, 9, 10 };
            Assert.AreEqual(6, intArray.Find(item => item % 3 == 0));
            Assert.AreEqual(0, intArray.Find(item => false));
        }

        [TestMethod()]
        public void FindTest_NullableIntArray()
        {
            int?[] nullableIntArray = new int?[] { 3, 2, 1, 0, -1, -2, -3, -2, -1, 0 };
            Assert.AreEqual(-1, nullableIntArray.Find(item => item < 0));
            Assert.IsNull(nullableIntArray.Find(item => false));
        }


        [TestMethod()]
        public void CollectTest_StringArray()
        {
            string[] stringArray = new string[] {"I am a champion!", "You are a looser."};
            string[] collectedArray = stringArray.Collect(str => str.ToUpper());

            Assert.AreEqual("I AM A CHAMPION!", collectedArray[0]);
            Assert.AreEqual("YOU ARE A LOOSER.", collectedArray[1]);
        }

        [TestMethod()]
        public void CollectTest_DoubleArray()
        {
            double[] doubleArray = new double[] {3.14, 5, 9.99, 1.23};
            int[] collectedArray = doubleArray.Collect(item => (int)Math.Round(item));

            Assert.AreEqual(3, collectedArray[0]);
            Assert.AreEqual(5, collectedArray[1]);
            Assert.AreEqual(10, collectedArray[2]);
            Assert.AreEqual(1, collectedArray[3]);
        }


        

    }
}
