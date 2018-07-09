using System;
using Microsoft.Extensions.CommandLineUtils;

namespace VSTSGitOps.Utils
{
    public class ArgumentParseUtil
    {
        public static T GetArgument<T>(CommandOption option, string envVar, bool required = true) where T : class
        {
            T result = default(T);
            bool empty = true;

            // Command line arguments override environment variables
            try
            {
                if (option.HasValue())
                {
                    result = (T)ConvertTo<T>(option.Value());
                    empty = false;
                }
                else if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(envVar)))
                {
                    result = (T)ConvertTo<T>(Environment.GetEnvironmentVariable(envVar));
                    empty = false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException(option.LongName, $"Required parameters could not be cast to {typeof(T)}");
            }

            // Now check if result is still empty
            if (empty == true && required == true)
                throw new ArgumentNullException(option.LongName, $"Required parameter empty. Please pass or set as an environment variable {envVar}.");

            return result;
        }

        public static object ConvertTo<T>(string obj) where T : class
        {
            // Handle special cases first
            if (typeof(T) == typeof(Uri))
                return new Uri(obj);
            if (typeof(T) == typeof(Guid))
                return new Guid(obj);

            // Otherwise
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}