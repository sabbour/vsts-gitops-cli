using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.PlatformAbstractions;

namespace VSTSGitOps.Commands
{
    public class VersionCommand : ICommand
    {
        private readonly CommandLineApplication _command;
        
        public VersionCommand(CommandLineApplication command)
        {
            _command = command;
        }

        public int Run()
        {
            Console.WriteLine($"version: {PlatformServices.Default.Application.ApplicationVersion}");
            return 0;
        }
    }
}
