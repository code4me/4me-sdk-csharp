using System;

namespace Sdk4me
{
    /// <summary>
    /// Get the 4me environment URL.
    /// </summary>
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
                case EnvironmentRegion.AU:
                    switch (environment)
                    {
                        case EnvironmentType.Quality:
                            return "https://api.au.4me.qa/v1";
                        case EnvironmentType.Demo:
                            return "https://api.4me-demo.com/v1";
                        default:
                            return "https://api.au.4me.com/v1";
                    }

                case EnvironmentRegion.UK:
                    switch (environment)
                    {
                        case EnvironmentType.Quality:
                            return "https://api.uk.4me.qa/v1";
                        case EnvironmentType.Demo:
                            return "https://api.4me-demo.com/v1";
                        default:
                            return "https://api.uk.4me.com/v1";
                    }

                case EnvironmentRegion.US:
                    switch (environment)
                    {
                        case EnvironmentType.Quality:
                            return "https://api.us.4me.qa/v1";
                        case EnvironmentType.Demo:
                            return "https://api.4me-demo.com/v1";
                        default:
                            return "https://api.us.4me.com/v1";
                    }

                case EnvironmentRegion.CH:
                    switch (environment)
                    {
                        case EnvironmentType.Quality:
                            return "https://api.ch.4me.qa/v1";
                        case EnvironmentType.Demo:
                            return "https://api.4me-demo.com/v1";
                        default:
                            return "https://api.ch.4me.com/v1";
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

        internal static string GetOAuth2Url(string url) 
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException($"'{nameof(url)}' cannot be null or whitespace.", nameof(url));

            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) || uriResult.Scheme != Uri.UriSchemeHttps)
                throw new ArgumentException($"'{nameof(url)}' is invalid.", nameof(url));

            return $"{uriResult.Scheme}://{uriResult.Host.Replace("api.","oauth.")}/token";
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
