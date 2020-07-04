using Cake.Core.IO;
using Cake.Testing;
using Cake.Testing.Fixtures;

using Moq;

namespace Cake.SevenZip.Tests
{
    public class SevenZipRunnerFixture : ToolFixture<SevenZipSettings>
    {
        internal Mock<IRegistry> Registry { get; set; }
        internal FakeLog Log { get; }

        public SevenZipRunnerFixture()
          : base("7za.exe")
        {
            Log = new FakeLog();
            Registry = new Mock<IRegistry>();
        }

        public void GivenProcessReturnsStdOutputOf(string[] stdOutput)
        {
            ProcessRunner.Process.SetStandardOutput(stdOutput);
        }

        protected override void RunTool()
        {
            var tool = new SevenZipRunner(
                FileSystem,
                Environment,
                ProcessRunner,
                Tools,
                Log,
                Registry?.Object);
            tool.Run(Settings);
        }

        public string EvaluateArgs()
        {
            var args = new ProcessArgumentBuilder();
            Settings.Command.BuildArguments(ref args);
            return args.Render();
        }
    }
}
