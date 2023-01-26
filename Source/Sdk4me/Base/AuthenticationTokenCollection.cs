using System;
using System.Collections;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// A collection of 4me authentication tokens.
    /// </summary>
    public sealed class AuthenticationTokenCollection : IEnumerable<AuthenticationToken>
    {
        private readonly AuthenticationTokenSorter authenticationTokenSorter = new AuthenticationTokenSorter();
        private readonly List<AuthenticationToken> authenticationTokens = new List<AuthenticationToken>();

        /// <summary>
        /// Create a new instance of an <see cref="AuthenticationTokenCollection"/>.
        /// </summary>
        public AuthenticationTokenCollection()
        {
        }

        /// <summary>
        /// Returns the 4me authentication token with the highest remaining requests value.
        /// </summary>
        /// <returns></returns>
        public AuthenticationToken Get()
        {
            if (authenticationTokens.Count.Equals(0))
                return null;

            if (authenticationTokens.Count > 1)
                authenticationTokens.Sort(authenticationTokenSorter);

            if (authenticationTokens[0].RequestsRemaining < 1 && authenticationTokens[0].RequestLimitReset > DateTime.Now)
                throw new Sdk4meException("There are no remaining API requests for the provided authentication tokens.");

            return authenticationTokens[0];
        }

        /// <summary>
        /// Create a new instance of an <see cref="AuthenticationTokenCollection"/> with <b>Personal Access Token</b> authentication.
        /// </summary>
        /// <param name="authenticationToken">The 4me Personal Access Token.</param>
        public AuthenticationTokenCollection(string authenticationToken)
        {
            Add(authenticationToken);
        }

        /// <summary>
        /// Create a new instance of an <see cref="AuthenticationTokenCollection"/> with <b>OAuth 2.0 Client Credentials Grant</b> authentication.
        /// </summary>
        /// <param name="clientID">The 4me OAuth 2.0 client grant client ID.</param>
        /// <param name="clientSecret">The 4me OAuth 2.0 client grant client secret.</param>
        public AuthenticationTokenCollection(string clientID, string clientSecret)
        {
            Add(clientID, clientSecret);
        }

        /// <summary>
        /// Create a new instance of an <see cref="AuthenticationTokenCollection"/>.
        /// </summary>
        /// <param name="authenticationToken">A 4me authentication token to add to the collection.</param>
        public AuthenticationTokenCollection(AuthenticationToken authenticationToken)
        {
            Add(authenticationToken);
        }

        /// <summary>
        /// Add a 4me Personal Access Token to the collection.
        /// </summary>
        /// <param name="authenticationToken">The 4me Personal Access Token.</param>
        public void Add(string authenticationToken)
        {
            Add(new AuthenticationToken(authenticationToken));
        }

        /// <summary>
        /// Add a 4me OAuth 2.0 client grant credential to the collection.
        /// </summary>
        /// <param name="clientID">The 4me OAuth 2.0 client grant client ID.</param>
        /// <param name="clientSecret">The 4me OAuth 2.0 client grant client secret.</param>
        public void Add(string clientID, string clientSecret)
        {
            Add(new AuthenticationToken(clientID, clientSecret));
        }

        /// <summary>
        /// Adds a 4me authentication token to the collection.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication token.</param>
        public void Add(AuthenticationToken authenticationToken)
        {
            if (authenticationToken is null)
                throw new ArgumentNullException(nameof(authenticationToken));

            if (string.IsNullOrWhiteSpace(authenticationToken.Token) && (string.IsNullOrWhiteSpace(authenticationToken.ClientID) || string.IsNullOrWhiteSpace(authenticationToken.ClientSecret)))
                throw new ArgumentException($"Missing Client ID and Client Secret, or Personal Access Token");

            for (int i = 0; i < authenticationTokens.Count; i++)
            {
                if (authenticationTokens[i].Identifier == authenticationToken.Identifier)
                    return;
            }
            authenticationTokens.Add(authenticationToken);
        }

        /// <summary>
        /// Removes a 4me authentication token from the collection.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication token.</param>
        public void Remove(string authenticationToken)
        {
            Remove(new AuthenticationToken(authenticationToken));
        }

        /// <summary>
        /// Removes a 4me authentication token from the collection.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication token.</param>
        public void Remove(AuthenticationToken authenticationToken)
        {
            if (authenticationToken is null)
                throw new ArgumentNullException(nameof(authenticationToken));

            if (string.IsNullOrWhiteSpace(authenticationToken.Token) && (string.IsNullOrWhiteSpace(authenticationToken.ClientID) || string.IsNullOrWhiteSpace(authenticationToken.ClientSecret)))
                throw new ArgumentException($"Missing Client ID and Client Secret, or Personal Access Token");

            for (int i = authenticationTokens.Count - 1; i >= 0; i--)
            {
                if (authenticationTokens[i].Identifier == authenticationToken.Identifier)
                {
                    authenticationTokens.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the AuthenticationTokenCollection.
        /// </summary>
        /// <returns>A AuthenticationTokenCollection.Enumerator for the AuthenticationTokenCollection.</returns>
        public IEnumerator<AuthenticationToken> GetEnumerator()
        {
            return authenticationTokens.GetEnumerator();
        }

        /// <summary>
        /// Removes all elements from the AuthenticationTokenCollection.
        /// </summary>
        public void Clear()
        {
            authenticationTokens.Clear();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the AuthenticationTokenCollection.
        /// </summary>
        /// <returns>A AuthenticationTokenCollection.Enumerator for the AuthenticationTokenCollection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return authenticationTokens.GetEnumerator();
        }

        /// <summary>
        /// Compares two 4me authentication tokens and sort them by remaining API requests.
        /// </summary>
        private class AuthenticationTokenSorter : IComparer<AuthenticationToken>
        {
            /// <summary>
            /// Compares two 4me authentication and returns sort them by remaining API requests and limit values.
            /// </summary>
            /// <param name="x">The first <see cref="AuthenticationToken"/> to compare.</param>
            /// <param name="y">The second <see cref="AuthenticationToken"/> to compare.</param>
            /// <returns>A signed integer that indicates the relative values of the first and second <see cref="AuthenticationToken"/>.</returns>
            public int Compare(AuthenticationToken x, AuthenticationToken y)
            {
                int sortValue = y.RequestsRemaining.CompareTo(x.RequestsRemaining);
                return (sortValue == 0) ? x.RequestLimitReset.CompareTo(y.RequestLimitReset) : sortValue;
            }
        }
    }
}
