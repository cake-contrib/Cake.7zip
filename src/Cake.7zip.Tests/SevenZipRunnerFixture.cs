namespace Cake.SevenZip.Tests
{
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Testing;
    using Cake.Testing.Fixtures;

    public class SevenZipRunnerFixture : ToolFixture<SevenZipSettings>
    {
        private ICakeEnvironment environment;

        public SevenZipRunnerFixture()
          : base("SevenZip.exe")
        {
            FakeEnvironment.CreateWindowsEnvironment();
        }

        protected override void RunTool()
        {
            var tool = new SevenZipRunner(FileSystem, Environment, ProcessRunner, Tools);
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