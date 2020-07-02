namespace Cake.SevenZip
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cake.Core;
    using Cake.Core.Diagnostics;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    /// <summary>
    /// The Tool-Runner for 7zip.
    /// </summary>
    /// <seealso cref="Tool{SevenZipSettings}" />
    public sealed class SevenZipRunner : Tool<SevenZipSettings>
    {
        private readonly ICakeLog log;
        private readonly ICakeEnvironment cakeEnvironment;
        private readonly IRegistry registry;
        private readonly IFileSystem fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="SevenZipRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">The log.</param>
        /// <param name="registry">The Registry.</param>
        public SevenZipRunner(
          IFileSystem fileSystem,
          ICakeEnvironment environment,
          IProcessRunner processRunner,
          IToolLocator tools,
          ICakeLog log,
          IRegistry registry)
          : base(fileSystem, environment, processRunner, tools)
        {
            this.log = log;
            cakeEnvironment = environment;
            this.registry = registry;
            this.fileSystem = fileSystem;
        }

        /// <summary>
        /// Runs the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">settings.</exception>
        public void Run(SevenZipSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var procSettings = new ProcessSettings
            {
                RedirectStandardOutput = true,
            };

            void AfterRun(IProcess p)
            {
                if (settings.Command is ICanParseOutput parseOutput)
                {
                    parseOutput.SetRawOutput(p.GetStandardOutput());
                }
            }

            Run(settings, GetArguments(settings), procSettings, AfterRun);
        }

        /// <inheritdoc/>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "7za.exe";
            yield return "7za";
            yield return "7z.exe"; // 7z.exe can do everything 7za.exe can.
            yield return "7z";
        }

        /// <inheritdoc/>
        protected override string GetToolName()
        {
            return "7-Zip";
        }

        /// <inheritdoc/>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(SevenZipSettings settings)
        {
            var paths = new List<FilePath>(base.GetAlternativeToolPaths(settings));

            if (registry != null)
            {
                log.Debug("Trying to detect 7zip from Registry");
                try
                {
                    var software = registry.LocalMachine.OpenKey("Software");
                    var sevenZip = software.OpenKey("7-Zip");
                    var path32 = sevenZip.GetValue("Path")?.ToString() ?? string.Empty;
                    log.Debug("7zip path in registry:" + path32);
                    var path64 = sevenZip.GetValue("Path64")?.ToString() ?? string.Empty;
                    log.Debug("7zip 64bit-path in registry:" + path64);
                    var dirs = new List<DirectoryPath>(new[] { new DirectoryPath(path32) });
                    if (cakeEnvironment.Platform.Is64Bit
                        && path64 != path32)
                    {
                        dirs.Add(new DirectoryPath(path64));
                    }

                    var names = GetToolExecutableNames().ToList();

                    names
                        .SelectMany(n => dirs
                            .Select(d => d.CombineWithFilePath(n)))
                        .Where(p => fileSystem.Exist(p))
                        .ToList().ForEach(p => paths.Add(p.FullPath));
                }
                catch (Exception e)
                {
                    log.Debug($"{e.GetType()}: {e.Message}");
                    log.Debug($"7zip not found in registry.");
                }
            }

            return paths;
        }

        private ProcessArgumentBuilder GetArguments(SevenZipSettings settings)
        {
            if (settings.Command == null)
            {
                throw new CakeException($"{GetToolName()}: Command can not be null - a command is needed to run!");
            }

            var builder = new ProcessArgumentBuilder();
            try
            {
                settings.Command.BuildArguments(ref builder);
                return builder;
            }
            catch (Exception e)
            {
                throw new CakeException($"{GetToolName()}: {e.Message}", e);
            }
        }
    }
}
