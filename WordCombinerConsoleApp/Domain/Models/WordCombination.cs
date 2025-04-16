namespace WordCombinerConsoleApp.Domain.Models
{
    /// <summary>
    /// Represents a word combination with its parts and result.
    /// </summary>
    public record WordCombination
    {
        /// <summary>
        /// Gets the parts of the word combination.
        /// </summary>
        public IReadOnlyList<string> Parts { get; }

        /// <summary>
        /// Gets the result of the word combination.
        /// </summary>
        public string Result { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordCombination"/> class.
        /// </summary>
        /// <param name="parts">The parts of the word combination.</param>
        /// <param name="result">The result of the word combination.</param>
        public WordCombination(IEnumerable<string> parts, string result)
        {
            Parts = parts.ToList().AsReadOnly();
            Result = result;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{string.Join("+", Parts)}={Result}";
        }
    }
}
