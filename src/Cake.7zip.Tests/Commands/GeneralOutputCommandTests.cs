using System;
using System.Collections;
using System.Collections.Generic;

using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;

using FluentAssertions;

using Xunit;

namespace Cake.SevenZip.Tests.Commands
{
    public class GeneralOutputCommandTests
    {
        [Theory]
        [ClassData(typeof(TestData))]
        public void OutputCommand_uses_its_own_parser<T>(OutputCommand<T> command, Type expectedParserType)
            where T : IOutput
        {
            var actual = command.OutputParser;
            actual.Should().NotBeNull();
            actual.Should().BeOfType(expectedParserType);
        }

        private class TestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new InformationCommand(), typeof(InformationOutputParser) };
                yield return new object[] { new TestCommand(), typeof(TestOutputParser) };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
