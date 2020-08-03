using System;

namespace Cake.SevenZip.Tests
{
    internal static class TestExtensions
    {
        internal static string[] ToArrayOfLines(this string @this)
        {
            return @this.UnifyLineEndings().Split(new[] { "\n" }, StringSplitOptions.None);
        }

        internal static string UnifyLineEndings(this string @this)
        {
            return @this.Replace("\r\n", "\n");
        }
    }
}
