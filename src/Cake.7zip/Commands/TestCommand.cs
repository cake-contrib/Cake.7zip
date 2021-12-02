using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Arguments;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Parsers;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands;

/// <summary>
/// Test one or more archives
/// (Command: t).
/// <para>
/// The builder is <see cref="TestCommandBuilder"/>.
/// </para>
/// </summary>
public sealed class TestCommand :
    BaseOutputCommand<ITestOutput>,
    IHaveArgumentArchive,
    IHaveArgumentFiles,
    ISupportSwitchIncludeArchiveFilenames,
    ISupportSwitchExcludeArchiveFilenames,
    ISupportSwitchDisableParsingOfArchiveName,
    ISupportSwitchIncludeFilenames,
    ISupportSwitchExcludeFilenames,
    ISupportSwitchPassword,
    ISupportSwitchNtfsAlternateStreams,
    ISupportSwitchRecurseSubdirectories
{
    private readonly TestOutputParser outputParser;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestCommand"/> class.
    /// </summary>
    public TestCommand()
    {
        outputParser = new TestOutputParser();
    }

    /// <inheritdoc />
    public FilePath? Archive { private get; set; }

    /// <inheritdoc />
    public SwitchIncludeArchiveFilenameCollection? IncludeArchiveFilenames { get; set; }

    /// <inheritdoc />
    public SwitchExcludeArchiveFilenameCollection? ExcludeArchiveFilenames { get; set; }

    /// <inheritdoc />
    public SwitchDisableParsingOfArchiveName? DisableParsingOfArchiveName { get; set; }

    /// <inheritdoc />
    public SwitchIncludeFilenameCollection? IncludeFilenames { get; set; }

    /// <inheritdoc />
    public SwitchExcludeFilenameCollection? ExcludeFilenames { get; set; }

    /// <inheritdoc />
    public SwitchPassword? Password { get; set; }

    /// <inheritdoc />
    public SwitchNtfsAlternateStreams? NtfsAlternateStreams { get; set; }

    /// <inheritdoc />
    public SwitchRecurseSubdirectories? RecurseSubdirectories { get; set; }

    /// <inheritdoc />
    public FilePathCollection? Files { get; set; }

    /// <inheritdoc/>
    internal override IOutputParser<ITestOutput> OutputParser => outputParser;

    /// <inheritdoc />
    protected override string CommandChar { get; } = "t";

    /// <inheritdoc />
    protected override IEnumerable<ISwitch?> Switches => new ISwitch?[]
    {
        IncludeArchiveFilenames,
        ExcludeArchiveFilenames,
        DisableParsingOfArchiveName,
        IncludeFilenames,
        ExcludeFilenames,
        Password,
        NtfsAlternateStreams,
        RecurseSubdirectories,
    };

    /// <inheritdoc/>
    protected override void BuildArgumentParams(ref ProcessArgumentBuilder builder)
    {
        Archive.RequireNotNull("Archive is required for extract.");

        builder.AppendQuoted(Archive!.FullPath);
        builder.AppendPathsNullSafe(Files);
    }
}