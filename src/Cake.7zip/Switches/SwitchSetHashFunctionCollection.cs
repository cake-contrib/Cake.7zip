namespace Cake.SevenZip.Switches
{
    /// <summary>
    /// A Collection of <see cref="SwitchSetHashFunction"/>.
    /// </summary>
    /// <seealso cref="BaseSwitchCollection{T}" />
    public class SwitchSetHashFunctionCollection : BaseSwitchCollection<SwitchSetHashFunction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchSetHashFunctionCollection"/> class.
        /// </summary>
        /// <param name="initial">The initial.</param>
        /// <param name="additional">The additional.</param>
        public SwitchSetHashFunctionCollection(SwitchSetHashFunction initial, params SwitchSetHashFunction[] additional)
        {
            Switches.Add(initial);
            Switches.AddRange(additional);
        }
    }
}
