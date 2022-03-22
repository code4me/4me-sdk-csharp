using System;

namespace Sdk4me
{
    public static class EnvironmentURL
    {
        /// <summary>
        /// Returns the API endpoint URL for a specific environment.
        /// </summary>
        /// <param name="environment">The environment type.</param>
        /// <param name="environmentRegion">The environment region.</param>
        /// <returns>The API endpoint URL for the specified environment.</returns>
        public static string Get(EnvironmentType environment, EnvironmentRegion environmentRegion)
        {
            switch (environmentRegion)
            {
                case EnvironmentRegion.Australia:
                    switch (environment)
                    {
                        case EnvironmentType.Quality:
                            return "https://api.au.4me.qa/v1";
                        case EnvironmentType.Demo:
                            return "https://api.4me-demo.com/v1";
                        default:
                            return "https://api.au.4me.com/v1";
                    }

                default:
                    switch (environment)
                    {
                        case EnvironmentType.Quality:
                            return "https://api.4me.qa/v1";
                        case EnvironmentType.Demo:
                            return "https://api.4me-demo.com/v1";
                        default:
                            return "https://api.4me.com/v1";
                    }
            }
        }

        internal static string GetStorageFacilityUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or whitespace.", nameof(url));

            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) || uriResult.Scheme != Uri.UriSchemeHttps)
                throw new ArgumentException($"'{nameof(url)}' is invalid.", nameof(url));

            return $"{uriResult.Scheme}://{uriResult.Host}/v1/attachments/storage";
        }
    }
}
