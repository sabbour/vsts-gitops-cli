using System;
using Microsoft.Extensions.CommandLineUtils;

namespace VSTSGitOps.Commands
{

    public class GenerateBuildNumberCommand : ICommand
    {

        private readonly string _buildReason; // $BUILD_REASON
        private readonly string _sourceBranchName; // $BUILD_SOURCEBRANCHNAME
        private readonly string _gitCommitId; // $BUILD_SOURCEVERSION
        private readonly string _buildId; // $BUILD_BUILDID
        private readonly string _prNumber;// $SYSTEM_PULLREQUEST_PULLREQUESTID
        private readonly CommandLineOptions _options;

        public GenerateBuildNumberCommand(
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

            Console.WriteLine(buildTag.ToLower());

            return 0;
        }

    }

}
