namespace Cake.SevenZip.Tests
{
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.SevenZip.Builder;

    public class FluentBuilderFixture
    {
        internal ICakeContext _cakeContext;
        internal SevenZipBuilderContext Context { get; private set; }

        public FluentBuilderFixture()
        {
            Context = new SevenZipBuilderContext();
        }

        public string EvaluateArgs()
        {
            var args = new ProcessArgumentBuilder();
            Context.Settings.Command.BuildArguments(ref args);
            return args.Render();
        }
    }
}
