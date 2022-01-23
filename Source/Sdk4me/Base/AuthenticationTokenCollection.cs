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
        /// Create a new instance of an AuthenticationTokenCollection.
        /// </summary>
        public AuthenticationTokenCollection()
        {
        }

        /// <summary>
        /// Create a new instance of an AuthenticationTokenCollection.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication token.</param>
        /// <param name="authenticationType">The 4me authentication token type.</param>
        public AuthenticationTokenCollection(string authenticationToken, AuthenticationType authenticationType)
        {
            Add(authenticationToken, authenticationType);
        }


        /// <summary>
        /// Create a new instance of an AuthenticationTokenCollection.
        /// </summary>
        /// <param name="authenticationToken">An 4me authentication token that will be added to the collection.</param>
        public AuthenticationTokenCollection(AuthenticationToken authenticationToken)
        {
            Add(authenticationToken);
        }

        /// <summary>
        /// Adds a 4me authentication token to the collection.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication token.</param>
        /// <param name="authenticationType">The 4me authentication token type.</param>
        public void Add(string authenticationToken, AuthenticationType authenticationType)
        {
            Add(new AuthenticationToken(authenticationToken, authenticationType));
        }

        /// <summary>
        /// Adds a 4me authentication token to the collection.
        /// </summary>
        /// <param name="token">The 4me authentication token.</param>
        public void Add(AuthenticationToken token)
        {
            for (int i = 0; i < authenticationTokens.Count; i++)
            {
                if (authenticationTokens[i].Token.Equals(token.Token) && authenticationTokens[i].TokenType.Equals(token.TokenType))
                    return;
            }
            authenticationTokens.Add(token);
        }

        /// <summary>
        /// Removes a 4me authentication token to the collection.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication token.</param>
        /// <param name="authenticationType">The 4me authentication token type.</param>
        public void Remove(string authenticationToken, AuthenticationType authenticationType)
        {
            Remove(new AuthenticationToken(authenticationToken, authenticationType));
        }

        /// <summary>
        /// Removes a 4me authentication token to the collection.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication token.</param>
        /// <param name="authenticationType">The 4me authentication token type.</param>
        public void Remove(AuthenticationToken authenticationToken)
        {
            for (int i = authenticationTokens.Count - 1; i >= 0; i--)
            {
                if (authenticationTokens[i].Token.Equals(authenticationToken.Token) && authenticationTokens[i].TokenType.Equals(authenticationToken.TokenType))
                {
                    authenticationTokens.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// Returns the 4me authentication token with most requests remaining.
        /// </summary>
        /// <returns></returns>
        public AuthenticationToken Get()
        {
            if (authenticationTokens.Count.Equals(0))
                return null;

            if (authenticationTokens.Count > 1)
                authenticationTokens.Sort(authenticationTokenSorter);

            if (authenticationTokens[0].RequestsRemaining == 0 && authenticationTokens[0].RequestLimitReset > DateTime.Now)
                throw new Sdk4meException("There are no remaining API requests for the provided authentication tokens.");

            return authenticationTokens[0];
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
            /// <param name="x">The first 4me authentication to compare.</param>
            /// <param name="y">The second 4me authentication to compare.</param>
            /// <returns>A signed integer that indicates the relative values of the first and second 4me authentication token.</returns>
            public int Compare(AuthenticationToken x, AuthenticationToken y)
            {
                int sortValue = y.RequestsRemaining.CompareTo(x.RequestsRemaining);
                return (sortValue == 0) ? x.RequestLimitReset.CompareTo(y.RequestLimitReset) : sortValue;
            }
        }
    }

}
