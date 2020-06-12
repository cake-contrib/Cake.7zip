namespace Cake.SevenZip.Tests.Settings
{
  using System;

  using Cake.Core.IO;

  public class SevenZipSettingsFixture
  {
    public string Parse(Action<ProcessArgumentBuilder> action)
    {
      var builder = new ProcessArgumentBuilder();
      action(builder);
      return builder.Render();
    }
  }
}
