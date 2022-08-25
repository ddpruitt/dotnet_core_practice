using System.CommandLine;

namespace PoC.CommandLine.Con.CommandLineInterface.Quotes;

internal static class DeleteCommandBuilder
{
    internal static Command Build(Option<FileInfo?> fileOption)
    {
        var searchTermsOption = new Option<string[]>(
                name: "--search-terms",
                description: "Strings to search for when deleting entries.")
        { IsRequired = true, AllowMultipleArgumentsPerToken = true };

        var deleteCommand = new Command("delete", "Delete lines from the file.");
        deleteCommand.AddOption(searchTermsOption);

        deleteCommand.SetHandler((file, searchTerms) =>
            {
                DeleteFromFile(file!, searchTerms);
            },
            fileOption, searchTermsOption);

        return deleteCommand;
    }

    internal static void DeleteFromFile(FileInfo file, string[] searchTerms)
    {
        Console.WriteLine("Deleting from file");
        File.WriteAllLines(
            file.FullName, File.ReadLines(file.FullName)
                .Where(line => searchTerms.All(s => !line.Contains(s))).ToList());
    }
}