using System.Collections.Generic;

using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Arguments;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands;

/// <summary>
/// Extract files from archive - with or without full path
/// (Commands: e and x).
/// <para>
/// With UseFullPath set to false, this represents the e-command:
/// Extracts files from an archive to the current directory or to the output directory.
/// The output directory can be specified by -o (Set Output Directory) switch.
/// This command copies all extracted files to one directory.
/// </para>
/// <para>
/// With UseFullPath set to true, this represents the x-command:
/// Extracts files from an archive with their full paths in the current directory,
/// or in an output directory if specified.
/// </para>
/// <para>
/// The builder is <see cref="ExtractCommandBuilder"/>.
/// </para>
/// </summary>
public sealed class ExtractCommand : BaseCommand,
    ICommand,
    IHaveArgumentArchive,
    ISupportSwitchIncludeFilenames,
    ISupportSwitchCompressionMethod,
    ISupportSwitchPassword,
    ISupportSwitchRecurseSubdirectories,
    ISupportSwitchNtSecurityInformation,
    ISupportSwitchNtfsAlternateStreams,
    ISupportSwitchExcludeFilenames,
    ISupportSwitchArchiveType,
    ISupportSwitchIncludeArchiveFilenames,
    ISupportSwitchExcludeArchiveFilenames,
    ISupportSwitchDisableParsingOfArchiveName,
    ISupportSwitchOverwriteMode,
    ISupportSwitchOutputDirectory,
    ISupportSwitchFullyQualifiedFilePaths
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExtractCommand"/> class.
    /// </summary>
    public ExtractCommand()
    {
        UseFullPaths = true;
    }

    /// <inheritdoc />
    public FilePath? Archive { private get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use full paths.
    /// Default is true.
    /// </summary>
    /// <value>
    ///   <c>true</c> if [use full paths]; otherwise, <c>false</c>.
    /// </value>
    public bool UseFullPaths { get; set; }

    /// <inheritdoc/>
    public SwitchArchiveType? ArchiveType { get; set; }

    /// <inheritdoc/>
    public SwitchCompressionMethod? CompressionMethod { get; set; }

    /// <inheritdoc />
    public SwitchPassword? Password { get; set; }

    /// <inheritdoc />
    public SwitchNtSecurityInformation? NtSecurityInformation { get; set; }

    /// <inheritdoc />
    public SwitchNtfsAlternateStreams? NtfsAlternateStreams { get; set; }

    /// <inheritdoc />
    public SwitchRecurseSubdirectories? RecurseSubdirectories { get; set; }

    /// <inheritdoc />
    public SwitchIncludeFilenameCollection? IncludeFilenames { get; set; }

    /// <inheritdoc />
    public SwitchExcludeFilenameCollection? ExcludeFilenames { get; set; }

    /// <inheritdoc />
    public SwitchIncludeArchiveFilenameCollection? IncludeArchiveFilenames { get; set; }

    /// <inheritdoc />
    public SwitchExcludeArchiveFilenameCollection? ExcludeArchiveFilenames { get; set; }

    /// <inheritdoc />
    public SwitchDisableParsingOfArchiveName? DisableParsingOfArchiveName { get; set; }

    /// <inheritdoc />
    public SwitchOverwriteMode? OverwriteMode { get; set; }

    /// <inheritdoc />
    public SwitchOutputDirectory? OutputDirectory { get; set; }

    /// <inheritdoc />
    public SwitchFullyQualifiedFilePaths? FullyQualifiedFilePaths { get; set; }

    /// <inheritdoc/>
    protected override string CommandChar => UseFullPaths ? "x" : "e";

    /// <inheritdoc/>
    protected override IEnumerable<ISwitch?> Switches => new ISwitch?[]
    {
        ArchiveType,
        CompressionMethod,
        Password,
        NtSecurityInformation,
        NtfsAlternateStreams,
        RecurseSubdirectories,
        IncludeFilenames,
        ExcludeFilenames,
        IncludeArchiveFilenames,
        ExcludeArchiveFilenames,
        DisableParsingOfArchiveName,
        OverwriteMode,
        OutputDirectory,
        FullyQualifiedFilePaths,
    };

    /// <inheritdoc/>
    protected override void BuildArgumentParams(ref ProcessArgumentBuilder builder)
    {
        Archive.RequireNotNull("Archive is required for extract.");

        builder.Append("-y"); // assume yes - can't have 7zip prompt the user.
        builder.AppendQuoted(Archive!.FullPath);
    }
}