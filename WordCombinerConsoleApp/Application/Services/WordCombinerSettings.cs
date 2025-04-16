namespace WordCombinerConsoleApp.Application.Services
{
    /// <summary>
    /// Represents the settings for the WordCombiner service.
    /// </summary>
    public class WordCombinerSettings
    {
        /// <summary>
        /// Gets or sets the length of the combined word.
        /// </summary>
        public int CombinedWordLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of parts to combine.
        /// </summary>
        public int MaxCombinationParts { get; set; }

        /// <summary>
        /// Gets the default WordCombiner settings.
        /// </summary>
        public static WordCombinerSettings Default
        {
            get
            {
                return new WordCombinerSettings { CombinedWordLength = 6, MaxCombinationParts = 2 };
            }
        }
    }
}