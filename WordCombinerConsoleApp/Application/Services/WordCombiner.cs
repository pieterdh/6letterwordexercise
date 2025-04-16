using Microsoft.Extensions.Options;
using WordCombinerConsoleApp.Application.Interfaces;
using WordCombinerConsoleApp.Domain.Models;

namespace WordCombinerConsoleApp.Application.Services
{

    /// <summary>
    /// Service class that combines words to form valid word combinations.
    /// </summary>
    public class WordCombiner : IWordCombiner
    {
        private readonly WordCombinerSettings _settings;

        public WordCombiner(IOptions<WordCombinerSettings> settings)
        {
            _settings = settings?.Value ?? WordCombinerSettings.Default;
        }

        /// <summary>
        /// Gets the valid combinations of words based on the provided rules.
        /// </summary>
        /// <param name="words">The collection of words to combine.</param>
        /// <returns>The valid combinations of words.</returns>
        public IEnumerable<WordCombination> GetValidCombinations(IEnumerable<string> words)
        {
            List<string> possibleWordsToCombine = words.Where(w => w.Length < _settings.CombinedWordLength).ToList();
            List<string> candidateWords = words.Where(w => w.Length == _settings.CombinedWordLength).ToList();

            foreach (var combination in GenerateCombinations(possibleWordsToCombine))
            {
                string combinedWord = string.Concat(combination);
                if (combinedWord.Length == _settings.CombinedWordLength && candidateWords.Contains(combinedWord))
                {
                    yield return new WordCombination(combination, combinedWord);
                }
            }
        }

        private IEnumerable<List<string>> GenerateCombinations(List<string> words)
        {
            return Generate(words, new List<string>(), 0);
        }

        private IEnumerable<List<string>> Generate(List<string> words, List<string> currentCombinations, int currentLength)
        {
            foreach (var word in words)
            {
                if (currentCombinations.Contains(word)) continue;

                int newLength = currentLength + word.Length;
                if (newLength > _settings.CombinedWordLength || currentCombinations.Count >= _settings.MaxCombinationParts) continue;

                var nextCombination = new List<string>(currentCombinations) { word };

                if (newLength == _settings.CombinedWordLength)
                {
                    yield return nextCombination;
                }
                else
                {
                    foreach (var combo in Generate(words, nextCombination, newLength))
                        yield return combo;
                }
            }
        }
    }
}