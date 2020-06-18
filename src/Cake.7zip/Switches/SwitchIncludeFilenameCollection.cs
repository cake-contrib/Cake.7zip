﻿namespace Cake.SevenZip
{

    /// <summary>
    /// A Collection of <see cref="SwitchIncludeFilename"/>.
    /// </summary>
    /// <seealso cref="SwitchCollection{T}" />
    public class SwitchIncludeFilenameCollection : SwitchCollection<SwitchIncludeFilename>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwitchIncludeFilenameCollection"/> class.
        /// </summary>
        /// <param name="initial">The initial.</param>
        /// <param name="additional">The additional.</param>
        public SwitchIncludeFilenameCollection(SwitchIncludeFilename initial, params SwitchIncludeFilename[] additional)
          : base()
        {
            Switches.Add(initial);
            Switches.AddRange(additional);
        }
    }
}