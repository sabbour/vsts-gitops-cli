using System;
using Microsoft.Extensions.CommandLineUtils;

namespace VSTSGitOps
{
    class Program
    {
        static int Main(string[] args)
        {
            var options = CommandLineOptions.Parse(args);
            if (options?.Command == null)
            {
                // RootCommand will have printed help
                return 1;
            }
            return options.Command.Run();
        }
    }
}
