using AutoFixture.NUnit3;
using CalastoneTest.Repo;
using FluentAssertions;
using NUnit.Framework;
using System.IO.Abstractions.TestingHelpers;

namespace CalastoneUnitTests.Repo
{
    [TestFixture]
    public class FileDataRepoTests
    {
        [Test]
        [AutoData]
        public void GetDataOutputsWords(string fileName)
        {
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData> { { @$"c:\{fileName}.txt", new MockFileData("Testing is meh.") } });

            var sut = new FileDataRepo(fileSystem)
            {
                Path = $"{fileName}.txt"
            };

            var data = sut.GetData().ToList();
            data.Count.Should().Be(3);
            data[0].Should().Be("Testing");
            data[1].Should().Be("is");
            data[2].Should().Be("meh");
        }
    }
}
