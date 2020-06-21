namespace Cake.SevenZip.Tests
{
    using Cake.Core.IO;
    using Cake.Core.Tooling;
    using Cake.Testing;
    using Cake.Testing.Fixtures;

    using Moq;

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
