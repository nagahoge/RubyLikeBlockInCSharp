using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubyLikeBlock
{
    public static class IntExtensions
    {
        /// <summary>
        /// 指定した回数繰り返します。
        /// </summary>
        /// <code>
        /// int n = 100;
        /// 5.Times(() => n += 5); // ループ後、nは125になる
        /// </code>
        public static void Times(this int thisNum, Action func)
        {
            for (int currNum = 0; currNum < thisNum; currNum++)
            {
                func();
            }
        }

        /// <summary>
        /// 指定した回数繰り返します。lambda式には0から順にインデックス値が渡されます。
        /// </summary>
        /// <code>
        /// int n = 100;
        /// 5.Times(idx => n += idx); // 1ループ目はn=0, 2ループ目はn=1 ...
        /// </code>
        public static void Times(this int thisNum, Action<int> func)
        {
            for (int currNum = 0; currNum < thisNum; currNum++)
            {
                func(currNum);
            }
        }

        /// <summary>
        /// 指定した値から値までのint[]配列を生成する。
        /// </summary>
        /// <code>
        /// int[] intArray = 2.To(5); // int[] {2, 3, 4, 5}が生成される
        /// 2.To(5).Each(n => Console.WriteLine(n)); // ブロック等のループ処理に有効利用できる
        /// </code>
        public static int[] To(this int begin, int to)
        {
            List<int> list = new List<int>();

            for (int i = begin; i <= to; i++)
            {
                list.Add(i);
            }

            return list.ToArray();
        }
    }
}
