namespace Cake.7zip.Tests
{
  using Cake.Testing.Fixtures;

  public class 7zipRunnerFixture : ToolFixture<7zipSettings>
  {
    public 7zipRunnerFixture()
      : base("7zip.exe")
    {
    }

    protected override void RunTool()
    {
      var tool = new 7zipRunner(FileSystem, Environment, ProcessRunner, Tools);
      tool.Run(Settings);
    }
  }
}
