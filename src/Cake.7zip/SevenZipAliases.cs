using System;

using Cake.Core;
using Cake.Core.Annotations;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Commands;

namespace Cake.SevenZip
{
    /// <summary>
    /// <para>Functions to call <see href="https://7-zip.org/">7-Zip</see>.</para>
    /// <para>
    /// In order to use this add-in, 7z.exe or 7za.exe has to be available.
    /// One option is using
    /// <see href="https://www.nuget.org/packages/7-Zip.CommandLine/">7-Zip.CommandLine from nuget</see>.
    /// The other option is to have 7z installed on your system (I.e. There is a registry-key HKLM/Software/7-Zip/Path
    /// that points to a directory containing 7z.exe or 7za.exe).
    /// </para>
    /// <para>
    /// Supported formats and capabilities depend on your 7z-version.
    /// </para>
    /// <para>
    /// To install add the following lines to your cake-file:
    /// <code>
    /// <![CDATA[
    /// #tool "nuget:?package=7-Zip.CommandLine"
    /// #addin "nuget:?package=Cake.7zip"
    /// ]]>
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("7Zip")]
    public static class SevenZipAliases
    {
        /// <summary>
        /// Runs 7zip, using a fluent builder for configuration.
        /// <para>
        /// For more examples see the different builders for the <see cref="ICommand"/>.
        /// <list type="bullet">
        /// <item><description><see cref="AddCommandBuilder"/></description></item>
        /// <item><description><see cref="DeleteCommandBuilder"/></description></item>
        /// <item><description><see cref="ExtractCommandBuilder"/></description></item>
        /// <item><description><see cref="UpdateCommandBuilder"/></description></item>
        /// </list>
        /// </para>
        /// <seealso cref="ICommand"/>
        /// <seealso cref="CommandBuilder"/>
        /// </summary>
        /// <param name="context">The <see cref="ICakeContext"/>.</param>
        /// <param name="action">The fluent <see cref="CommandBuilder"/>.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// Task("ZipIt")
        ///     .Does(() =>
        /// {
        ///     SevenZip(m => m
        ///         .InAddMode()
        ///         .WithArchive(File("path/to/file.zip"))
        ///         .WithFile(File("a.txt"))
        ///         .WithFile(File("b.txt"))
        ///         .WithVolume(1, VolumeUnit.Gigabyte));
        /// });
        /// ]]>
        /// </code>
        /// <code>
        /// <![CDATA[
        /// Task("UnzipIt")
        ///     .Does(() =>
        /// {
        ///     SevenZip(m => m
        ///       .InExtractMode()
        ///       .WithArchive(File("path/to/file.zip"))
        ///       .WithArchiveType(SwitchArchiveType.Zip)
        ///       .WithOutputDirectory("some/other/directory"));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void SevenZip(this ICakeContext context, Action<CommandBuilder> action)
        {
            SevenZip(context, new SevenZipSettings(), action);
        }

        /// <summary>
        /// <para>
        /// Runs 7zip, using <see cref="SevenZipSettings"/> for configuration and additionally
        /// <see cref="CommandBuilder"/> for fluent configuration of the Command.
        /// </para>
        /// <para>
        /// Works exactly like <see cref="SevenZip(ICakeContext, Action{CommandBuilder})"/>
        /// However, the settings are supplied to set e.g. the <c>ToolPath</c> or something else.
        /// </para>
        /// <para>
        /// <strong>DO NOT</strong> set <c>Command</c> on the <see cref="SevenZipSettings"/>,
        /// as it will be overwritten by the <see cref="CommandBuilder"/>.
        /// </para>
        /// </summary>
        /// <param name="context">The <see cref="ICakeContext"/>.</param>
        /// <param name="settings">The <see cref="SevenZipSettings"/>.</param>
        /// <param name="action">The fluent <see cref="CommandBuilder"/>-Builder.</param>
        [CakeMethodAlias]
        public static void SevenZip(this ICakeContext context, SevenZipSettings settings, Action<CommandBuilder> action)
        {
            var builder = new CommandBuilder();
            action(builder);
            settings.Command = builder.Command;
            SevenZip(context, settings);
        }

        /// <summary>
        /// Runs 7zip, using <see cref="SevenZipSettings"/> for configuration.
        /// </summary>
        /// <param name="context">The <see cref="ICakeContext"/>.</param>
        /// <param name="settings">The <see cref="SevenZipSettings"/>.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// Task("ZipIt")
        ///     .Does(() =>
        /// {
        ///     SevenZip(new SevenZipSettings
        ///     {
        ///         Command = new AddCommand
        ///         {
        ///             Files = new FilePathCollection(new[] { new FilePath("a.txt"), new FilePath("b.txt") }),
        ///             Archive = new FilePath("out.zip"),
        ///             Volumes = new SwitchVolumeCollection(
        ///                 new SwitchVolume
        ///                 {
        ///                     Size = 1,
        ///                     Unit = VolumeUnit.Gigabytes
        ///                 })
        ///         }
        ///     });
        /// });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void SevenZip(this ICakeContext context, SevenZipSettings settings)
        {
            var runner = new SevenZipRunner(
              context.FileSystem,
              context.Environment,
              context.ProcessRunner,
              context.Tools,
              context.Log,
              context.Registry);
            runner.Run(settings);
        }
    }
}
