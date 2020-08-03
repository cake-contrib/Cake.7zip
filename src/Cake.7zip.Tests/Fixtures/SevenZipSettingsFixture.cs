using System;

using Cake.Core.IO;

namespace Cake.SevenZip.Tests.Fixtures
{
    public class SevenZipSettingsFixture
    {
        public string Parse(Action<ProcessArgumentBuilder> action)
        {
            var builder = new ProcessArgumentBuilder();
            action(builder);
            return builder.Render();
        }

        public string ParseSafe(Action<ProcessArgumentBuilder> action)
        {
            var builder = new ProcessArgumentBuilder();
            action(builder);
            return builder.RenderSafe();
        }
    }
}
