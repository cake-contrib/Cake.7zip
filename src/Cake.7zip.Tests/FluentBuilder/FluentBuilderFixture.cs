namespace Cake.SevenZip.Tests
{
    using Cake.Core.IO;

    public class FluentBuilderFixture
    {
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
