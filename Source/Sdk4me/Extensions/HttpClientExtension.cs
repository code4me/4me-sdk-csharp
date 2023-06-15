#if NET5_0_OR_GREATER
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;

namespace Sdk4me.Extensions
{
    /// <summary>
    /// A set of <see cref="HttpClient"/> extension methods.
    /// </summary>
    internal static class HttpClientExtension
    {
        /// <summary>
        /// Set the User-Agent based on the <see cref="AssemblyProductAttribute"/> and <see cref="AssemblyInformationalVersionAttribute"/>.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/>.</param>
        /// <param name="defaultProductName">The value when the <see cref="AssemblyProductAttribute"/> value is null.</param>
        public static void SetUserAgent(this HttpClient client, string defaultProductName)
        {
            try
            {
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                string productName = currentAssembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
                string productVersion = currentAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

                client.DefaultRequestHeaders.UserAgent.Clear();
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productName ?? defaultProductName, productVersion));
            }
            catch
            {
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(defaultProductName));
            }
        }
    }
}
#endif