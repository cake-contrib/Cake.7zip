namespace Cake.SevenZip
{
    using System;
    using System.Collections.Generic;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="SevenZipRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">The log.</param>
        public SevenZipRunner(
          IFileSystem fileSystem,
          ICakeEnvironment environment,
          IProcessRunner processRunner,
          IToolLocator tools,
          ICakeLog log)
          : base(fileSystem, environment, processRunner, tools)
        {
            this.log = log;
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

            Run(settings, GetArguments(settings));
        }

        /// <inheritdoc/>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "7za.exe";
            yield return "7za";

            // TODO: What about checking HCR\Applications\7z.exe\shell\open\command
        }

        /// <inheritdoc/>
        protected override string GetToolName()
        {
            return "7-Zip";
        }

        private ProcessArgumentBuilder GetArguments(SevenZipSettings settings)
        {
            if (settings == null)
            {
                throw new CakeException($"{GetToolName()}: Settings can not be null - a command is needed to run!");
            }

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
