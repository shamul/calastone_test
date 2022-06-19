using System.IO.Abstractions;
using System.Text.RegularExpressions;

namespace CalastoneTest.Repo
{
    public class FileDataRepo : IDataRepo
    {
        private readonly IFileSystem _fileSystem;

        public FileDataRepo(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public string Path { get; set; }

        public IEnumerable<string> GetData()
        {
            if(!_fileSystem.File.Exists(Path))
                throw new FileNotFoundException(Path);
            var rx = new Regex(@"\w+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            using var streamReader = _fileSystem.File.OpenText(Path);
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                var matches = rx.Matches(line);
                foreach (var match in matches)
                    yield return match.ToString();
            }
        }
    }
}
