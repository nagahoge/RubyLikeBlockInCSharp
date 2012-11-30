using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubyLikeBlock
{
    public static class StringExtensions
    {
        public static string[] Split(this string self, string separator, int limit = 0)
        {
            if (self == "") return new string[] { };
            if (separator == null) separator = " ";


            string[] splitted;
            
            switch (separator)
            {
                case " ":
                    splitted = self.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case "":
                    splitted = self.ToCharArray().ToStringArray();
                    break;
                default:
                    splitted = self.Split(new string[] { separator }, StringSplitOptions.None);
                    break;
            }

            if (limit < 0)
            {

            }
            else if (limit == 0 && splitted.Length >= 1)
            {
                var list = splitted.ToList();

                while (list.Last() == "")
                {
                    list.RemoveAt(list.Count - 1);
                }

                splitted = list.ToArray();
            }
            else
            {
                var list = splitted.ToList();
                var outOfLimitList = new List<string>();
                

                (list.Count - 1).To(limit - 1).Each(idx =>
                {
                    outOfLimitList.Insert(0, list[idx]);
                    list.RemoveAt(idx);
                });

                list.Add(outOfLimitList.Join(separator));

                splitted = list.ToArray();
            }
            


            return splitted;
        }
    }
}
