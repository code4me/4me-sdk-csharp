#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER || NET452_OR_GREATER
using System.Net;
using System.Reflection;

namespace Sdk4me.Extensions
{
    /// <summary>
    /// A set of <see cref="HttpWebRequest"/> extension methods.
    /// </summary>
    internal static class HttpWebRequestExtension
    {
        private static Assembly currentAssembly;

        /// <summary>
        /// Set the User-Agent based on the <see cref="AssemblyProductAttribute"/> and <see cref="AssemblyInformationalVersionAttribute"/>.
        /// </summary>
        /// <param name="httpWebRequest">The <see cref="HttpWebRequest"/>.</param>
        /// <param name="defaultProductName">The value when the <see cref="AssemblyProductAttribute"/> value is null.</param>
        public static void SetUserAgent(this HttpWebRequest httpWebRequest, string defaultProductName)
        {
            try
            {
                if (currentAssembly == null)
                    currentAssembly = Assembly.GetExecutingAssembly();

                string productName = currentAssembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
                string productVersion = currentAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

                httpWebRequest.UserAgent = productName + (!string.IsNullOrEmpty(productVersion) ? $"/{productVersion}" : "");
            }
            catch
            {
                httpWebRequest.UserAgent = defaultProductName;
            }
        }
    }
}
#endif