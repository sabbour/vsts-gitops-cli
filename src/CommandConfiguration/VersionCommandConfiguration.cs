using System;
using System.Collections.Generic;
using System.Text;
using VSTSGitOps.Commands;
using Microsoft.Extensions.CommandLineUtils;

namespace VSTSGitOps.CommandConfiguration
{
    public static class VersionCommandConfiguration
    {
        public static void Configure(CommandLineApplication command, CommandLineOptions options)
        {
            command.Description = "Display current version of the CLI.";
            command.HelpOption("--help|-h|-?");
            
            command.OnExecute(() =>
            {
                options.Command = new VersionCommand(command);
                return 0;
            });

        }
    }
}