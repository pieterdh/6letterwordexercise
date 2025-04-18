using Microsoft.Extensions.Options;
using Shouldly;
using WordCombinerConsoleApp.Application.Services;
using WordCombinerConsoleApp.Domain.Models;

namespace WordCombinerConsoleApp.Tests
{
    [Trait("Category", "Unit")]
    public class WordCombinerTests
    {
        [Fact]
        public void Should_return_combinations_that_matches_the_default_wordCombinerSettings()
        {
            var words = new List<string> { "foo", "bar", "foobar" };
            var combiner = new WordCombiner(Options.Create(WordCombinerSettings.Default));

            List<WordCombination> result = combiner.GetValidCombinations(words).ToList();

            result.ShouldSatisfyAllConditions(
                () => result.Any().ShouldBeTrue(),
                () => result.First().Parts.Count().ShouldBe(2),
                () => result.First().Result.ShouldBe("foobar"),
                () => result.First().ToString().ShouldBe("foo+bar=foobar"));
        }

        [Fact]
        public void Should_return_combinations_that_matches_the_configured_combinedWordLength_settings()
        {
            var words = new List<string> { "fo", "bars", "od", "foodbars", "foot", "ball", "football" };
            var combinerSettings = new WordCombinerSettings { CombinedWordLength = 8, MaxCombinationParts = 3 };
            var combiner = new WordCombiner(Options.Create(combinerSettings));

            var result = combiner.GetValidCombinations(words).ToList();

            result.ShouldSatisfyAllConditions(
                () => result.Count().ShouldBe(2),
                () => result[0].Parts.Count().ShouldBe(3),
                () => result[0].Result.ShouldBe("foodbars"),
                () => result[0].ToString().ShouldBe("fo+od+bars=foodbars"),
                () => result[1].ToString().ShouldBe("foot+ball=football"));
        }

        [Fact]
        public void Should_return_empty_list_when_no_words_are_provided()
        {
            var words = new List<string>();
            var combiner = new WordCombiner(Options.Create(WordCombinerSettings.Default));

            var result = combiner.GetValidCombinations(words).ToList();

            result.ShouldBeEmpty();
        }

        [Fact]
        public void Should_return_empty_list_when_no_combination_matches_based_on_the_configured_combinedWordLength_settings()
        {
            var words = new List<string> { "foo", "bar", "foobar" };
            var combinerSettings = new WordCombinerSettings { CombinedWordLength = 10, MaxCombinationParts = 3 };
            var combiner = new WordCombiner(Options.Create(combinerSettings));

            var result = combiner.GetValidCombinations(words).ToList();

            result.ShouldBeEmpty();
        }

        [Fact]
        public void Should_return_empty_list_when_no_combination_could_be_made_with_the_configured_maxCombinationParts_settings()
        {
            var words = new List<string> { "foo", "bar", "foobar" };
            var combinerSettings = new WordCombinerSettings { CombinedWordLength = 6, MaxCombinationParts = 1 };
            var combiner = new WordCombiner(Options.Create(combinerSettings));

            var result = combiner.GetValidCombinations(words).ToList();

            result.ShouldBeEmpty();
        }

        [Fact]
        public void Should_take_case_sensitivity_into_account_when_looking_for_word_combinations()
        {
            var words = new List<string> { "foo", "Bar", "FOOBAR" };
            var combiner = new WordCombiner(Options.Create(WordCombinerSettings.Default));

            var result = combiner.GetValidCombinations(words).ToList();

            result.ShouldBeEmpty();
        }
    }
}
