namespace Cake.7zip.Tests
{
  using System.Collections.Generic;
  using System.Linq;
  using Cake.Core;
  using Cake.Core.IO;
  using Cake.Testing;
  using Cake.Testing.Fixtures;
  using Moq;

  public class 7zipAliasesFixture : 7zipRunnerFixture
  {
    internal ICakeContext _context;

    public 7zipAliasesFixture()
    {
      var argumentsMoq = new Mock<ICakeArguments>();
      var registryMoq = new Mock<IRegistry>();
      var dataService = new Mock<ICakeDataService>();
      _context = new CakeContext(
        FileSystem,
        Environment,
        Globber,
        new FakeLog(),
        argumentsMoq.Object,
        ProcessRunner,
        registryMoq.Object,
        Tools,dataService.Object,
        Configuration);
    }

    protected override void RunTool()
    {
      if (Settings == null)
      {
        7zipAliases.7zip(_context);
      }
      else
      {
        7zipAliases.7zip(_context, Settings);
      }
    }
  }
}
