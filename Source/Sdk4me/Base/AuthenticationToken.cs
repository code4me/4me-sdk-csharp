using System;
using System.Diagnostics;
using System.Text;

namespace Sdk4me
{
    public sealed class AuthenticationToken
    {
        private readonly string token = null;
        private readonly string basicAuthenticationToken = null;
        private int requestLimit = 3600;
        private int requestsRemaining = 3600;
        private DateTime updatedAt = DateTime.MinValue;

        /// <summary>
        /// The 4me authentication token.
        /// </summary>
        internal string Token
        {
            get => token;
        }

        /// <summary>
        /// Get the total request amount.
        /// </summary>
        public int RequestLimit
        {
            get => requestLimit;
            internal set => requestLimit = value;
        }

        /// <summary>
        /// Get the amount of requests available.
        /// </summary>
        public int RequestsRemaining
        {
            get => requestsRemaining;
            internal set => requestsRemaining = value;
        }

        /// <summary>
        /// Return the date and time when the request limit and remaining request values were updated.
        /// </summary>
        public DateTime UpdatedAt
        {
            get => updatedAt;
            internal set => updatedAt = value;
        }

        /// <summary>
        /// Returns a basic authentication value for this 4me authentication token.
        /// </summary>
        internal string BasicAuthenticationToken
        {
            get => basicAuthenticationToken;
        }

        /// <summary>
        /// Create a new instance of an AuthenticationToken.
        /// </summary>
        /// <param name="token">The 4me authentication token.</param>
        public AuthenticationToken(string token)
        {
            this.token = token;
            this.basicAuthenticationToken = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(token + ":."));
        }
    }

}
