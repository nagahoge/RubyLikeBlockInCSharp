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

        
        // CountメソッドはSystem.Linq名前空間で定義されている
        // Count<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)


        public static T Find<T>(this IEnumerable<T> self, Func<T, bool> block)
        {
            foreach (T item in self)
            {
                if (block(item)) return item;
            }

            return default(T);
        }
    }
}
