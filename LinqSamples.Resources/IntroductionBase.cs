using System;
using System.IO;
using System.Linq;

namespace LinqSamples.Resources
{
    public class IntroductionBase
    {
        public static void ShowLargeFiles()
        {
            string path = @"C:\Windows";

            Console.WriteLine("****Show large files without linq****");
            var directoryInfo = new DirectoryInfo(path);
            var fileInfoArray = directoryInfo.GetFiles();
            Array.Sort(fileInfoArray, new FileInfoComparer());

            for (int i = 0; i < 5; i++)
            {
                var fileInfo = fileInfoArray[i];
                Console.WriteLine($"{fileInfo.Name,-20} : {fileInfo.Length,-10:N0}");
            }

            Console.WriteLine("****Show large files with linq****");
            var query = new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(f => f.Length)
                        .Take(5);

            foreach (var fileInfo in query)
            {
                Console.WriteLine($"{fileInfo.Name,-20} : {fileInfo.Length,-10:N0}");
            }
        }

        public static void ShowLargeFilesWithoutLinq(string path)
        {

        }

        public static void ShowLargeFilesWithLinq(string path)
        {

        }
    }
}