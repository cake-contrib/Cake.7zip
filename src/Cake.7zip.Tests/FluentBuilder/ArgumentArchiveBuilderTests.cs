using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Commands;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class ArgumentArchiveBuilderTests
    {
        [Fact]
        public void WithArchive_returns_the_builder()
        {
            var expected = new Mock<ISupportArgumentBuilder<IHaveArgumentArchive>>();
            expected.Setup(x => x.Command).Returns(new Mock<IHaveArgumentArchive>().Object);

            var actual = expected.Object.WithArchive(new FilePath("foo"));

            Assert.Equal(expected.Object, actual);
        }

        [Fact]
        public void WithArchive_sets_the_archive()
        {
            var builder = new Mock<ISupportArgumentBuilder<IHaveArgumentArchive>>();
            var command = new Mock<IHaveArgumentArchive>();
            command.SetupSet(c => c.Archive = It.IsAny<FilePath>()).Verifiable();
            builder.Setup(x => x.Command).Returns(command.Object);
            var expected = new FilePath("foo");

            builder.Object.WithArchive(expected);

            command.VerifySet(c => c.Archive = expected, Times.Once);
        }
    }
}
