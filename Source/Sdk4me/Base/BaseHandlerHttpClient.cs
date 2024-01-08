#if NET5_0_OR_GREATER
using Sdk4me.Extensions;
using System;
using System.Net.Http;

namespace Sdk4me
{
    /// <summary>
    /// The shared HTTP client.
    /// </summary>
    public class BaseHandlerHttpClient : IDisposable
    {
        private static readonly object clientLocker = new object();
        private static volatile HttpClient client;

        /// <summary>
        /// Returns the HTTP client.
        /// </summary>
        protected static HttpClient HttpClient
        {
            get
            {
                if (client == null)
                {
                    lock (clientLocker)
                    {
                        if (client == null)
                        {
                            client = new HttpClient();
                            client.SetUserAgent("Sdk4me");
                        }
                    }
                }

                return client;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                client?.Dispose();
                client = null;
            }
        }
    }
}
#endif