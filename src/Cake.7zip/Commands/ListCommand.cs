using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Arguments;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Parsers;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands;

/// <summary>
/// Show List about supported formats
/// (Command: i).
/// <para>
/// The builder is <see cref="ListCommandBuilder"/>.
/// </para>
/// </summary>
public sealed class ListCommand :
    BaseOutputCommand<IListOutput>,
    IHaveArgumentArchive,
    ISupportSwitchIncludeArchiveFilenames,
    ISupportSwitchDisableParsingOfArchiveName,
    ISupportSwitchExcludeArchiveFilenames,
    ISupportSwitchIncludeFilenames,
    ISupportSwitchNtfsAlternateStreams,
    ISupportSwitchPassword,
    ISupportSwitchRecurseSubdirectories,
    ISupportSwitchArchiveType,
    ISupportSwitchExcludeFilenames,
    ISupportSwitchShowTechnicalInformation
{
    private readonly ListOutputParser outputParser;

    /// <summary>
    /// Initializes a new instance of the <see cref="ListCommand"/> class.
    /// </summary>
    public ListCommand()
    {
        outputParser = new ListOutputParser();
    }

    /// <inheritdoc/>
    public FilePath? Archive { private get; set; }

    /// <inheritdoc/>
    public SwitchExcludeFilenameCollection? ExcludeFilenames { get; set; }

    /// <inheritdoc/>
    public SwitchShowTechnicalInformation? ShowTechnicalInformation { get; set; }

    /// <inheritdoc/>
    public SwitchIncludeArchiveFilenameCollection? IncludeArchiveFilenames { get; set; }

    /// <inheritdoc/>
    public SwitchDisableParsingOfArchiveName? DisableParsingOfArchiveName { get; set; }

    /// <inheritdoc/>
    public SwitchExcludeArchiveFilenameCollection? ExcludeArchiveFilenames { get; set; }

    /// <inheritdoc/>
    public SwitchIncludeFilenameCollection? IncludeFilenames { get; set; }

    /// <inheritdoc/>
    public SwitchNtfsAlternateStreams? NtfsAlternateStreams { get; set; }

    /// <inheritdoc/>
    public SwitchPassword? Password { get; set; }

    /// <inheritdoc/>
    public SwitchRecurseSubdirectories? RecurseSubdirectories { get; set; }

    /// <inheritdoc/>
    public SwitchArchiveType? ArchiveType { get; set; }

    /// <inheritdoc/>
    internal override IOutputParser<IListOutput> OutputParser => outputParser;

    /// <inheritdoc/>
    protected override string CommandChar { get; } = "l";

    /// <inheritdoc/>
    protected override IEnumerable<ISwitch?> Switches => new ISwitch?[]
    {
        IncludeArchiveFilenames,
        DisableParsingOfArchiveName,
        ExcludeArchiveFilenames,
        IncludeFilenames,
        NtfsAlternateStreams,
        Password,
        RecurseSubdirectories,
        ArchiveType,
        ExcludeFilenames,
        ShowTechnicalInformation,
    };

    /// <inheritdoc/>
    protected override void BuildArgumentParams(ref ProcessArgumentBuilder builder)
    {
        Archive.RequireNotNull($"{nameof(Archive)} is required for list.");
        builder.AppendQuoted(Archive!.FullPath);
    }
}