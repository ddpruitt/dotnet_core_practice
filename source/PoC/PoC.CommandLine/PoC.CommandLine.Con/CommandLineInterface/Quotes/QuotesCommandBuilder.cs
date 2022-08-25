using System.CommandLine;

namespace PoC.CommandLine.Con.CommandLineInterface.Quotes;

public static class QuotesCommandBuilder
{
    public static Command Build(Option<FileInfo?> fileOption)
    {
        var quotesCommand = new Command("quotes", "Work with a file that contains quotes.");

        quotesCommand.AddCommand(ReadCommandBuilder.Build(fileOption));
        quotesCommand.AddCommand(DeleteCommandBuilder.Build(fileOption));
        quotesCommand.AddCommand(AddCommandBuilder.Build(fileOption));

        return quotesCommand;
    }
}