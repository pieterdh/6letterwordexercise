using WordCombinerConsoleApp.Application.Interfaces;
using WordCombinerConsoleApp.Domain.Models;

namespace WordCombinerConsoleApp.Application.Services
{
    /// <summary>
    /// Service class for finding valid word combinations from a given file.
    /// </summary>
    public class WordService
    {
        private readonly IWordCombiner _combiner;
        private readonly IFileWordProvider _fileWordProvider;

        public WordService(IWordCombiner combiner, IFileWordProvider fileWordProvider)
        {
            _combiner = combiner;
            _fileWordProvider = fileWordProvider;
        }

        /// <summary>
        /// Finds valid word combinations from a file.
        /// </summary>
        /// <param name="filePath">The path to the file containing the words.</param>
        /// <returns>An enumerable collection of valid word combinations.</returns>
        public IEnumerable<WordCombination> FindValidWordCombinations(string filePath)
        {
            IEnumerable<string> words = _fileWordProvider.GetWords(filePath);
            return _combiner.GetValidCombinations(words);
        }
    }
}
