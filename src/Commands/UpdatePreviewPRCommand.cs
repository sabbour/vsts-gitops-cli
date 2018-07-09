using System;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.TeamFoundation.SourceControl.WebApi;

using VSTSGitOps.Commands.Interfaces;

namespace VSTSGitOps.Commands
{

    public class UpdatePreviewPRCommand : ICommand
    {
        private readonly Uri _accountUri; // Account URL, for example: https://fabrikam.visualstudio.com
        private readonly string _personalAccessToken; // https://docs.microsoft.com/en-us/vsts/organizations/accounts/use-personal-access-tokens-to-authenticate?view=vsts
        private readonly string _repoName;
        private readonly string _projectName;

        private readonly string _buildNumber;
        private readonly string _prNumber;

        private readonly CommandLineOptions _options;

        public UpdatePreviewPRCommand(string buildNumber, string prNumber, string repoName, Uri accountUri, string projectName, string personalAccessToken, CommandLineOptions options)
        {
            _buildNumber = buildNumber;
            _prNumber = prNumber;
            _accountUri = accountUri;
            _personalAccessToken = personalAccessToken;
            _projectName = projectName;
            _repoName = repoName;
            _options = options;
        }

        public async Task<int> UpdatePreviewPR(string buildNumber,string prNumber)
        {
            // Create a connection to the account
            var connection = new VssConnection(_accountUri, new VssBasicCredential("pat", _personalAccessToken));
            
            // Get the Git client
            var gitClient = connection.GetClient<GitHttpClient>();

            // Get the Git repo
            var gitRepo = await gitClient.GetRepositoryAsync(_projectName, _repoName);

            Console.WriteLine($"repoid: {gitRepo.Id}");

            var pullRequests = await gitClient.GetPullRequestsAsync(gitRepo.Id,new GitPullRequestSearchCriteria { });
            foreach (var pr in pullRequests)
            {
                Console.WriteLine($"pr: {pr.PullRequestId} title: {pr.Title}");
            }

            if(pullRequests.Count == 0) {
                Console.WriteLine("No pull requests found");
                return 1;
            }
            
            return 0;
        }
        
        public int Run()
        {
            return UpdatePreviewPR(_buildNumber,_prNumber).Result;
        }

    }

}
