using System.Linq;

using Cake.Core.IO;
using Cake.SevenZip.Arguments;
using Cake.SevenZip.Builder;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class ArgumentFilesBuilderTests
    {
        [Fact]
        public void WithFiles_returns_the_builder()
        {
            var expected = new Mock<ISupportArgumentBuilder<IHaveArgumentFiles>>();
            var command = new Mock<IHaveArgumentFiles>();
            command.SetupProperty(c => c.Files);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithFiles(new FilePath("foo"));

            actual.ShouldBe(expected.Object);
        }

        [Fact]
        public void WithFiles_collection_returns_the_builder()
        {
            var expected = new Mock<ISupportArgumentBuilder<IHaveArgumentFiles>>();
            var command = new Mock<IHaveArgumentFiles>();
            command.SetupProperty(c => c.Files);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithFiles(new FilePathCollection());

            actual.ShouldBe(expected.Object);
        }

        [Fact]
        public void WithFiles_sets_the_directoryContents()
        {
            var builder = new Mock<ISupportArgumentBuilder<IHaveArgumentFiles>>();
            var command = new Mock<IHaveArgumentFiles>();
            command.SetupProperty(c => c.Files);
            builder.Setup(x => x.Command).Returns(command.Object);
            var expected = new FilePath("foo");

            builder.Object.WithFiles(expected);

            command.Object.Files.Single().ShouldBe(expected);
        }

        [Fact]
        public void WithFiles_collection_sets_the_directoryContents()
        {
            var builder = new Mock<ISupportArgumentBuilder<IHaveArgumentFiles>>();
            var command = new Mock<IHaveArgumentFiles>();
            command.SetupProperty(c => c.Files);
            builder.Setup(x => x.Command).Returns(command.Object);
            var expected = new FilePath("foo");

            builder.Object.WithFiles(new FilePathCollection(new[] { expected }));

            command.Object.Files.Single().ShouldBe(expected);
        }
    }
}
