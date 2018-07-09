using System;
using Microsoft.Extensions.CommandLineUtils;

namespace VSTSGitOps
{
    class Program
    {
        static int Main(string[] args)
        {
            PrintEnv();
            
            var options = CommandLineOptions.Parse(args);
            if (options?.Command == null)
            {
                // RootCommand will have printed help
                return 1;
            }
            return options.Command.Run();
        }

        public static void PrintEnv() {
            var envVariables = System.Environment.GetEnvironmentVariables();
            Console.WriteLine("*** BEGIN ENVIRONMENT VARIABLES ***");
            foreach (System.Collections.DictionaryEntry env in envVariables)
            {
                Console.WriteLine($"{env.Key}: {env.Value}");
            }
            Console.WriteLine("*** END ENVIRONMENT VARIABLES ***\n");
        }
    }
}
