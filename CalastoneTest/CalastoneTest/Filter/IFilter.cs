namespace CalastoneTest.Filter
{
    public interface IFilter
    {
        IEnumerable<string> Execute(IEnumerable<string> input);
    }
}
