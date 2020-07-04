using System;
using System.Linq;

namespace Cake.SevenZip.Tests
{
    internal static class TestExtensions
    {
        internal static string[] ToArrayOfLines(this string @this)
        {
            return @this.Split(new[] { "\n" }, StringSplitOptions.None).Select(x => x.TrimEnd('\r')).ToArray();
        }
    }
}
