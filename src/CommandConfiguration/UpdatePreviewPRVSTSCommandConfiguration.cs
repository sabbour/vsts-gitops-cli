using System;
using System.Collections.Generic;
using System.Text;
using VSTSGitOps.Commands;
using VSTSGitOps.Commands.Implementation.Generic;
using VSTSGitOps.Commands.Implementation.VSTS;
using Microsoft.Extensions.CommandLineUtils;
using VSTSGitOps.Utils;

namespace VSTSGitOps.CommandConfiguration
{
    public static class UpdatePreviewPRVSTSCommandConfiguration
    {
        public static void Configure(CommandLineApplication command, CommandLineOptions options)
        {
            command.Description = "Updates VSTS Git Pull Request with preview environment details";
            command.HelpOption("--help|-h|-?");

            var accountUriOption = command.Option("--accountUri", "Account URL, for example: https://fabrikam.visualstudio.com. Usually passed from $SYSTEM_TEAMFOUNDATIONCOLLECTIONURI", CommandOptionType.SingleValue);
            var personalAccessTokenOption = command.Option("--personalAccessToken", "Personal Access Token for VSTS. See: https://docs.microsoft.com/en-us/vsts/organizations/accounts/use-personal-access-tokens-to-authenticate?view=vsts", CommandOptionType.SingleValue);
            var projectNameOption = command.Option("--projectName", "VSTS Project name. Usually passed from $SYSTEM_TEAMPROJECT", CommandOptionType.SingleValue);
            var repoNameOption = command.Option("--repoName", "Git repository name. Usually passed from $BUILD_REPOSITORY_NAME", CommandOptionType.SingleValue);
            var buildNumberOption = command.Option("--buildNumber", "Build number. Usually passed from $BUILD_NUMBER", CommandOptionType.SingleValue);
            var prNumberOption = command.Option("--prNumber", "Pull request number. Usually passed from $SYSTEM_PULLREQUEST_PULLREQUESTNUMBER", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                try
                {
                    if(options.Debug)
                        Program.PrintEnv();

                    Uri accountUri = ArgumentParseUtil.GetArgument<Uri>(accountUriOption, "SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");
                    var personalAccessToken = ArgumentParseUtil.GetArgument<string>(personalAccessTokenOption, "ENV_PERSONALACCESSTOKEN");
                    var projectName = ArgumentParseUtil.GetArgument<string>(projectNameOption, "SYSTEM_TEAMPROJECT");
                    var repoName = ArgumentParseUtil.GetArgument<string>(repoNameOption, "BUILD_REPOSITORY_NAME");
                    var buildNumber = ArgumentParseUtil.GetArgument<string>(buildNumberOption, "BUILD_NUMBER");
                    var prNumber = ArgumentParseUtil.GetArgument<string>(prNumberOption, "SYSTEM_PULLREQUEST_PULLREQUESTNUMBER");

                    options.Command = new UpdatePreviewPRVSTSCommand(
                        buildNumber,
                        prNumber,
                        repoName,
                        accountUri,
                        projectName,
                        personalAccessToken,
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