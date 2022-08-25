using System.CommandLine;
using PoC.CommandLine.Con.CommandLineInterface.Quotes;

namespace PoC.CommandLine.Con.CommandLineInterface;

public static class RootCommandBuilder
{
    public static RootCommand Build()
    {
        var fileOption = FileInfoOptionBuilder.Build();

        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        rootCommand.AddGlobalOption(fileOption);

        rootCommand.AddCommand(QuotesCommandBuilder.Build(fileOption));

        return rootCommand;
    }
}