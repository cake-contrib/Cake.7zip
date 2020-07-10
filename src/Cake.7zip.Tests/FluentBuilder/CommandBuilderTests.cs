using System;
using System.Collections;
using System.Collections.Generic;

using Cake.SevenZip.Builder;

using Xunit;

namespace Cake.SevenZip.Tests.FluentBuilder
{
    public class CommandBuilderTests
    {
        [Theory]
        [ClassData(typeof(TestData))]
        public void CommandBuilder_retuns_all_SubBuilders(Func<CommandBuilder, object> mode, Type expected)
        {
            var sut = new CommandBuilder();
            var actual = mode(sut);

            Assert.Equal(expected, actual.GetType());
        }

        private class TestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { (Func<CommandBuilder, object>)(x => x.InAddMode()), typeof(AddCommandBuilder) };
                yield return new object[] { (Func<CommandBuilder, object>)(x => x.InDeleteMode()), typeof(DeleteCommandBuilder) };
                yield return new object[] { (Func<CommandBuilder, object>)(x => x.InExtractMode()), typeof(ExtractCommandBuilder) };
                yield return new object[] { (Func<CommandBuilder, object>)(x => x.InInformationMode()), typeof(InformationCommandBuilder) };
                yield return new object[] { (Func<CommandBuilder, object>)(x => x.InUpdateMode()), typeof(UpdateCommandBuilder) };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
