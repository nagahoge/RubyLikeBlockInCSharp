using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using RubyLikeBlock;

namespace UnitTest
{
    [TestClass]
    public class IOTest
    {
        [TestMethod]
        public void TestForeach()
        {
            const string path = "FileExtensionTest_TestForeachData.txt";
            string[] lines = _.Ary("First line.", "Second line.", "Third line.");

            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                lines.Each(str => writer.WriteLine(str));
            }

            CollectionAssert.AreEqual(lines, IO.Foreach(path, Encoding.UTF8));


            lines = new string[] { };
            using (var writer = new StreamWriter(path, false, Encoding.UTF8)){}
            CollectionAssert.AreEqual(lines, IO.Foreach(path, Encoding.UTF8));
        }
    }
}
