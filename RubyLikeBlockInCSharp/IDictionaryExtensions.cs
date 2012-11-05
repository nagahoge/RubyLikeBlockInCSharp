using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubyLikeBlock
{
    public static class IDictionaryExtensions
    {
        /// <summary>
        /// ported from ruby's Hash#each
        /// http://doc.ruby-lang.org/ja/1.9.3/method/Hash/i/each.html
        /// </summary>
        public static IDictionary<K, V> Each<K, V>(this IDictionary<K, V> dict, Action<K, V> proc)
        {
            foreach (KeyValuePair<K, V> pair in dict)
            {
                proc(pair.Key, pair.Value);
            }
            return dict;
        }

        // original method.
        public static IDictionary<K, V> EachWithCount<K, V>(this IDictionary<K, V> dict, Action<K, V, long> proc)
        {
            long count = 0;

            dict.Each((key, val) => proc(key, val, count++));

            return dict;
        }

        /// <summary>
        /// ported from ruby's Hash#keep_if 
        /// http://doc.ruby-lang.org/ja/1.9.3/method/Hash/i/keep_if.html
        /// </summary>
        public static IDictionary<K, V> KeepIf<K, V>(this IDictionary<K, V> dict, Func<K, V, bool> proc)
        {
            IList<K> keysToBeRemoved = new List<K>();

            dict.Each((key, val) => 
            {
                if (!proc(key, val)) keysToBeRemoved.Add(key);
            });

            keysToBeRemoved.Each(key => dict.Remove(key));

            return dict;
        }

        /// <summary>
        /// Remove keys that are matched to proc dondition.
        /// Opposite of KeepIf method.
        /// </summary>
        public static IDictionary<K, V> RemoveIf<K, V>(this IDictionary<K, V> dict, Func<K, V, bool> proc)
        {
            IList<K> keysToBeRemoved = new List<K>();

            dict.Each((key, val) =>
            {
                if (proc(key, val)) keysToBeRemoved.Add(key);
            });

            keysToBeRemoved.Each(key => dict.Remove(key));

            return dict;
        }
    }
}
