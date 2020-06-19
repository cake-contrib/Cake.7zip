using Cake.Core.IO;
using Cake.Testing;

using Moq;

using System.Text;

using Xunit;

namespace Cake.SevenZip.Tests
{
    public class SevenZipAliasesTests
    {
        [Fact]
        public void Should_support_using_settings()
        {
            var fixture = new SevenZipAliasesFixture();
            var command = new Mock<ICommand>();
            command.Setup(c => c.BuildArguments(ref It.Ref<ProcessArgumentBuilder>.IsAny));
            fixture.Settings.Command = command.Object;

            fixture.Run();

            command.Verify(c => c.BuildArguments(ref It.Ref<ProcessArgumentBuilder>.IsAny), Times.Once);
        }

        [Fact]
        public void Should_support_using_fluent_add()
        {
            var fixture = new SevenZipAliasesFixture();

            fixture.Context.SevenZip(s => s
                .InAddMode()
                .WithArchive("zip.zip")
                .WithFiles("in.txt"));

            // TODO WHAT TO TEST?! - and how?!
        }
    }
}
