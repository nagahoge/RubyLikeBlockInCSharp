using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubyLikeBlock
{
    public static class IntExtensions
    {
        /// <summary>
        /// Repeat specified times.
        /// </summary>
        /// <code>
        /// int n = 100;
        /// 5.Times(() => n += 5); // after loop, n will be 125
        /// </code>
        public static void Times(this int thisNum, Action func)
        {
            ((long)thisNum).Times(func);
        }

        /// <summary>
        /// Repeat specified times, with index count.
        /// </summary>
        /// <code>
        /// int n = 100;
        /// 5.Times(idx => n += idx); // at first loop, n is set 0, second of loop, n is set 1 ...
        /// </code>
        public static void Times(this int thisNum, Action<int> func)
        {
            for (int currNum = 0; currNum < thisNum; currNum++)
            {
                func(currNum);
            }
        }

        /// <summary>
        /// Make an array from specified number to number.
        /// </summary>
        /// <code>
        /// int[] intArray = 2.To(5); // int[] {2, 3, 4, 5}
        /// 2.To(5).Each(n => Console.WriteLine(n)); // 2\n3\n4\n5\n
        /// </code>
        public static int[] To(this int begin, int to)
        {
            if (begin > to) return to.To(begin).Reverse();

            List<int> list = new List<int>();

            for (int i = begin; i <= to; i++)
            {
                list.Add(i);
            }

            return list.ToArray();
        }
    }
}
