using WordCombinerConsoleApp.Domain.Models;

namespace WordCombinerConsoleApp.Application.Interfaces
{
    public interface IWordCombiner
    {
        IEnumerable<WordCombination> GetValidCombinations(IEnumerable<string> words);
    }
}
