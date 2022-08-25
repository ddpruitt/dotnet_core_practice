
using System.CommandLine;
using System.CommandLine.Hosting;
using System.CommandLine.NamingConventionBinder;
using Microsoft.Extensions.Hosting;
using PoC.CommandLine.Con.CommandLineInterface;

namespace PoC.CommandLine.Con
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            var rootCommand = RootCommandBuilder.Build();
            return await rootCommand.InvokeAsync(args);
        }

        
    }
}