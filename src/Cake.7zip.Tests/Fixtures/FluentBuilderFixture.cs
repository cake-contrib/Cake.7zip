namespace Cake.SevenZip.Tests
{
    using Cake.Core.IO;
    using Cake.SevenZip;

    using Moq;

    public class FluentBuilderFixture
    {
        internal CommandBuilder Context { get; private set; }

        public FluentBuilderFixture()
        {
            Context = new CommandBuilder();
        }

        public string EvaluateArgs()
        {
            var args = new ProcessArgumentBuilder();
            Context.Command.BuildArguments(ref args);
            return args.Render();
        }
    }
}
