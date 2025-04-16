using Microsoft.Extensions.Options;
using NSubstitute;
using Shouldly;
using WordCombinerConsoleApp.Application.Interfaces;
using WordCombinerConsoleApp.Application.Services;
using WordCombinerConsoleApp.Domain.Models;

namespace WordCombinerConsoleApp.Tests
{
    public class WordServiceIntegrationTests
    {
        [Fact]
        public void Should_return_all_valid_word_combinations()
        {
            var words = new List<string> { "foo", "bar", "foobar", "foot", "ball", "football" };
            var combiner = new WordCombiner(Options.Create(WordCombinerSettings.Default));
            var provider = Substitute.For<IFileWordProvider>();
            provider.GetWords(Arg.Any<string>()).Returns(words);
            var service = new WordService(combiner, provider);

            IEnumerable<WordCombination> result = service.FindValidWordCombinations("fakepath.txt").ToList();

            result.ShouldSatisfyAllConditions(
                () => result.Count().ShouldBe(1),
                () => result.ShouldContain(x => x.ToString().Equals("foo+bar=foobar")));
        }

        [Fact]
        public void Ensure_that_it_does_not_contain_any_words_longer_then_the_maxWord_Length()
        {
            var words = new List<string> { "foo", "bar", "foobar", "foot", "ball", "football" };
            var combiner = new WordCombiner(Options.Create(WordCombinerSettings.Default));
            var provider = Substitute.For<IFileWordProvider>();
            provider.GetWords(Arg.Any<string>()).Returns(words);
            var service = new WordService(combiner, provider);

            IEnumerable<WordCombination> result = service.FindValidWordCombinations("fakepath.txt").ToList();

            result.ShouldSatisfyAllConditions(
                () => result.Count().ShouldBe(1),
                () => result.ShouldNotContain(x => x.Result.Equals("football")));
        }
    }
}
