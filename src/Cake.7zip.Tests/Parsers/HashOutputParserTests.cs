using System.Linq;

using Cake.SevenZip.Parsers;
using Cake.SevenZip.Tests.Fixtures;

using FluentAssertions;

using Xunit;

namespace Cake.SevenZip.Tests.Parsers
{
    public class HashOutputParserTests
    {
        [Fact]
        public void HashParser_parses_InfoLine()
        {
            var parser = new HashOutputParser();

            var actual = parser.Parse(Outputs.Hash);
            const string expected = "7-Zip 19.00 (x64) : Copyright (c) 1999-2018 Igor Pavlov : 2019-02-21";

            actual.Information.Should().Be(expected);
        }

        [Fact]
        public void HashParser_parses_Files_ok()
        {
            var parser = new HashOutputParser();
            var actual = parser.Parse(Outputs.Hash).Files.Single();

            actual.FilePath.Should().Be("docs\\input\\index.cshtml");
            actual.Size.Should().Be(1450);

            // hashes
            var hashes = actual.Hashes.ToList();
            hashes.Single(x => x.HashFunction == "CRC32").Hash.Should().Be("65F628E7");
            hashes.Single(x => x.HashFunction == "CRC64").Hash.Should().Be("0C263A6A38541BE2");
            hashes.Single(x => x.HashFunction == "SHA1").Hash.Should().Be("30A96827A2BD56E1139FFA1988E53C6BDB400D5D");
            hashes.Single(x => x.HashFunction == "SHA256").Hash.Should().Be("735E9C514689F10220846742C8871A665F5888D5C36F71F949C70D9B5FBBFBD6");
            hashes.Single(x => x.HashFunction == "BLAKE2sp").Hash.Should().Be("46569382381890A5F29264F0B7EA8EE3628C714911AE43839CC444490033BABD");
        }

        [Fact]
        public void HashParser_parses_SumOfHashes_Ok()
        {
            var parser = new HashOutputParser();
            var actual = parser.Parse(Outputs.Hash).SumOfHashes.ToList();

            actual.Single(x => x.HashFunction == "CRC32").Hash.Should().Be("65F628E7");
            actual.Single(x => x.HashFunction == "CRC64").Hash.Should().Be("0C263A6A38541BE2");
            actual.Single(x => x.HashFunction == "SHA1").Hash.Should().Be("30A96827A2BD56E1139FFA1988E53C6BDB400D5D");
            actual.Single(x => x.HashFunction == "SHA256").Hash.Should().Be("735E9C514689F10220846742C8871A665F5888D5C36F71F949C70D9B5FBBFBD6");
            actual.Single(x => x.HashFunction == "BLAKE2sp").Hash.Should().Be("46569382381890A5F29264F0B7EA8EE3628C714911AE43839CC444490033BABD");
        }

        [Fact]
        public void HashParser_parses_HashOfData_Ok()
        {
            var parser = new HashOutputParser();
            var actual = parser.Parse(Outputs.Hash).HashesOfData.ToList();

            actual.Single(x => x.HashFunction == "CRC32").Hash.Should().Be("65F628E7");
            actual.Single(x => x.HashFunction == "CRC64").Hash.Should().Be("0C263A6A38541BE2");
            actual.Single(x => x.HashFunction == "SHA1").Hash.Should().Be("30A96827A2BD56E1139FFA1988E53C6BDB400D5D");
            actual.Single(x => x.HashFunction == "SHA256").Hash.Should().Be("735E9C514689F10220846742C8871A665F5888D5C36F71F949C70D9B5FBBFBD6");
            actual.Single(x => x.HashFunction == "BLAKE2sp").Hash.Should().Be("46569382381890A5F29264F0B7EA8EE3628C714911AE43839CC444490033BABD");
        }

        [Fact]
        public void HashParser_parses_HashOfDataAndNames_Ok()
        {
            var parser = new HashOutputParser();
            var actual = parser.Parse(Outputs.Hash).HashOfDataAndNames.ToList();

            actual.Single(x => x.HashFunction == "CRC32").Hash.Should().Be("DDEFD8B7");
            actual.Single(x => x.HashFunction == "CRC64").Hash.Should().Be("7914AFBA69DF8351");
            actual.Single(x => x.HashFunction == "SHA1").Hash.Should().Be("4B179021A00AE3AD7ACD2044212EF055CD31C6D8");
            actual.Single(x => x.HashFunction == "SHA256").Hash.Should().Be("22B8DE058E187C59B75D3E385864B8713E1A1D8315E137526E6BD069936B342A");
            actual.Single(x => x.HashFunction == "BLAKE2sp").Hash.Should().Be("222855D590C06DE9B42BF15335DBC6EF14798938E202808A5C7DFE9BC38F8F25");
        }

        [Fact]
        public void HashParser_parses_SumOfSizes_Ok()
        {
            var parser = new HashOutputParser();
            var actual = parser.Parse(Outputs.Hash).SumOfSizes;

            actual.Should().Be(1450);
        }
    }
}
