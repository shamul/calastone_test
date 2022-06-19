using CalastoneTest.Filter;

namespace CalastoneTest.Pipeline
{
    public class FilterPipeline
    {
        private readonly IList<IFilter> _filters = new List<IFilter>();

        public void AddFilter(IFilter filter)
        {
            _filters.Add(filter);
        }

        public IEnumerable<string> Process(IEnumerable<string> input)
        {
            foreach (var filter in _filters)
                input = filter.Execute(input);

            return input;
        }
    }
}
