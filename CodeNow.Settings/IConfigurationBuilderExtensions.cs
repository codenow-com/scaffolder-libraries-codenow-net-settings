using Microsoft.Extensions.Configuration;


namespace CodeNow.Settings
{
    // Thanks for inspiration to tgropper and his lib https://github.com/tgropper/env-settings-net
    // I dont want to use these lib because it looks abandoned.

    public static class IConfigurationBuilderExtensions
    {
        /// <summary>
        /// Build the configuration and replace the placeholders inside configuration with the environment variables value
        /// </summary>
        /// <param name="this"></param>
        /// <param name="replaceOnEmpty"></param>
        /// <returns></returns>
        public static IConfiguration ReplaceCodeNowEnvVariables(this IConfigurationBuilder @this, bool replaceOnEmpty = true)
        {
            var configuration = @this.Build();
            configuration.ReplaceCodeNowEnvVariables(replaceOnEmpty);

            return configuration;
        }
    }
}