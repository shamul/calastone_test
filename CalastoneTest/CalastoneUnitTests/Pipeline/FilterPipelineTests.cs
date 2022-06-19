using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using CalastoneTest.Filter;
using CalastoneTest.Pipeline;
using Moq;
using NUnit.Framework;

namespace CalastoneUnitTests.Pipeline
{
    [TestFixture]
    public class FilterPipelineTests
    {
        private readonly IFixture _fixture = new Fixture();

        [SetUp]
        public void Setup()
        {
            _fixture.Customize(new AutoMoqCustomization());
        }

        [Test]
        [AutoData]
        public void ProcessFiltersInPipeline(IList<string> data, IList<Mock<IFilter>> filters)
        {
            var pipleLine = new FilterPipeline();

            foreach (var filter in filters)
                pipleLine.AddFilter(filter.Object);


            pipleLine.Process(data);

            foreach (var filter in filters)
                filter.Verify(x => x.Execute(It.IsAny<IEnumerable<string>>()), Times.Once);
        }
    }
}
