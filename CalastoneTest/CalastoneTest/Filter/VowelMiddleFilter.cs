namespace CalastoneTest.Filter
{
    public class VowelMiddleFilter : IFilter
    {
        private readonly HashSet<char> _vowels = new() { 'a', 'e', 'i', 'o', 'u' };

        public IEnumerable<string> Execute(IEnumerable<string> input)
        {
            foreach (var inputWord in input)
            {
                var even = inputWord.Length % 2 == 0;
                var middleIndex = inputWord.Length / 2;
                var middleChar = inputWord[middleIndex];
                if (even)
                {
                    if (!_vowels.Contains(middleChar) && !_vowels.Contains(inputWord[middleIndex - 1]))
                        yield return inputWord;
                }
                else if (!_vowels.Contains(middleChar))
                    yield return inputWord;
            }
        }
    }
}
