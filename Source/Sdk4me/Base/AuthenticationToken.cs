using System;

namespace Sdk4me
{
    /// <summary>
    /// The 4me authentication token.
    /// </summary>
    public sealed class AuthenticationToken
    {
        private readonly int identifier = 0;
        private readonly string clientID;
        private readonly string clientSecret;
        private string authenticationToken;
        private string tokenType;
        private int requestLimit = int.MaxValue;
        private int requestsRemaining = int.MaxValue;
        private DateTime requestLimitReset = DateTime.MinValue;
        private DateTime updatedAt = DateTime.MinValue;
        private DateTime authenticationTokenExpires = DateTime.MinValue;

        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        internal int Identifier
        {
            get => identifier;
        }

        /// <summary>
        /// Get the 4me authentication token.
        /// </summary>
        internal string Token
        {
            get => authenticationToken;
            set => authenticationToken = value;
        }

        /// <summary>
        /// Get or set the token type.
        /// </summary>
        internal string TokenType
        {
            get => tokenType;
            set => tokenType = value;
        }

        /// <summary>
        /// Get the 4me OAuth 2.0 client grant client ID.
        /// </summary>
        public string ClientID
        {
            get => clientID;
        }

        /// <summary>
        /// Get the 4me OAuth 2.0 client grant client secret.
        /// </summary>
        internal string ClientSecret
        {
            get => clientSecret;
        }

        /// <summary>
        /// Get or set the 4me OAuth 2.0 client grant token expiration time.
        /// </summary>
        internal DateTime AuthenticationTokenExpires
        {
            get => authenticationTokenExpires;
            set => authenticationTokenExpires = value;
        }

        /// <summary>
        /// The maximum number of requests permitted to make in the current rate limit window.
        /// </summary>
        public int RequestLimit
        {
            get => requestLimit;
            internal set => requestLimit = value;
        }

        /// <summary>
        /// The number of requests remaining in the current rate limit window.
        /// </summary>
        public int RequestsRemaining
        {
            get => requestsRemaining;
            internal set => requestsRemaining = value;
        }

        /// <summary>
        /// The local time at which the current rate limit window resets.
        /// </summary>
        public DateTime RequestLimitReset
        {
            get => requestLimitReset;
            internal set => requestLimitReset = value;
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
        /// Check if the current token is expired.
        /// </summary>
        /// <returns>True if the current token is expired; otherwise false</returns>
        internal bool IsTokenExpired()
        {
            return authenticationTokenExpires < DateTime.Now.AddMinutes(+1);
        }

        /// <summary>
        /// Create a new instance of an <see cref="AuthenticationToken"/> with <b>Personal Access Token</b> authentication.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication token.</param>
        public AuthenticationToken(string authenticationToken)
        {
            this.authenticationToken = authenticationToken;
            authenticationTokenExpires = DateTime.MaxValue;
            tokenType = "bearer";
            identifier = authenticationToken.GetHashCode();
        }

        /// <summary>
        /// Create a new instance of an <see cref="AuthenticationToken"/> with <b>OAuth 2.0 Client Credentials Grant</b> authentication.
        /// </summary>
        /// <param name="clientID">The 4me OAuth 2.0 client grant ID.</param>
        /// <param name="clientSecret">The 4me OAuth 2.0 client grant secret.</param>
        public AuthenticationToken(string clientID, string clientSecret)
        {
            this.clientID = clientID;
            this.clientSecret = clientSecret;
            authenticationTokenExpires = DateTime.MinValue;
            tokenType = string.Empty;
            identifier = (clientID + clientSecret).GetHashCode();
        }
    }
}
