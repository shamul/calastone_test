namespace CalastoneTest.Filter
{
    public class MinimumLengthFilter : IFilter
    {
        public MinimumLengthFilter(int minimumLength)
        {
            MinimumLength = minimumLength;
        }

        public int MinimumLength { get; }

        public IEnumerable<string> Execute(IEnumerable<string> input)
        {
            foreach (var inputItem in input)
                if (inputItem.Length >= MinimumLength)
                    yield return inputItem;
        }
    }
}
