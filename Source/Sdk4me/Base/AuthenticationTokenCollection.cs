﻿using System;
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
        private List<AuthenticationToken> authenticationTokens = new List<AuthenticationToken>();

        /// <summary>
        /// Create a new instance of an AuthenticationTokenCollection.
        /// </summary>
        public AuthenticationTokenCollection()
        {
        }

        /// <summary>
        /// Create a new instance of an AuthenticationTokenCollection.
        /// </summary>
        /// <param name="token">An 4me authentication token that will be added to the collection.</param>
        public AuthenticationTokenCollection(string token)
        {
            Add(token);
        }

        /// <summary>
        /// Create a new instance of an AuthenticationTokenCollection.
        /// </summary>
        /// <param name="tokens">A list of 4me authentication tokens that will be added to toe collection.</param>
        public AuthenticationTokenCollection(List<string> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
                Add(tokens[i]);
        }

        /// <summary>
        /// Create a new instance of an AuthenticationTokenCollection.
        /// </summary>
        /// <param name="token">An 4me authentication token that will be added to the collection.</param>
        public AuthenticationTokenCollection(AuthenticationToken token)
        {
            Add(token);
        }

        /// <summary>
        /// Adds a 4me authentication token to the collection.
        /// </summary>
        /// <param name="token">The 4me authentication token.</param>
        public void Add(string token)
        {
            this.Add(new AuthenticationToken(token));
        }

        /// <summary>
        /// Adds a 4me authentication token to the collection.
        /// </summary>
        /// <param name="token">The 4me authentication token.</param>
        public void Add(AuthenticationToken token)
        {
            for (int i = 0; i < authenticationTokens.Count; i++)
            {
                if (authenticationTokens[i].Token.Equals(token.Token))
                    return;
            }
            authenticationTokens.Add(token);
        }

        /// <summary>
        /// Removes a 4me authentication token to the collection.
        /// </summary>
        /// <param name="token">The 4me authentication token.</param>
        public void Remove(string token)
        {
            Remove(new AuthenticationToken(token));
        }

        /// <summary>
        /// Removes a 4me authentication token to the collection.
        /// </summary>
        /// <param name="token">The 4me authentication token.</param>
        public void Remove(AuthenticationToken token)
        {
            for (int i = authenticationTokens.Count - 1; i >= 0; i--)
            {
                if (authenticationTokens[i].Token.Equals(token.Token))
                {
                    authenticationTokens.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// Returns the 4me authentication token with most request remaining.
        /// </summary>
        /// <returns></returns>
        public AuthenticationToken Get()
        {
            switch (authenticationTokens.Count)
            {
                case 0:
                    return null;

                case 1:
                    return authenticationTokens[0];

                default:
                    authenticationTokens.Sort(authenticationTokenSorter);
                    return authenticationTokens[0];
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
        /// Returns an enumerator that iterates through the AuthenticationTokenCollection.
        /// </summary>
        /// <returns>A AuthenticationTokenCollection.Enumerator for the AuthenticationTokenCollection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return authenticationTokens.GetEnumerator();
        }

        /// <summary>
        /// Compares two 4me authentication tokens and sort them by request remaining API requests.
        /// </summary>
        private class AuthenticationTokenSorter : IComparer<AuthenticationToken>
        {
            /// <summary>
            /// Compares two 4me authentication and returns sort them by request remaining API requests.
            /// </summary>
            /// <param name="x">The first 4me authentication to compare.</param>
            /// <param name="y">The second 4me authentication to compare.</param>
            /// <returns>A signed integer that indicates the relative values of the first and second 4me authentication token.</returns>
            public int Compare(AuthenticationToken x, AuthenticationToken y)
            {
                return y.RequestsRemaining.CompareTo(x.RequestsRemaining);
            }
        }
    }

}
