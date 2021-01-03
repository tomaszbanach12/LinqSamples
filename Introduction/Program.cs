using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows";
            Console.WriteLine("****Show large files without linq****");
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("****Show large files with linq****");
            ShowLargeFilesWithLinq(path);
        }
        private static void ShowLargeFilesWithoutLinq(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var fileInfoArray = directoryInfo.GetFiles();
            Array.Sort(fileInfoArray, new FileInfoComparer());

            for (int i = 0; i < 5; i++)
            {
                var fileInfo = fileInfoArray[i];
                Console.WriteLine($"{fileInfo.Name,-20} : {fileInfo.Length,-10:N0}");
            }
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(f => f.Length)
                        .Take(5);

            foreach (var fileInfo in query)
            {
                Console.WriteLine($"{fileInfo.Name,-20} : {fileInfo.Length,-10:N0}");
            }
        }

        public class FileInfoComparer : IComparer<FileInfo>
        {
            public int Compare([AllowNull] FileInfo x, [AllowNull] FileInfo y)
            {
                return y.Length.CompareTo(x.Length);
            }
        }
    }
}
