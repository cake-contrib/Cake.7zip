using System;

using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Tests.Fixtures;

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