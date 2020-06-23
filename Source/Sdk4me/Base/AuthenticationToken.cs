using System;
using System.Diagnostics;
using System.Text;

namespace Sdk4me
{
    public sealed class AuthenticationToken
    {
        private readonly AuthenticationType authenticationTokenType = AuthenticationType.BasicAuthentication;
        private readonly string authenticationToken = null;
        private int requestLimit = 3600;
        private int requestsRemaining = 3600;
        private DateTime requestReset = DateTime.MinValue;
        private DateTime updatedAt = DateTime.MinValue;

        /// <summary>
        /// The 4me authentication token.
        /// </summary>
        internal string Token
        {
            get => authenticationToken;
        }

        internal AuthenticationType TokenType
        {
            get => authenticationTokenType;
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
            get => requestReset;
            internal set => requestReset = value;
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
        /// Create a new instance of an AuthenticationToken.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication token.</param>
        [Obsolete]
        public AuthenticationToken(string authenticationToken)
        {
            this.authenticationTokenType = AuthenticationType.BasicAuthentication;
            this.authenticationToken = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(authenticationToken + ":."));
        }

        /// <summary>
        /// Create a new instance of an AuthenticationToken.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication token.</param>
        /// <param name="authenticationType">The 4me authentication token type.</param>
        public AuthenticationToken(string authenticationToken, AuthenticationType authenticationType)
        {
            if (authenticationType == AuthenticationType.BearerAuthentication)
                this.authenticationToken = "Bearer " + authenticationToken;
            else
                this.authenticationToken = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(authenticationToken + ":."));
            this.authenticationTokenType = authenticationType;
        }
    }

}
