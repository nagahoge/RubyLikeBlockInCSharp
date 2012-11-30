using RubyLikeBlock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass()]
    public class StringExtensionsTest
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


        /// <summary>
        /// String#Split(String separator, int limit = 0) behave as same as ruby's String#split method.
        /// Now this library support only string separator.
        /// 
        /// ruby/test/ruby/test_string.rb
        /// 
        /// assert_nil($;)
        /// assert_equal([S("a"), S("b"), S("c")], S(" a   b\t c ").split)
        /// assert_equal([S("a"), S("b"), S("c")], S(" a   b\t c ").split(S(" ")))
        /// 
        /// assert_equal([S(" a "), S(" b "), S(" c ")], S(" a | b | c ").split(S("|")))
        /// 
        /// assert_equal([S("a"), S("b"), S("c")], S("aXXbXXcXX").split(/X./))
        /// 
        /// assert_equal([S("a"), S("b"), S("c")], S("abc").split(//))
        /// 
        /// assert_equal([S("a|b|c")], S("a|b|c").split(S('|'), 1))
        /// 
        /// assert_equal([S("a"), S("b|c")], S("a|b|c").split(S('|'), 2))
        /// assert_equal([S("a"), S("b"), S("c")], S("a|b|c").split(S('|'), 3))
        /// 
        /// assert_equal([S("a"), S("b"), S("c"), S("")], S("a|b|c|").split(S('|'), -1))
        /// assert_equal([S("a"), S("b"), S("c"), S(""), S("")], S("a|b|c||").split(S('|'), -1))
        /// 
        /// assert_equal([S("a"), S(""), S("b"), S("c")], S("a||b|c|").split(S('|')))
        /// assert_equal([S("a"), S(""), S("b"), S("c"), S("")], S("a||b|c|").split(S('|'), -1))
        /// 
        /// assert_equal([], "".split(//, 1))
        /// 
        /// assert_equal("[2, 3]", [1,2,3].slice!(1,10000).inspect, "moved from btest/knownbug")
        /// 
        /// bug6206 = '[ruby-dev:45441]'
        /// Encoding.list.each do |enc|
        ///   next unless enc.ascii_compatible?
        ///   s = S("a:".force_encoding(enc))
        ///   assert_equal([enc]*2, s.split(":", 2).map(&:encoding), bug6206)
        /// end
        /// </summary>
        [TestMethod()]
        public void TestSplit()
        {
            //Assert.AreEqual(new string[] { "a", "b", "c" }, " a   b\t c ".Split(null)); // null param call .NET API default method.
            CollectionAssert.AreEqual(new string[] { "a", "b", "c" }, " a   b\t c ".Split(" "));

            CollectionAssert.AreEqual(new string[] { " a ", " b ", " c " }, " a | b | c ".Split("|"));

            CollectionAssert.AreEqual(new string[] { "a|b|c" }, "a|b|c".Split("|", 1));
            CollectionAssert.AreEqual(new string[] { "a", "b|c" }, "a|b|c".Split("|", 2));
            CollectionAssert.AreEqual(new string[] { "a", "b", "c" }, "a|b|c".Split("|", 3));

            CollectionAssert.AreEqual(new string[] { "a", "b", "c", "" }, "a|b|c|".Split("|", -1));
            CollectionAssert.AreEqual(new string[] { "a", "b", "c", "", "" }, "a|b|c||".Split("|", -1));
            //                        
            // belows are original tests

            CollectionAssert.AreEqual(
                _.Ary("I am a pen.", "You are also a pen."), 
                "I am a pen.<br />You are also a pen.<br />".Split("<br />"));

            // irb(main):001:0> ''.split('')
            // => []
            // irb(main):002:0> ''.split('a')
            // => []
            // irb(main):003:0> ''.split(nil)
            // => []
            // irb(main):004:0> ''.split(' ')
            // => []
            CollectionAssert.AreEqual(new string[] { }, "".Split("", 1));

            // irb(main):005:0> 'a  b'.split('')
            // => ["a", " ", " ", "b"]
            CollectionAssert.AreEqual(new string[] { "a", "|", "b", "|", "c" }, "a|b|c".Split("", -1));
        }

    }
}
