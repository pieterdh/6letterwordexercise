using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WordCombinerConsoleApp.Application.Interfaces;
using WordCombinerConsoleApp.Application.Services;
using WordCombinerConsoleApp.Domain.Models;
using WordCombinerConsoleApp.Infrastructure;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var services = new ServiceCollection();

// Register configuration section as options
services.Configure<WordCombinerSettings>(configuration.GetSection("WordCombinerSettings"));

// Registering dependencies for IoC
services.AddSingleton<IFileWordProvider, TxtFileWordProvider>();
services.AddSingleton<IWordCombiner, WordCombiner>();
services.AddSingleton<WordService>();

using (var provider = services.BuildServiceProvider())
{
    try
    {
        // Command-line arguments: file path
        string inputFilePath = args.FirstOrDefault() ?? "input.txt";   // Default to "input.txt" if no file path is provided

        var wordService = provider.GetRequiredService<WordService>();
        IEnumerable<WordCombination> results = wordService.FindValidWordCombinations(inputFilePath);

        foreach (WordCombination result in results)
        {
            Console.WriteLine(result);
        }
    }
    catch (Exception ex) when (ex is FileNotFoundException || ex is NotSupportedException)
    {
        Console.WriteLine($"Error: {ex.Message}.");
    }
    catch (Exception)
    {
        Console.WriteLine("Error: Sorry, something unexpected went wrong.");
    }
}