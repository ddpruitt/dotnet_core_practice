using System.CommandLine;

namespace PoC.CommandLine.Con.CommandLineInterface.Quotes;

internal class AddCommandBuilder
{
    internal static Command Build(Option<FileInfo?> fileOption)
    {
        var quoteArgument = new Argument<string>(
            name: "quote",
            description: "Text of quote.");

        var bylineArgument = new Argument<string>(
            name: "byline",
            description: "Byline of quote.");

        var addCommand = new Command("add", "Add an entry to the file.");
        addCommand.AddArgument(quoteArgument);
        addCommand.AddArgument(bylineArgument);
        addCommand.AddAlias("insert");

        addCommand.SetHandler((file, quote, byline) =>
            {
                AddToFile(file!, quote, byline);
            },
            fileOption, quoteArgument, bylineArgument);

        return addCommand;
    }

    internal static void AddToFile(FileInfo file, string quote, string byline)
    {
        Console.WriteLine("Adding to file");
        using StreamWriter? writer = file.AppendText();
        writer.WriteLine($"{Environment.NewLine}{Environment.NewLine}{quote}");
        writer.WriteLine($"{Environment.NewLine}-{byline}");
        writer.Flush();
    }
}