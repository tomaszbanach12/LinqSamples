using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace LinqSamples.Resources
{
    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare([AllowNull] FileInfo x, [AllowNull] FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}