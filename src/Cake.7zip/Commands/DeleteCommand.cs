using System.Collections.Generic;

using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands;

/// <summary>
/// Deletes files from the archive.
/// (Command: d).
/// <para>
/// The builder is <see cref="DeleteCommandBuilder"/>.
/// </para>
/// </summary>
public sealed class DeleteCommand : BaseAddLikeSyntaxCommand,
    ICommand,
    ISupportSwitchIncludeFilenames,
    ISupportSwitchExcludeFilenames,
    ISupportSwitchCompressionMethod,
    ISupportSwitchPassword,
    ISupportSwitchRecurseSubdirectories,
    ISupportSwitchNtfsAlternateStreams,
    ISupportSwitchUpdateOptions,
    ISupportSwitchWorkingDirectory,
    ISupportSwitchSelfExtractingArchive,
    ISupportSwitchFullyQualifiedFilePaths
{
    /// <inheritdoc />
    public SwitchRecurseSubdirectories? RecurseSubdirectories { get; set; }

    /// <inheritdoc />
    public SwitchIncludeFilenameCollection? IncludeFilenames { get; set; }

    /// <inheritdoc />
    public SwitchExcludeFilenameCollection? ExcludeFilenames { get; set; }

    /// <inheritdoc />
    public SwitchWorkingDirectory? WorkingDirectory { get; set; }

    /// <inheritdoc />
    public SwitchNtfsAlternateStreams? NtfsAlternateStreams { get; set; }

    /// <inheritdoc/>
    public SwitchCompressionMethod? CompressionMethod { get; set; }

    /// <inheritdoc />
    public SwitchUpdateOptions? UpdateOptions { get; set; }

    /// <inheritdoc />
    public SwitchPassword? Password { get; set; }

    /// <inheritdoc />
    public SwitchSelfExtractingArchive? SelfExtractingArchive { get; set; }

    /// <inheritdoc />
    public SwitchFullyQualifiedFilePaths? FullyQualifiedFilePaths { get; set; }

    /// <inheritdoc/>
    protected override string CommandName => "delete";

    /// <inheritdoc/>
    protected override string CommandChar => "d";

    /// <inheritdoc/>
    protected override IEnumerable<ISwitch?> Switches => new ISwitch?[]
    {
        CompressionMethod,
        Password,
        NtfsAlternateStreams,
        WorkingDirectory,
        RecurseSubdirectories,
        IncludeFilenames,
        ExcludeFilenames,
        UpdateOptions,
        SelfExtractingArchive,
        FullyQualifiedFilePaths,
    };

    /// <inheritdoc/>
    protected override bool ThrowOnMissingInputFiles => false;
}