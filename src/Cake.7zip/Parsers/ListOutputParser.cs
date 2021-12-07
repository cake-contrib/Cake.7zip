using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

using Cake.SevenZip.Commands;

namespace Cake.SevenZip.Parsers;

/// <summary>
/// Parses outputs of the <see cref="ListCommand"/>.
/// </summary>
/// <seealso cref="IOutputParser{T}" />
internal class ListOutputParser : IOutputParser<IListOutput>
{
    /// <inheritdoc />
    public IListOutput Parse(string[] rawOutput)
    {
        var output = new ListOutput();
        ArchiveListOutput? currentArchive = null;
        bool inParsingFilesMode = false;

        var fileMatcher = new Regex(@"(?<datetime>[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{2}:[0-9]{2}:[0-9]{2})\s(?<attr>.{5})\s+(?<size>[0-9]+)\s+(?<compressed>[0-9]+)\s+(?<name>.*)", RegexOptions.Compiled | RegexOptions.Singleline);

        foreach (var line in rawOutput)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (string.IsNullOrEmpty(output.Information))
            {
                output.Information = line;
                continue;
            }

            if (line.StartsWith("Path = ", StringComparison.Ordinal))
            {
                currentArchive = new ArchiveListOutput
                {
                    Path = line.Substring(7).Trim(),
                };
                output.Archives.Add(currentArchive);
                inParsingFilesMode = false;
                continue;
            }

            if (currentArchive != null && line.StartsWith("Type = ", StringComparison.Ordinal))
            {
                currentArchive.Type = line.Substring(7).Trim();
                continue;
            }

            if (currentArchive != null && line.StartsWith("Physical Size = ", StringComparison.Ordinal))
            {
                currentArchive.PhysicalSize = long.Parse(line.Substring(16).Trim(), CultureInfo.InvariantCulture);
                continue;
            }

            if (currentArchive != null && line.StartsWith("---", StringComparison.Ordinal))
            {
                inParsingFilesMode = !inParsingFilesMode;
                continue;
            }

            var match = fileMatcher.Match(line);
            if (match.Success)
            {
                var fileDate = DateTime.Parse(match.Groups["datetime"].Value, CultureInfo.InvariantCulture);
                var compressedSize = long.Parse(match.Groups["compressed"].Value, CultureInfo.InvariantCulture);
                var size = long.Parse(match.Groups["size"].Value, CultureInfo.InvariantCulture);
                var name = match.Groups["name"].Value.Trim();
                var attr = match.Groups["attr"].Value.Trim();

                if (inParsingFilesMode)
                {
                    currentArchive!.Files.Add(new ArchivedFileListOutput
                    {
                        FileDate = fileDate,
                        CompressedSize = compressedSize,
                        Size = size,
                        Name = name,
                        Attributes = attr,
                    });
                }
                else
                {
                    // now, this is either the last line for an archive or the summary (last line) for multiple archives
                    if (currentArchive != null)
                    {
                        currentArchive.ArchiveDate = fileDate;
                        currentArchive.CompressedSize = compressedSize;
                        currentArchive.Size = size;
                        currentArchive = null;
                    }
                    else
                    {
                        output.CompressedSize = compressedSize;
                        output.Size = size;
                    }
                }
            }
        }

        // if there was only one archive listed, there was no summary line
        if (output.Archives.Count == 1)
        {
            output.CompressedSize = output.Archives[0].CompressedSize;
            output.Size = output.Archives[0].Size;
        }

        return output;
    }

    private class ListOutput : IListOutput
    {
        public ListOutput()
        {
            Archives = new List<IArchiveListOutput>();
        }

        public long Size { get; set; }

        public long CompressedSize { get; set; }

        public string Information { get; set; } = string.Empty;

        public List<IArchiveListOutput> Archives { get; }

        IEnumerable<IArchiveListOutput> IListOutput.Archives => Archives;
    }

    private class ArchiveListOutput : IArchiveListOutput
    {
        public ArchiveListOutput()
        {
            Files = new List<IArchivedFileListOutput>();
        }

        public string Path { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public long PhysicalSize { get; set; }

        public long Size { get; set; }

        public long CompressedSize { get; set; }

        public DateTime ArchiveDate { get; set; }

        public List<IArchivedFileListOutput> Files { get; }

        IEnumerable<IArchivedFileListOutput> IArchiveListOutput.Files => Files;
    }

    private class ArchivedFileListOutput : IArchivedFileListOutput
    {
        public DateTime FileDate { get; set; }

        public string Attributes { get; set; } = string.Empty;

        public long Size { get; set; }

        public long CompressedSize { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}