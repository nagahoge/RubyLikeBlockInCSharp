using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace RubyLikeBlock
{
    public static class ArrayExtensions
    {

        public static void Each<T>(this IEnumerable<T> self, Action<T> block)
        {
            foreach (T currItem in self)
            {
                block(currItem);
            }
        }

        public static void EachWithIndex<T>(
            this IEnumerable<T> self, Action<T, int> block)
        {
            int i = 0;

            foreach (T item in self)
            {
                block(item, i);
                i++;
            }
        }

        public static O[] Collect<T, O>(this IEnumerable<T> self, Func<T, O> block)
        {
            IList<O> list = new List<O>();

            self.Each(item =>
            {
                list.Add(block(item));
            });

            return list.ToArray();
        }

        
        // Count is specified in System.Linq namespace.
        // Count<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)


        public static T Find<T>(this IEnumerable<T> self, Func<T, bool> block)
        {
            foreach (T item in self)
            {
                if (block(item)) return item;
            }

            return default(T);
        }

        /// <summary>
        /// Same to ruby's Array#reverse!
        /// </summary>
        public static T[] Reverse<T>(this T[] self)
        {
            Array.Reverse(self);
            return self;
        }

        /// <summary>
        /// Create string[] array by using each element's ToString() method in an array.
        /// </summary>
        public static string[] ToStringArray<T>(this T[] self)
        {
            var result = new List<string>();
            self.Each(obj => result.Add(obj.ToString()));
            return result.ToArray();
        }

        /// <summary>
        /// Same to ruby's String#Join.
        /// </summary>
        public static string Join<T>(this IEnumerable<T> self, string sep = null)
        {
            return _Join(self, sep);
        }

        private static string _Join<T>(IEnumerable<T> self, string sep)
        {
            if (sep == null) sep = "";
            string result = "";

            self.EachWithIndex((item, idx) =>
            {
                string currentStringExpression;


                //if (item is Array)
                //{
                //    Type t = item.GetType().GetElementType();
                //    switch (item.GetType().GetElementType().ToString())
                //    {
                //        case typeof(int).ToString():

                //            break;
                //    }

                //    if (

                //    currentStringExpression = _Join((IEnumerable<t>)item, sep);
                //}
                //if (item is Array) currentStringExpression = Join(item, sep);
                if (item is Array) throw new NotImplementedException(); // TODO
                else if (item == null) currentStringExpression = "";
                else currentStringExpression = item.ToString();

                result += currentStringExpression;
                if (idx != self.Count() - 1) result += sep;
            });

            return result;
        }
    }
}
