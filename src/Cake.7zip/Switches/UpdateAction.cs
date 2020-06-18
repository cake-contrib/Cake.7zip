namespace Cake.SevenZip
{
    /// <summary>
    /// Specifies the action for a given <see cref="SwitchUpdateOptions"/>-State.
    /// </summary>
    public sealed class UpdateAction
    {
        private readonly string action;

        private UpdateAction(string action)
        {
            this.action = action;
        }

        /// <summary>
        /// Gets the ignore-action.
        /// Ignore file (don't create item in new archive for this file).
        /// </summary>
        /// <value>
        /// The ignore-action.
        /// </value>
        public static UpdateAction Ignore => new UpdateAction("0");

        /// <summary>
        /// Gets the copy-action.
        /// Copy file (copy from old archive to new).
        /// </summary>
        /// <value>
        /// The copy-action.
        /// </value>
        public static UpdateAction Copy => new UpdateAction("1");

        /// <summary>
        /// Gets the compress-action.
        /// Compress (compress file from disk to new archive).
        /// </summary>
        /// <value>
        /// The copress-action.
        /// </value>
        public static UpdateAction Compress => new UpdateAction("2");

        /// <summary>
        /// Gets the anti-action.
        /// Create Anti-item (item that will delete file or directory during extracting). This feature is supported only in 7z format.
        /// </summary>
        /// <value>
        /// The anti-action.
        /// </value>
        public static UpdateAction Anti => new UpdateAction("3");

        /// <inheritdoc/>
        public override string ToString()
        {
            return action;
        }
    }
}
