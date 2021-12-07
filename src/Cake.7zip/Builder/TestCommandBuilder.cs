using Cake.SevenZip.Arguments;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Builder;

/// <summary>
/// Builder for <see cref="TestCommand"/>.
/// <seealso cref="ISupportSwitchBuilder{T}" />
/// </summary>
/// <example>
/// <code>
/// <![CDATA[
/// Task("TestZip")
///     .Does(() =>
/// {
///     SevenZip(m => m
///        .InTestMode()
///        .WithArchive(File("path/to/file.zip"))
///        .WithCommandOutput(o =>
///        {
///            Information("7Zip version is:" + o.Information);
///            foreach (var archiveTestResult in o.Archives)
///            {
///                var isOk = archiveTestResult.IsOk ? "OK" : "not OK";
///                Information($" - {archiveTestResult.FileName} test is { isOk }");
///            }
///        }));
///  });
/// ]]>
/// </code>
/// </example>
public sealed class TestCommandBuilder :
    BaseOutputBuilder<TestCommandBuilder, ITestOutput>,
    ISupportArgumentBuilder<IHaveArgumentArchive>,
    ISupportArgumentBuilder<IHaveArgumentFiles>,
    ISupportSwitchBuilder<ISupportSwitchIncludeArchiveFilenames>,
    ISupportSwitchBuilder<ISupportSwitchExcludeArchiveFilenames>,
    ISupportSwitchBuilder<ISupportSwitchDisableParsingOfArchiveName>,
    ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>,
    ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>,
    ISupportSwitchBuilder<ISupportSwitchPassword>,
    ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>,
    ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>
{
    private readonly TestCommand command;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestCommandBuilder"/> class.
    /// </summary>
    /// <param name="command">The command.</param>
    internal TestCommandBuilder(ref TestCommand command)
    {
        this.command = command;
    }

    /// <inheritdoc/>
    IHaveArgumentArchive ISupportArgumentBuilder<IHaveArgumentArchive>.Command => command;

    /// <inheritdoc/>
    IHaveArgumentFiles ISupportArgumentBuilder<IHaveArgumentFiles>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchIncludeArchiveFilenames ISupportSwitchBuilder<ISupportSwitchIncludeArchiveFilenames>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchExcludeArchiveFilenames ISupportSwitchBuilder<ISupportSwitchExcludeArchiveFilenames>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchDisableParsingOfArchiveName ISupportSwitchBuilder<ISupportSwitchDisableParsingOfArchiveName>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchIncludeFilenames ISupportSwitchBuilder<ISupportSwitchIncludeFilenames>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchExcludeFilenames ISupportSwitchBuilder<ISupportSwitchExcludeFilenames>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchPassword ISupportSwitchBuilder<ISupportSwitchPassword>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchNtfsAlternateStreams ISupportSwitchBuilder<ISupportSwitchNtfsAlternateStreams>.Command => command;

    /// <inheritdoc/>
    ISupportSwitchRecurseSubdirectories ISupportSwitchBuilder<ISupportSwitchRecurseSubdirectories>.Command => command;

    /// <inheritdoc/>
    protected override BaseOutputCommand<ITestOutput> OutputCommand => command;
}