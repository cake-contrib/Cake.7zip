using System;
using System.Collections;
using System.Collections.Generic;

using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;

using Shouldly;

using Xunit;

namespace Cake.SevenZip.Tests.Commands;

public class GeneralOutputCommandTests
{
    [Theory]
    [ClassData(typeof(TestData))]
    public void OutputCommand_uses_its_own_parser<T>(BaseOutputCommand<T> command, Type expectedParserType)
        where T : IOutput
    {
        var actual = command.OutputParser;
        actual.ShouldNotBeNull();
        actual.ShouldBeOfType(expectedParserType);
    }

    private class TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new InformationCommand(), typeof(InformationOutputParser) };
            yield return new object[] { new TestCommand(), typeof(TestOutputParser) };
            yield return new object[] { new HashCommand(), typeof(HashOutputParser) };
            yield return new object[] { new BenchmarkCommand(), typeof(BenchmarkOutputParser) };
            yield return new object[] { new ListCommand(), typeof(ListOutputParser) };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}