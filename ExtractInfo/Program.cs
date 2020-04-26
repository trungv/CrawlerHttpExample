using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExtractInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Password: ");
            var path = Console.ReadLine();

            var content = File.ReadAllText(path);

            var partern = @"\w+\@\w+\.\w+";
            var matches = Regex.Matches(content, partern);
            var checkList = new HashSet<string>();

            using (TextWriter tw = new StreamWriter(@"D:\email.txt"))
            {
                foreach (var item in matches)
                {
                    var value = item.ToString();
                    if (checkList.Add(value))
                    {
                        tw.WriteLine(value);
                    }
                }
            }
        }

        void GetInfo()
        {

        }
    }
}
