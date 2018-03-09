using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelbinTextures
{
    class Program
    {
        private static char[] allowedChars = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();

        static void Main(string[] args)
        {
            DumpTextureReferences(args[0]);
            Console.ReadLine();
        }

        private static void DumpTextureReferences(string path)
        {
            var bytes = File.ReadAllBytes(path);
            string byteSTR = Encoding.Default.GetString(bytes);
            var sb = new StringBuilder();
            bool wasLastCharTrue = false;
            foreach (char x in byteSTR)
            {
                if (!wasLastCharTrue) { sb.Append(""); }
                if (allowedChars.Contains(x) || x.ToString() == "\\" || x.ToString() == ":" || x.ToString() == "." || x.ToString() == "_")
                {
                    sb.Append(x);
                }
                else
                {
                    wasLastCharTrue = false;
                }
            }
            var split = sb.ToString().Split(new[] { "game" }, StringSplitOptions.None);
            foreach (var item in split)
            {
                Console.WriteLine($"{item.Replace(":", "game:")} {Environment.NewLine}");
            }
        }
    }
}
