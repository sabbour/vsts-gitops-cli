using Microsoft.Extensions.CommandLineUtils;
using VSTSGitOps.Commands;
using VSTSGitOps.CommandConfiguration;

namespace VSTSGitOps
{

    public class CommandLineOptions
    {
        public static CommandLineOptions Parse(string[] args)
        {
            var options = new CommandLineOptions();

            var app = new CommandLineApplication
            {
                Name = "vsts-gitops",
                FullName = "VSTS GitOps command line utility"
            };

            app.HelpOption("-?|-h|--help");



            var enthousiasticSwitch = app.Option("-e|--enthousiastically",
                                          "Whether the app should be enthousiastic.",
                                          CommandOptionType.NoValue);



            RootCommandConfiguration.Configure(app, options);

            var result = app.Execute(args);

            if (result != 0)
            {
                return null;
            }

            options.IsEnthousiastic = enthousiasticSwitch.HasValue();

            return options;
        }

        public ICommand Command { get; set; }
        public bool IsEnthousiastic { get; set; }

    }

}
