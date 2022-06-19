using CalastoneTest.Filter;
using FluentAssertions;
using NUnit.Framework;

namespace CalastoneUnitTests.Filter
{
    [TestFixture]
    public class MinimumLengthFilterTests
    {
        [TestCase(3, new[] {"The", "Test", "to", "as", "I"}, 2)]
        [TestCase(4, new[] { "Test", "Test1", "as", "I" }, 2)]
        [TestCase(5, new[] { "Test", "Test1", "as", "I" }, 1)]
        public void FilterInputCorrectly(int minimumLength, string[] input, int expectedLength)
        {
            var sut = new MinimumLengthFilter(minimumLength);

            var result = sut.Execute(input);

            result.Count().Should().Be(expectedLength);
        }
    }
}
