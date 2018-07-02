using System;
using Microsoft.Extensions.CommandLineUtils;
using VSTSGitOps.Commands;
using VSTSGitOps.CommandConfiguration;

namespace VSTSGitOps
{

    public class CommandLineOptions
    {
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
            
            RootCommandConfiguration.Configure(app, options);

            var result = app.Execute(args);

            if (result != 0)
            {
                return null;
            }

            return options;
        }

        public ICommand Command { get; set; }

    }

}
