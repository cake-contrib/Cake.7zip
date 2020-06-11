namespace Cake.7zip
{
  using System;
  using System.Collections.Generic;
  using Cake.Core;
  using Cake.Core.IO;
  using Cake.Core.Tooling;

  public sealed class 7zipRunner : Tool<7zipSettings>
  {
    public 7zipRunner(
      IFileSystem fileSystem,
      ICakeEnvironment environment,
      IProcessRunner processRunner,
      IToolLocator tools)
      : base(fileSystem, environment, processRunner, tools)
    {
    }

    public void Run(7zipSettings settings)
    {
      if (settings == null)
      {
        throw new ArgumentNullException(nameof(settings));
      }

      this.Run(settings, GetArguments(settings));
    }

    protected override IEnumerable<string> GetToolExecutableNames()
    {
      yield return "7zip.exe";
      yield return "7zip";
    }

    protected override string GetToolName()
    {
      return "7zip";
    }

    private static ProcessArgumentBuilder GetArguments(7zipSettings settings)
    {
      var builder = new ProcessArgumentBuilder();

      // TODO: Add the necessary arguments based on the settings class

      return builder;
    }
  }
}
