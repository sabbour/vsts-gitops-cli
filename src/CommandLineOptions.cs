using System;
using Microsoft.Extensions.CommandLineUtils;
using VSTSGitOps.Commands;
using VSTSGitOps.CommandConfiguration;

namespace VSTSGitOps
{

    public class CommandLineOptions
    {
        public bool Debug { get; set; }
        public static CommandLineOptions Parse(string[] args)
        {
            var options = new CommandLineOptions();
            var app = new CommandLineApplication
            {
                Name = "vsts-gitops-cli",
                FullName = "VSTS GitOps command line utility"
            };

            // Register main app help
            app.HelpOption("-?|-h|--help");

            var debugSwitch = app.Option("-d|--debug",
                                          "Print environment variables",
                                          CommandOptionType.NoValue);

            RootCommandConfiguration.Configure(app, options);

            var result = app.Execute(args);

            if (result != 0)
            {
                return null;
            }

            options.Debug = true;//debugSwitch.HasValue();

            return options;
        }

        public ICommand Command { get; set; }

    }

}
