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
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("*******");
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var fileInfoArray = directoryInfo.GetFiles();
            Array.Sort(fileInfoArray, new FileInfoComparer());

            for (int i = 0; i < 5; i++)
            {
                var fileInfo = fileInfoArray[i];
                Console.WriteLine($"{fileInfo.Name, -20} : {fileInfo.Length, -10:N0}");
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
