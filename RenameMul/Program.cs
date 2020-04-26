using System;
using System.IO;
using System.Linq;

namespace RenameMul
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mode: mahoa/giaima");
            
            Console.WriteLine("Mode:");
            var mode = Console.ReadLine();
            
            Console.WriteLine("Password:");
            var path = Console.ReadLine();

            switch (mode)
            {
                case "mahoa":
                    Remove(path);
                    break;
                case "giaima":
                    Rename(path);
                    break;
                default:
                    Console.WriteLine("No more");
                    break;
            }

            Console.WriteLine("Done!!!!");
        }

        static void Remove(string pathFolder)
        {
            DirectoryInfo d = new DirectoryInfo(pathFolder);
            FileInfo[] infos = d.GetFiles();
            foreach (FileInfo f in infos)
            {
                if (f.FullName.Contains("."))
                {
                    File.Move(f.FullName, f.FullName.Remove(f.FullName.IndexOf('.')));
                }
            }
        }

        static void Rename(string pathFolder)
        {
            DirectoryInfo d = new DirectoryInfo(pathFolder);
            FileInfo[] infos = d.GetFiles();
            foreach (FileInfo f in infos)
            {
                if (!f.FullName.Contains("."))
                {
                    File.Move(f.FullName, f.FullName.Insert(f.FullName.Count(), ".jpg"));
                }
            }
        }
    }
}
