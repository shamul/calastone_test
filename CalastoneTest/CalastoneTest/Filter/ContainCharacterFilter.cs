namespace CalastoneTest.Filter
{
    public class ContainCharacterFilter : IFilter
    {
        public ContainCharacterFilter(char chracterToFilter)
        {
            ChracterToFilter = chracterToFilter;
        }

        public char ChracterToFilter { get; }

        public IEnumerable<string> Execute(IEnumerable<string> input)
        {
            foreach (string inputItem in input)
                if (!inputItem.Contains(ChracterToFilter, StringComparison.CurrentCultureIgnoreCase))
                    yield return inputItem;
        }
    }
}
