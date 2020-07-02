using System;

namespace Cake.SevenZip.Tests
{
    public class SevenZipFluentRunnerFixture : SevenZipRunnerFixture
    {
        public void RunToolFluent(Action<CommandBuilder> action)
        {
            var builder = new CommandBuilder();
            action(builder);

            Settings.Command = builder.Command;

            RunTool();
        }
    }
}
