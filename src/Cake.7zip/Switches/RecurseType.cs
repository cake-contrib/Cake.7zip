namespace Cake.SevenZip
{
    /// <summary>
    /// Specifies the method of treating wildcards and filenames on the command line.
    /// </summary>
    public sealed class RecurseType
    {
        private readonly string type;

        private RecurseType(string type)
        {
            this.type = type;
        }

        /// <summary>
        /// Gets the enable-type.
        /// </summary>
        /// <value>
        /// The enable-type.
        /// </value>
        public static RecurseType Enable => new RecurseType(string.Empty);

        /// <summary>
        /// Gets the disable-type.
        /// </summary>
        /// <value>
        /// The disable-type.
        /// </value>
        public static RecurseType Disable => new RecurseType("-");

        /// <summary>
        /// Gets the enable only for wildcard names -type.
        ///
        /// (Probably this is not needed in Cake.7zip -
        /// there are wildcard-names in this implementation.)
        /// </summary>
        /// <value>
        /// The enable only for wildcard names -type.
        /// </value>
        public static RecurseType EnableOnlyForWildcardNames => new RecurseType("0");

        /// <inheritdoc/>
        public override string ToString()
        {
            return type;
        }
    }
}
