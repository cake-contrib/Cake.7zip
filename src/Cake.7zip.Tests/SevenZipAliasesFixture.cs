namespace Cake.SevenZip.Tests
{
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Testing;

    using Moq;

    public class SevenZipAliasesFixture : SevenZipRunnerFixture
    {
        internal ICakeContext _context;

        public SevenZipAliasesFixture()
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
              Tools, dataService.Object,
              Configuration);
        }

        protected override void RunTool()
        {
            SevenZipAliases.SevenZip(_context, Settings);
        }
    }
}
