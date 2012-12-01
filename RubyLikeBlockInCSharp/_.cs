using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubyLikeBlock
{
    public class _
    {
        /// <summary>
        /// Create one dimensional array in short-hand expression.
        /// </summary>
        /// <code>
        /// _.Ary(1, 2, 3); // equal to new int[] {1, 2, 3}
        /// </code>
        public static T[] Ary<T>(params T[] items)
        {
            return items;
        }
    }
}
