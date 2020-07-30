using System.Linq;

using Cake.Core.IO;
using Cake.SevenZip.Builder;
using Cake.SevenZip.Commands;

using FluentAssertions;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class ArgumentDirectoriesBuilderTests
    {
        [Fact]
        public void WithDirectories_returns_the_builder()
        {
            var expected = new Mock<ISupportArgumentBuilder<IHaveArgumentDirectories>>();
            var command = new Mock<IHaveArgumentDirectories>();
            command.SetupProperty(c => c.Directories);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithDirectories(new DirectoryPath("foo"));

            actual.Should().Be(expected.Object);
        }

        [Fact]
        public void WithDirectories_collection_returns_the_builder()
        {
            var expected = new Mock<ISupportArgumentBuilder<IHaveArgumentDirectories>>();
            var command = new Mock<IHaveArgumentDirectories>();
            command.SetupProperty(c => c.Directories);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithDirectories(new DirectoryPathCollection());

            actual.Should().Be(expected.Object);
        }

        [Fact]
        public void WithDirectoryContents_returns_the_builder()
        {
            var expected = new Mock<ISupportArgumentBuilder<IHaveArgumentDirectories>>();
            var command = new Mock<IHaveArgumentDirectories>();
            command.SetupProperty(c => c.DirectoryContents);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithDirectoryContents(new DirectoryPath("foo"));

            actual.Should().Be(expected.Object);
        }

        [Fact]
        public void WithDirectoryContents_collection_returns_the_builder()
        {
            var expected = new Mock<ISupportArgumentBuilder<IHaveArgumentDirectories>>();
            var command = new Mock<IHaveArgumentDirectories>();
            command.SetupProperty(c => c.DirectoryContents);
            expected.Setup(x => x.Command).Returns(command.Object);

            var actual = expected.Object.WithDirectoryContents(new DirectoryPathCollection());

            actual.Should().Be(expected.Object);
        }

        [Fact]
        public void WithDirectoryContents_sets_the_directoryContents()
        {
            var builder = new Mock<ISupportArgumentBuilder<IHaveArgumentDirectories>>();
            var command = new Mock<IHaveArgumentDirectories>();
            command.SetupProperty(c => c.DirectoryContents);
            builder.Setup(x => x.Command).Returns(command.Object);
            var expected = new DirectoryPath("foo");

            builder.Object.WithDirectoryContents(expected);
            command.Object.DirectoryContents.Single().Should().Be(expected);
        }

        [Fact]
        public void WithDirectoryContents_collection_sets_the_directoryContents()
        {
            var builder = new Mock<ISupportArgumentBuilder<IHaveArgumentDirectories>>();
            var command = new Mock<IHaveArgumentDirectories>();
            command.SetupProperty(c => c.DirectoryContents);
            builder.Setup(x => x.Command).Returns(command.Object);
            var expected = new DirectoryPath("foo");

            builder.Object.WithDirectoryContents(new DirectoryPathCollection(new[] { expected }));

            command.Object.DirectoryContents.Single().Should().Be(expected);
        }

        [Fact]
        public void WithDirectories_sets_the_directoryContents()
        {
            var builder = new Mock<ISupportArgumentBuilder<IHaveArgumentDirectories>>();
            var command = new Mock<IHaveArgumentDirectories>();
            command.SetupProperty(c => c.Directories);
            builder.Setup(x => x.Command).Returns(command.Object);
            var expected = new DirectoryPath("foo");

            builder.Object.WithDirectories(expected);

            command.Object.Directories.Single().Should().Be(expected);
        }

        [Fact]
        public void WithDirectories_collection_sets_the_directoryContents()
        {
            var builder = new Mock<ISupportArgumentBuilder<IHaveArgumentDirectories>>();
            var command = new Mock<IHaveArgumentDirectories>();
            command.SetupProperty(c => c.Directories);
            builder.Setup(x => x.Command).Returns(command.Object);
            var expected = new DirectoryPath("foo");

            builder.Object.WithDirectories(new DirectoryPathCollection(new[] { expected }));

            command.Object.Directories.Single().Should().Be(expected);
        }
    }
}
