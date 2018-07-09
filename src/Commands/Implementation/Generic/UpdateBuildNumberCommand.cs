using System;
using Microsoft.Extensions.CommandLineUtils;

namespace VSTSGitOps.Commands.Implementation.Generic
{

    public class UpdateBuildNumberCommand : ICommand
    {

        private readonly string _buildReason; // $BUILD_REASON
        private readonly string _sourceBranchName; // $BUILD_SOURCEBRANCHNAME
        private readonly string _gitCommitId; // $BUILD_SOURCEVERSION
        private readonly string _buildId; // $BUILD_ID
        private readonly string _prNumber;// $SYSTEM_PULLREQUEST_PULLREQUESTNUMBER
        private readonly CommandLineOptions _options;

        public UpdateBuildNumberCommand(
            string buildReason,
            string sourceBranchName,
            string gitCommitId,
            string buildId,
            string prNumber,
            CommandLineOptions options)
        {
            _buildReason = buildReason;
            _sourceBranchName = sourceBranchName;
            _gitCommitId = gitCommitId;
            _buildId = buildId;
            _prNumber = prNumber;
            _options = options;
        }

        public int Run()
        {
            if(_options.Debug)
                Program.PrintEnv();

            string buildTag;

            // Shorten the commit SHA if it is longer than 7 characters
            var commitId = _gitCommitId;
            if(commitId.Length>7)
                commitId = commitId.Substring(0,7);

            // If it is a Pull Request
            if(_buildReason == "PullRequest" && !string.IsNullOrEmpty(_prNumber)) {
                buildTag = $"{_sourceBranchName}-pr-{_prNumber}-{commitId}-{_buildId}";
            }
            else{
                buildTag = $"{_sourceBranchName}-{commitId}-{_buildId}";
            }

            Console.WriteLine("##vso[build.updatebuildnumber]"+buildTag.ToLower());

            return 0;
        }

    }

}
