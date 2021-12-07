namespace Cake.SevenZip.Switches;

/// <summary>
/// <para>
/// Specifies the overwrite mode during extraction, to overwrite files already present on disk.
/// </para>
/// <para>
/// <list type="bullet">
/// <item><description><see cref="SwitchOverwriteMode"/></description></item>
/// </list>
/// </para>
/// </summary>
public class OverwriteMode
{
    private readonly string mode;

    private OverwriteMode(string mode)
    {
        this.mode = mode;
    }

    /// <summary>
    /// Gets the Overwrite-Mode.
    /// Overwrite All existing files without prompt.
    /// </summary>
    /// <value>
    /// The overwrite-Mode.
    /// </value>
    public static OverwriteMode Overwrite => new OverwriteMode("a");

    /// <summary>
    /// Gets the skip-Mode.
    /// Skip extracting of existing files.
    /// </summary>
    /// <value>
    /// The skip-Mode.
    /// </value>
    public static OverwriteMode Skip => new OverwriteMode("s");

    /// <summary>
    /// Gets the rename extracting-Mode.
    /// aUto rename extracting file (for example, name.txt will be renamed to name_1.txt).
    /// </summary>
    /// <value>
    /// The rename extracting-Mode.
    /// </value>
    public static OverwriteMode RenameExtracting => new OverwriteMode("u");

    /// <summary>
    /// Gets the rename existing-Mode.
    /// auto rename existing file (for example, name.txt will be renamed to name_1.txt).
    /// </summary>
    /// <value>
    /// The rename existing-Mode.
    /// </value>
    public static OverwriteMode RenameExisting => new OverwriteMode("t");

    /// <inheritdoc />
    public override string ToString()
    {
        return mode;
    }
}