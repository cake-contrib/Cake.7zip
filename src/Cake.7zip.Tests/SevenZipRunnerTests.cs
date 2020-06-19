namespace Cake.SevenZip.Tests
{
    using System;

    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Testing;

    using Xunit;

    public class SevenZipRunnerTests
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            var fixture = new SevenZipRunnerFixture { Settings = null };

            void result() => fixture.Run();

            Assert.Throws<ArgumentNullException>(result);
        }

        [Fact]
        public void Should_Throw_If_SevenZip_Executable_Was_Not_Found()
        {
            var fixture = new SevenZipRunnerFixture
            {
                Settings = new SevenZipSettings
                {
                    Command = new NoCommand()
                }
            };
            fixture.GivenDefaultToolDoNotExist();
            const string expectedMessage = "7-Zip: Could not locate executable.";

            void result() => fixture.Run();

            var ex = Assert.Throws<CakeException>(result);
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void Should_Throw_If_Command_is_null()
        {
            var fixture = new SevenZipRunnerFixture
            {
                Settings = new SevenZipSettings
                {
                    Command = null
                }
            };
            const string expectedMessage = "7-Zip: Command can not be null - a command is needed to run!";

            void result() => fixture.Run();

            var ex = Assert.Throws<CakeException>(result);
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void Can_zip_some_Files()
        {
            var fixture = new SevenZipRunnerFixture
            {
                Settings = new SevenZipSettings
                {
                    Command = new AddCommand
                    {
                        Files = new FilePathCollection(new[] { new FilePath("a.txt"), new FilePath("b.txt") }),
                        Archive = new FilePath("out.zip")
                    }
                }
            };
            const string expected = @"a ""out.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Can_zip_and_split_some_Files()
        {
            var fixture = new SevenZipRunnerFixture
            {
                Settings = new SevenZipSettings
                {
                    Command = new AddCommand
                    {
                        Files = new FilePathCollection(new[] { new FilePath("a.txt"), new FilePath("b.txt") }),
                        Archive = new FilePath("out.zip"),
                        Volumes = new SwitchVolumeCollection(
                    new SwitchVolume
                    {
                        Size = 1,
                        Unit = VolumeUnit.Gigabytes
                    },
                    new SwitchVolume
                    {
                        Size = 2,
                        Unit = VolumeUnit.Megabytes
                    })
                    }
                }
            };
            const string expected = @"a -v1g -v2m ""out.zip"" ""a.txt"" ""b.txt""";

            var actual = fixture.EvaluateArgs();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Throw_CakeException_If_Command_throws()
        {
            var fixture = new SevenZipRunnerFixture
            {
                Settings = new SevenZipSettings
                {
                    Command = new ThrowCommand()
                }
            };
            const string expectedMessage = "7-Zip: Intentionally not implemented.";

            void result() => fixture.Run();

            var ex = Assert.Throws<CakeException>(result);
            Assert.Equal(expectedMessage, ex.Message);
        }
    }

    internal class NoCommand : ICommand
    {
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            // no-op
        }
    }

    internal class ThrowCommand : ICommand
    {
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            throw new NotImplementedException("Intentionally not implemented.");
        }
    }
}
