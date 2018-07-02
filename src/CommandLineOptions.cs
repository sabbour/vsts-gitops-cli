using System;
using System.Reflection;
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
            app.VersionOption("-v",System.Reflection.Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);

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
