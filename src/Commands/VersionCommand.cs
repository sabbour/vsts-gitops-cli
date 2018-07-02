using System;
using System.Reflection;
using Microsoft.Extensions.CommandLineUtils;

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

            var assemblyVersion = System.Reflection.Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            var assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;

            Console.WriteLine($"{assemblyName}-{assemblyVersion}");
            return 0;
        }
    }
}
