namespace WordCombinerConsoleApp.Application.Interfaces
{
    public interface IFileWordProvider
    {
        IEnumerable<string> GetWords(string path);
    }
}
