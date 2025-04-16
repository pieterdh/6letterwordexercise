using WordCombinerConsoleApp.Infrastructure;

namespace WordCombinerTests
{
    public class TxtFileWordProviderTests
    {
        [Fact]
        public void Should_return_words_if_a_valid_filePath_is_provided()
        {
            var wordProvider = new TxtFileWordProvider();
            var filePath = "TestFiles/supportedFileExtension.txt";
            var expectedWords = new List<string> { "foobar", "fo", "o", "bar", "football" };

            var actualWords = wordProvider.GetWords(filePath);

            Assert.Equal(expectedWords, actualWords);
        }

        [Fact]
        public void Ensure_it_throws_FileNotFoundException_when_invalid_filePath_is_provided()
        {
            var wordProvider = new TxtFileWordProvider();
            var filePath = "path/to/invalid/file.txt";

            Assert.Throws<FileNotFoundException>(() => wordProvider.GetWords(filePath));
        }

        [Fact]
        public void Ensure_it_throws_NotSupportedException_when_invalid_file_extension_is_provided()
        {
            string path = "TestFiles/unsupportedFileExtension.xml";
            var wordProvider = new TxtFileWordProvider();

            Assert.Throws<NotSupportedException>(() => wordProvider.GetWords(path));
        }
    }
}
