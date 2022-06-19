using CalastoneTest.Filter;
using FluentAssertions;
using NUnit.Framework;

namespace CalastoneUnitTests.Filter
{
    [TestFixture]
    public class VowelMiddleFilterTests
    {
        [TestCase(new[] { "clean" }, 0)]
        [TestCase(new[] { "what" }, 0)]
        [TestCase(new[] { "currently" }, 0)]
        [TestCase(new[] { "the" }, 1)]
        [TestCase(new[] { "rather" }, 1)]
        public void FilterInputCorrectly(string[] input, int expectedLength)
        {
            var sut = new VowelMiddleFilter();

            var result = sut.Execute(input);

            result.Count().Should().Be(expectedLength);
        }
    }
}
