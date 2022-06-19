using CalastoneTest.Filter;
using FluentAssertions;
using NUnit.Framework;

namespace CalastoneUnitTests.Filter
{
    [TestFixture]
    public class ContainCharacterFilterTests
    {
        [TestCase('t', new[] {"The", "Test", "to", "as", "I"}, 2)]
        [TestCase('o', new[] { "The", "Test", "to", "as", "I" }, 4)]
        [TestCase('e', new[] { "The", "Test", "to", "as", "I" }, 3)]
        public void FilterInputCorrectly(char chracterToFilter, string[] input, int expectedLength)
        {
            var sut = new ContainCharacterFilter(chracterToFilter);

            var result = sut.Execute(input);

            result.Count().Should().Be(expectedLength);
        }

        [Test]
        public void FilterInputIgnoreCase()
        {
            var sut = new ContainCharacterFilter('t');

            var result = sut.Execute(new[] {"There", "there", "The", "their", "random"});

            result.Count().Should().Be(1);
        }
    }
}
