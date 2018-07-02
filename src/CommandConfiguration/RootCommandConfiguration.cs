using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using VSTSGitOps.Commands;
using Microsoft.Extensions.CommandLineUtils;

namespace VSTSGitOps.CommandConfiguration
{
    public static class RootCommandConfiguration
    {
        public static void Configure(CommandLineApplication app, CommandLineOptions options)
        {
            // Register the Version option
            app.VersionOption("-v|--version",System.Reflection.Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);

            // Register application commands
            app.Command("generate-build-number", c => GenerateBuildNumberCommandConfiguration.Configure(c, options));

            app.OnExecute(() =>
            {
                options.Command = new RootCommand(app);

                return 0;
            });

        }
    }
}