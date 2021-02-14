using Cake.Core;
using Cake.Core.IO;
using Cake.Frosting;

namespace Build
{
    public class BuildContext : FrostingContext
    {
        public DirectoryPath Root { get; set; }

        public DirectoryPath Output { get; set; }

        public BuildContext(ICakeContext context)
            : base(context)
        {
        }
    }
}
