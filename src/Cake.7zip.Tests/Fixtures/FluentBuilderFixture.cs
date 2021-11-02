using Cake.Core.IO;
using Cake.SevenZip.Builder;

namespace Cake.SevenZip.Tests.Fixtures
{
    public class FluentBuilderFixture
    {
        internal CommandBuilder Context { get; }

        public FluentBuilderFixture()
        {
            Context = new CommandBuilder();
        }

        public string EvaluateArgs()
        {
            var args = new ProcessArgumentBuilder();
            Context.Command?.BuildArguments(ref args);
            return args.Render();
        }
    }
}
