using System.Collections.Generic;

using Cake.Core.IO;
using Cake.SevenZip.Arguments;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Parsers;
using Cake.SevenZip.Switches;

namespace Cake.SevenZip.Commands;

/// <summary>
/// Calculates the hash for one or more files
/// (Command: h).
/// <para>
/// The builder is <see cref="HashCommandBuilder"/>.
/// </para>
/// </summary>
public sealed class HashCommand :
    BaseOutputCommand<IHashOutput>,
    IHaveArgumentFiles,
    IHaveArgumentDirectories,
    ISupportSwitchIncludeFilenames,
    ISupportSwitchExcludeFilenames,
    ISupportSwitchRecurseSubdirectories,
    ISupportSwitchCompressionMethod,
    ISupportSwitchCompressFilesOpenForWriting,
    ISupportSwitchNtfsAlternateStreams,
    ISupportSwitchSetHashFunction
{
    private readonly HashOutputParser outputParser;

    /// <summary>
    /// Initializes a new instance of the <see cref="HashCommand"/> class.
    /// </summary>
    public HashCommand()
    {
        outputParser = new HashOutputParser();
    }

    /// <inheritdoc />
    public FilePathCollection? Files { get; set; }

    /// <inheritdoc />
    public DirectoryPathCollection? Directories { get; set; }

    /// <inheritdoc />
    public DirectoryPathCollection? DirectoryContents { get; set; }

    /// <inheritdoc />
    public SwitchIncludeFilenameCollection? IncludeFilenames { get; set; }

    /// <inheritdoc />
    public SwitchExcludeFilenameCollection? ExcludeFilenames { get; set; }

    /// <inheritdoc />
    public SwitchRecurseSubdirectories? RecurseSubdirectories { get; set; }

    /// <inheritdoc />
    public SwitchCompressionMethod? CompressionMethod { get; set; }

    /// <inheritdoc />
    public SwitchCompressFilesOpenForWriting? CompressFilesOpenForWriting { get; set; }

    /// <inheritdoc />
    public SwitchNtfsAlternateStreams? NtfsAlternateStreams { get; set; }

    /// <inheritdoc />
    public SwitchSetHashFunctionCollection? HashFunctions { get; set; }

    /// <inheritdoc/>
    internal override IOutputParser<IHashOutput> OutputParser => outputParser;

    /// <inheritdoc/>
    protected override string CommandChar => "h";

    /// <inheritdoc/>
    protected override IEnumerable<ISwitch?> Switches => new ISwitch?[]
    {
        IncludeFilenames,
        ExcludeFilenames,
        RecurseSubdirectories,
        CompressionMethod,
        CompressFilesOpenForWriting,
        NtfsAlternateStreams,
        HashFunctions,
    };

    /// <inheritdoc/>
    protected override void BuildArgumentParams(ref ProcessArgumentBuilder builder)
    {
        Files.RequireNotEmpty(
            $"some input ({nameof(Files)} or {nameof(Directories)}) are required for hash.",
            Directories,
            DirectoryContents);

        builder.AppendPathsNullSafe(Files);
        builder.AppendPathsNullSafe(Directories);
        builder.AppendPathsNullSafe(DirectoryContents); // Directory and DirectoryContents produce the same output for "hash"
    }
}