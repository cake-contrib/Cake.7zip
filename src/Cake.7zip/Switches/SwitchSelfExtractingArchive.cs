namespace Cake.SevenZip
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// <para>
    /// -sfx (Create SFX archive) switch.
    /// </para>
    /// <para>
    /// Specifies the SFX module that will be combined with the archive.
    /// This module must be placed in the same directory as the 7z.exe.
    /// If {SFX_Module} is not assigned, 7-Zip will use standard console SFX module 7zCon.sfx.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item><description><see cref="ISupportSwitchSelfExtractingArchive"/></description></item>
    /// <item><description><see cref="SwitchSelfExtractingArchiveBuilder"/></description></item>
    /// </list>
    /// </para>
    /// <seealso cref="ISwitch" />
    /// </summary>
    public class SwitchSelfExtractingArchive : ISwitch
    {
        /// <summary>
        /// Gets or sets the SFX module that will be combined with the archive.
        /// This module must be placed in the same directory as the 7z.exe.
        /// If no module is assigned, 7-Zip will use standard console SFX module 7zCon.sfx.
        /// </summary>
        /// <value>
        /// The SFX module.
        /// </value>
        public FilePath SfxModule { get; set; }

        /// <inheritdoc />
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            if (SfxModule != null)
            {
                builder.AppendSwitchQuoted("-sfx", string.Empty, SfxModule.FullPath);
            }
            else
            {
                builder.Append("-sfx");
            }
        }
    }
}
