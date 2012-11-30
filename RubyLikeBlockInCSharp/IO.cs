using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RubyLikeBlock
{
    public class IO
    {
        public static void Foreach(string path, Encoding encoding, Action<string> block)
        {
            using (var reader = new StreamReader(path, encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    block(line);
                }
            }
        }

        public static string[] Foreach(string path, Encoding encoding)
        {
            var lines = new List<string>();
            IO.Foreach(path, encoding, line => lines.Add(line));
            return lines.ToArray();
        }

        public static void Foreach(string path, Action<string> block)
        {
            IO.Foreach(path, Encoding.Default, block);
        }

        public static void Foreach(string path)
        {
            IO.Foreach(path, Encoding.Default);
        }
    }
}
