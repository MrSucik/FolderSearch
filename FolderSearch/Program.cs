using System;
using System.Collections.Generic;
using System.IO;

namespace FolderSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = "C:/malodev";
            var fs = new FolderSearchProvider(path);
            var s = fs.ContainingFolders("XMLFile_onclick");
            Console.WriteLine("Done searching");
            foreach (var f in s)
            {
                Console.WriteLine($" ==== {f} ==== ");
            }
        }

    }
    public class FolderSearchProvider
    {
        public FolderSearchProvider(string rootFolderPath)
        {
            RootFolderPath = rootFolderPath;
        }

        public string RootFolderPath { get; }

        public List<string> ContainingFolders(string containment)
        {
            var files = Directory.EnumerateFiles(RootFolderPath, string.Empty, SearchOption.AllDirectories);
            var successes = new List<string>();
            foreach (var file in files)
            {
                try
                {
                    var contents = File.ReadAllText(file);
                    if (contents.Contains(containment))
                    {
                        Console.WriteLine($"Success with === {file} === ");
                        successes.Add(file);
                    }
                    else
                    {
                        Console.WriteLine($"Proccessed {file}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return successes;
        }
    }

    interface IFolderSearchLogger
    {
        void Log(string message);
    }
}
