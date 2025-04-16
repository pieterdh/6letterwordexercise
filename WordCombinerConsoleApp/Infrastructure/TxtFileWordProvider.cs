using WordCombinerConsoleApp.Application.Interfaces;

namespace WordCombinerConsoleApp.Infrastructure
{
    /// <summary>
    /// This class will read all given words from a given txt file.
    /// </summary>
    public class TxtFileWordProvider : IFileWordProvider
    {
        /// <summary>
        /// Retrieves a collection of words from the specified text file.
        /// </summary>
        /// <param name="path">The path to the text file.</param>
        /// <returns>A collection of words.</returns>
        /// <exception cref="FileNotFoundException">Thrown when the input file is not found.</exception>
        /// <exception cref="NotSupportedException">Thrown when the file fileExtension is not '.txt'.</exception>
        public IEnumerable<string> GetWords(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Input file not found.", path);

            string fileExtension = Path.GetExtension(path);
            if (fileExtension != ".txt")
                throw new NotSupportedException($"Unsupported file fileExtension '{fileExtension}'. Only '.txt' files are supported.");

            return File.ReadLines(path)
                       .Select(line => line.Trim())
                       .Where(line => !string.IsNullOrWhiteSpace(line));
        }
    }
}
