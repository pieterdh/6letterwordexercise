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

- Should we also support word combinations that have a smaller length then what is configured?
- How should we handle duplicates?
- Is the sequence of the words important to make a combination?
- Do we need to take into account case sensitivity, special characters?

## Future improvements

- Add support for Localization. Messages are hardcoded in English and should be moved to a resource file.
- Add additional logging/tracing.
- Test against a larger dataset.
- Allow the option to easily support more file types based in user preference or provided file extension.
- Take into account that data also can come in from another datasource then a file.
- Concurrent processing of multiple files.
- Learning opportunity: Use SpecFlow to optimize BDD-style test readability and coverage