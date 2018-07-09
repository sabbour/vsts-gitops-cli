using System;
using System.Collections.Generic;
using System.Text;
using VSTSGitOps.Commands;
using VSTSGitOps.Utils;
using VSTSGitOps.Commands.Implementation.Generic;
using Microsoft.Extensions.CommandLineUtils;

namespace VSTSGitOps.CommandConfiguration
{
    public static class UpdateBuildNumberCommandConfiguration
    {
        public static void Configure(CommandLineApplication command, CommandLineOptions options)
        {
            command.Description = "Updates VSTS build number based on inputs";
            command.HelpOption("--help|-h|-?");

            var buildReasonOption = command.Option("--buildReason", "Reason for the build. If empty will check $BUILD_REASON", CommandOptionType.SingleValue);
            var sourceBranchNameOption = command.Option("--sourceBranchName", "Source branch name. Usually passed from $BUILD_SOURCEBRANCHNAME", CommandOptionType.SingleValue);
            var gitCommitIdOption = command.Option("--gitCommitId", "Git commit ID. Usually passed from $BUILD_SOURCEVERSION", CommandOptionType.SingleValue);
            var buildIdOption = command.Option("--buildId", "Build ID. Usually passed from $BUILD_ID", CommandOptionType.SingleValue);
            var prNumberOption = command.Option("--prNumber", "(Optional) Pull Request number. Usually passed from $SYSTEM_PULLREQUEST_PULLREQUESTNUMBER", CommandOptionType.SingleValue);

      
            command.OnExecute(() =>
            {
                try
                {
                    if(options.Debug)
                        Program.PrintEnv();

                    var buildReason = ArgumentParseUtil.GetArgument<string>(buildReasonOption, "BUILD_REASON");
                    var sourceBranch = ArgumentParseUtil.GetArgument<string>(sourceBranchNameOption, "BUILD_SOURCEBRANCHNAME");
                    var gitCommitId = ArgumentParseUtil.GetArgument<string>(gitCommitIdOption, "BUILD_SOURCEVERSION");
                    var buildId = ArgumentParseUtil.GetArgument<string>(buildIdOption, "BUILD_ID");
                    var prNumber = ArgumentParseUtil.GetArgument<string>(prNumberOption, "SYSTEM_PULLREQUEST_PULLREQUESTNUMBER", required: false);


                    options.Command = new UpdateBuildNumberCommand(
                        buildReason,
                        sourceBranch,
                        gitCommitId,
                        buildId,
                        prNumber,
                        options);
                    return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return 1;
                }
            });

        }
    }
}