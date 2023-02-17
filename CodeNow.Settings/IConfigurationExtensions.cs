using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;


namespace CodeNow.Settings
{
    // Thanks for inspiration to tgropper and his lib https://github.com/tgropper/env-settings-net
    // I dont want to use these lib because it looks abandoned.
    
    public static class IConfigurationExtensions
    {
        /// <summary>
        /// Methods will replace placeholders in AppSettings.json with environment variables values.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="replaceOnEmpty"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IConfiguration ReplaceCodeNowEnvVariables(this IConfiguration @this, bool replaceOnEmpty = true)
        {
            if (@this == null) throw new System.ArgumentNullException(nameof(@this));

            var valueToReplaceRegex = new Regex(@"(?<=\$\{)([a-zA-Z0-9_]+)(?=\})");

            @this.AsEnumerable()
                .Where(kv => !string.IsNullOrEmpty(kv.Value) && valueToReplaceRegex.IsMatch(kv.Value))
                .ToList()
                .ForEach(kv => valueToReplaceRegex.Matches(kv.Value).Cast<Match>()
                    .Select(x => x.Value).ToList()
                    .ForEach(match => @this[kv.Key] = @this[match] != null
                        ? new Regex($"\\${{{match}}}").Replace(@this[kv.Key], @this[match])
                        : replaceOnEmpty ? new Regex($"\\${{{match}}}").Replace(@this[kv.Key], string.Empty) : @this[kv.Key]));

            return @this;
        }
    }
}