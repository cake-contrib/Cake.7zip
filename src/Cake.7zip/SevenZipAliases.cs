namespace Cake.SevenZip
{
    using System;

    using Cake.Core;
    using Cake.Core.Annotations;

    /// <summary>
    /// <para>Functions to call <see href="https://7-zip.org/">7-Zip</see>.</para>
    /// <para>
    /// In order to use this addin, make sure 7zip is installed on the system
    /// and add the following to your build.cake.
    /// <code><![CDATA[
    /// #tool "nuget:?package=7-Zip.CommandLine"
    /// #addin "nuget:?package=Cake.7zip"
    /// ]]></code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("7Zip")]
    public static class SevenZipAliases
    {
        /// <summary>
        /// Runs a fluent builder for 7zip.
        /// </summary>
        /// <param name="context">The <see cref="ICakeContext"/>.</param>
        /// <param name="action">The fluent <see cref="SevenZipBuilderContext"/>-Builder.</param>
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
        /// </example>
        [CakeMethodAlias]
        public static void SevenZip(this ICakeContext context, Action<SevenZipBuilderContext> action)
        {
            var builder = new SevenZipBuilderContext();
            action(builder);
            SevenZip(context, builder.Settings);
        }

        /// <summary>
        /// Runs a non-fluent 7zip.
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
              context.Log);
            runner.Run(settings);
        }
    }
}
