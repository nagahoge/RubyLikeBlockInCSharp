using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubyLikeBlock
{
    public static class LongExtensions
    {
        /// <summary>
        /// Repeat specified times.
        /// </summary>
        /// <code>
        /// int n = 100;
        /// 5.Times(() => n += 5); // after loop, n will be 125
        /// </code>
        public static void Times(this long thisNum, Action func)
        {
            for (long currNum = 0; currNum < thisNum; currNum++)
            {
                func();
            }
        }

        /// <summary>
        /// Repeat specified times, with index count.
        /// </summary>
        /// <code>
        /// int n = 100;
        /// 5.Times(idx => n += idx); // at first loop, n is set 0, second of loop, n is set 1 ...
        /// </code>
        public static void Times(this long thisNum, Action<long> func)
        {
            for (long currNum = 0; currNum < thisNum; currNum++)
            {
                func(currNum);
            }
        }

        /// <summary>
        /// 指定した値から値までのlong[]配列を生成する。
        /// </summary>
        /// <code>
        /// int[] intArray = 2.To(5); // int[] {2, 3, 4, 5}
        /// 2.To(5).Each(n => Console.WriteLine(n)); // 2\n3\n4\n5\n
        /// </code>
        public static long[] To(this long begin, long to)
        {
            if (begin > to) return to.To(begin).Reverse();

            IList<long> list = new List<long>();

            for (long i = begin; i <= to; i++)
            {
                list.Add(i);
            }

            return list.ToArray();
        }
    }
}
