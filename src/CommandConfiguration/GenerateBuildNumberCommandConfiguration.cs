using System;
using System.Collections.Generic;
using System.Text;
using VSTSGitOps.Commands;
using Microsoft.Extensions.CommandLineUtils;

namespace VSTSGitOps.CommandConfiguration
{
    public static class GenerateBuildNumberCommandConfiguration
    {
        public static void Configure(CommandLineApplication command, CommandLineOptions options)
        {
            command.Description = "Generates a build number based on inputs";
            command.HelpOption("--help|-h|-?");

            var buildReasonOption = command.Option("--buildReason", "Reason for the build. Usually passed from $BUILD_REASON", CommandOptionType.SingleValue);
            var sourceBranchNameOption = command.Option("--sourceBranchName", "Source branch name. Usually passed from $BUILD_SOURCEBRANCHNAME", CommandOptionType.SingleValue);
            var gitCommitId = command.Option("--gitCommitId", "Git commit ID. Usually passed from $BUILD_SOURCEVERSION", CommandOptionType.SingleValue);
            var buildIdOption = command.Option("--buildId", "Build ID. Usually passed from $BUILD_ID", CommandOptionType.SingleValue);
            var prNumberOption = command.Option("--prNumber", "(Optional) Source branch name. Usually passed from $SYSTEM_PULLREQUEST_PULLREQUESTNUMBER", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                if (
                    buildReasonOption.HasValue()
                    && sourceBranchNameOption.HasValue()
                    && gitCommitId.HasValue()
                    && buildIdOption.HasValue())
                {
                    options.Command = new GenerateBuildNumberCommand(
                        buildReasonOption.Value(),
                        sourceBranchNameOption.Value(),
                        gitCommitId.Value(),
                        buildIdOption.Value(),
                        prNumberOption.Value(),
                        options);

                    return 0;
                }
                else
                {
                    Console.WriteLine("Error: Please supply all required parameters.");
                    return 1;
                }
            });

        }
    }
}