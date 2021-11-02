using System;
using System.Diagnostics.CodeAnalysis;

using Cake.Core;
using Cake.Core.IO;
using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;
using Cake.SevenZip.Switches;
using Cake.SevenZip.Tests.Fixtures;
using Cake.Testing;

using Shouldly;

using Moq;

using Xunit;

namespace Cake.SevenZip.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "I like my 'local functions' camelCase.")]
    public class SevenZipRunnerTests
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            var fixture = new SevenZipRunnerFixture { Settings = null! };

            Action result = () =>
            {
                fixture.Run();
            };

            result.ShouldThrow<ArgumentNullException>();
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

            Action result = () =>
            {
                fixture.Run();
            };

            result.ShouldThrow<CakeException>().Message.ShouldBe(expectedMessage);
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

            Action result = () =>
            {
                fixture.Run();
            };

            result.ShouldThrow<CakeException>().Message.ShouldBe(expectedMessage);
        }

        [Fact]
        public void Should_Access_registry()
        {
            var fixture = new SevenZipRunnerFixture
            {
                Settings = new SevenZipSettings
                {
                    Command = new NoCommand()
                }
            };

            fixture.GivenDefaultToolDoNotExist();
            fixture.GivenProcessExitsWithCode(0);
            var installLocation = fixture.FileSystem.CreateDirectory("/temp7z");
            var file = fixture.FileSystem.CreateFile(installLocation.Path.CombineWithFilePath("7z.exe"));

            var sevenZipKey = new Mock<IRegistryKey>();
            sevenZipKey.Setup(k => k.GetValue("Path")).Returns(installLocation.Path.FullPath);
            sevenZipKey.Setup(k => k.GetValue("Path64")).Returns(null);
            var softwareKey = new Mock<IRegistryKey>();
            softwareKey.Setup(k => k.OpenKey("7-Zip")).Returns(sevenZipKey.Object);
            var hklm = new Mock<IRegistryKey>();
            hklm.Setup(k => k.OpenKey("Software")).Returns(softwareKey.Object);
            fixture.Registry.Setup(r => r.LocalMachine).Returns(hklm.Object);

            var result = fixture.Run();

            sevenZipKey.Verify(k => k.GetValue("Path"), Times.Once);
            sevenZipKey.Verify(k => k.GetValue("Path64"), Times.Once);
            result.Path.FullPath.ShouldBe(file.Path.FullPath);
        }

        [Fact]
        public void Should_Access_64bit_tool_from_registry()
        {
            var fixture = new SevenZipRunnerFixture
            {
                Settings = new SevenZipSettings
                {
                    Command = new NoCommand()
                }
            };

            fixture.Environment.Platform.Is64Bit = true;
            fixture.GivenDefaultToolDoNotExist();
            fixture.GivenProcessExitsWithCode(0);
            var installLocation = fixture.FileSystem.CreateDirectory("/temp7z");
            var file = fixture.FileSystem.CreateFile(installLocation.Path.CombineWithFilePath("7z.exe"));

            var sevenZipKey = new Mock<IRegistryKey>();
            sevenZipKey.Setup(k => k.GetValue("Path")).Returns(null);
            sevenZipKey.Setup(k => k.GetValue("Path64")).Returns(installLocation.Path.FullPath);
            var softwareKey = new Mock<IRegistryKey>();
            softwareKey.Setup(k => k.OpenKey("7-Zip")).Returns(sevenZipKey.Object);
            var hklm = new Mock<IRegistryKey>();
            hklm.Setup(k => k.OpenKey("Software")).Returns(softwareKey.Object);
            fixture.Registry.Setup(r => r.LocalMachine).Returns(hklm.Object);

            var result = fixture.Run();

            result.Path.FullPath.ShouldBe(file.Path.FullPath);
        }

        [Fact]
        public void Should_not_access_registry_if_Default_exists()
        {
            var fixture = new SevenZipRunnerFixture
            {
                Settings = new SevenZipSettings
                {
                    Command = new NoCommand()
                }
            };

            fixture.GivenProcessExitsWithCode(0);

            var sevenZipKey = new Mock<IRegistryKey>();
            sevenZipKey.Setup(k => k.GetValue("Path")).Returns(string.Empty);
            sevenZipKey.Setup(k => k.GetValue("Path64")).Returns(string.Empty);
            var softwareKey = new Mock<IRegistryKey>();
            softwareKey.Setup(k => k.OpenKey("7-Zip")).Returns(sevenZipKey.Object);
            var hklm = new Mock<IRegistryKey>();
            hklm.Setup(k => k.OpenKey("Software")).Returns(softwareKey.Object);
            fixture.Registry.Setup(r => r.LocalMachine).Returns(hklm.Object);

            var result = fixture.Run();

            sevenZipKey.Verify(k => k.GetValue("Path"), Times.Never);
            result.Path.FullPath.ShouldBe(fixture.DefaultToolPath.FullPath);
        }

        [Fact]
        public void Should_throw_ToolNotFound_if_registry_throws()
        {
            var fixture = new SevenZipRunnerFixture
            {
                Settings = new SevenZipSettings
                {
                    Command = new NoCommand()
                }
            };

            fixture.GivenDefaultToolDoNotExist();
            var hklm = new Mock<IRegistryKey>();
            hklm.Setup(k => k.OpenKey("Software")).Throws(new AccessViolationException("No!"));
            fixture.Registry.Setup(r => r.LocalMachine).Returns(hklm.Object);

            Action action = () =>
            {
                fixture.Run();
            };

            action.ShouldThrow<CakeException>();
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

            actual.ShouldBe(expected);
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

            actual.ShouldBe(expected);
        }

        [Fact]
        public void Should_Throw_CakeException_If_Command_throws()
        {
            var command = new Mock<ICommand>();
            command.Setup(c => c.BuildArguments(ref It.Ref<ProcessArgumentBuilder>.IsAny))
                .Throws(new NotImplementedException("Intentionally not implemented."));
            var fixture = new SevenZipRunnerFixture
            {
                Settings = new SevenZipSettings
                {
                    Command = command.Object
                }
            };
            const string expectedMessage = "7-Zip: Intentionally not implemented.";

            Action result = () =>
            {
                fixture.Run();
            };

            result.ShouldThrow<CakeException>().Message.ShouldBe(expectedMessage);
        }

        [Fact]
        public void Should_Set_output_null_on_outputCommand_whithout_output()
        {
            var command = new Mock<BaseOutputCommand<IOutput>>();
            var outputParseCommand = command.As<ICanParseOutput>();
            var fixture = new SevenZipRunnerFixture
            {
                Settings = new SevenZipSettings
                {
                    Command = command.Object
                }
            };
            fixture.GivenProcessReturnsStdOutputOf(null);

            fixture.Run();

            outputParseCommand.Verify(c => c.SetRawOutput(null!), Times.Once);
        }

        [Fact]
        public void Should_Set_output_on_outputCommand()
        {
            var command = new Mock<BaseOutputCommand<IOutput>>();
            var outputParseCommand = command.As<ICanParseOutput>();
            var parser = new Mock<IOutputParser<IOutput>>();
            command.Setup(c => c.OutputParser).Returns(parser.Object);
            var fixture = new SevenZipRunnerFixture
            {
                Settings = new SevenZipSettings
                {
                    Command = command.Object
                }
            };
            var expected = new[] { "this", "is", "the", "output" };
            fixture.GivenProcessReturnsStdOutputOf(expected);

            fixture.Run();

            outputParseCommand.Verify(c => c.SetRawOutput(expected), Times.Once);
        }
    }

    internal class NoCommand : ICommand
    {
        public void BuildArguments(ref ProcessArgumentBuilder builder)
        {
            // no-op
        }
    }
}
