# Word Combiner Console App

This is a console application that combines words from a text file to form valid word combinations. It uses a service-oriented architecture and dependency injection for extensibility and testability.

## Prerequisites

- .NET 8 SDK
- Visual Studio or any other code editor

## Getting Started

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Build the solution to restore the NuGet packages.
4. Set the `WordCombinerSettings` in the `appsettings.json` file according to your requirements.
5. Run the application.

## Configuration

The application uses the `appsettings.json` file to configure the `WordCombinerSettings`. You can modify the following settings:

- `WordCombinerSettings:CombinedWordLength`: The minimum length of a word to be considered for combination.
- `WordCombinerSettings:MaxCombinationParts`: The maximum amount of word that can be part of a combination.

## Usage

The application takes the first command-line argument as the file path. If no file path is provided, it defaults to "input.txt". The application then combines the words from the file and outputs the valid word combinations.

## Error Handling

The application handles the following exceptions:

- `FileNotFoundException`: If the specified or default file is not found.
- `NotSupportedException`: If the specified file extension is not supported.
- Any other unexpected exception.

## Open questions

- Should we allow word combinations that are shorter than the configured length?
- How should duplicate entries be treated?
- Does the order of words matter when forming a combination?
- Should we consider case sensitivity and special characters?

## Future improvements

- Implement Localization support. The messages are currently hardcoded in English and should be moved to a resource file.
- Enhance logging and tracing capabilities.
- Perform tests with a larger dataset.
- Enable support for additional file types based on user preferences or the file extension provided.
- Consider that data may also originate from a source other than a file.
- Support concurrent processing of multiple files.
- Learning opportunity: Utilize SpecFlow to improve the readability and coverage of BDD-style tests.
