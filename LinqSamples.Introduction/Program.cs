using LinqSamples.Resources;
using System;

namespace LinqSamples.Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows";
            Console.WriteLine("****Show large files without linq****");
            IntroductionBase.ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("****Show large files with linq****");
            IntroductionBase.ShowLargeFilesWithLinq(path);
        }
    }
}
