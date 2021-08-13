using System;
using System.Collections;
using System.Collections.Generic;

using Cake.SevenZip.Commands;
using Cake.SevenZip.Parsers;

using Shouldly;

using Xunit;

namespace Cake.SevenZip.Tests.Commands
{
    public class BenchmarkCommandTests
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
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
