using System;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;

namespace VSTSGitOps.Commands.Interfaces
{

    public interface IUpdatePreviewPRCommand : ICommand
    {
        Task<int> UpdatePreviewPR(string buildNumber,string prNumber);
    }

}
