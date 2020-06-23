using System;
using System.Collections.Generic;
using System.Linq;

namespace Sdk4me
{
    public class SearchHandler : IBaseHandler
    {
        private readonly AuthenticationTokenCollection authenticationTokens = null;
        private readonly string accountID = null;
        private readonly string url = null;
        private int itemsPerRequest = 100;
        private int maximumRecursiveRequests = 50;

        /// <summary>
        /// <para>Gets or sets the amount of items returned in one request.</para>
        /// <para>The value must be at least 1 and maximum 100.</para>
        /// </summary>
        public int ItemsPerRequest
        {
            get => itemsPerRequest;
            set => itemsPerRequest = (value < 1 || value > 100) ? 100 : value;
        }

        /// <summary>
        /// <para>Gets or sets the amount of recursive requests.</para>
        /// </summary>
        public int MaximumRecursiveRequests
        {
            get => maximumRecursiveRequests;
            set => maximumRecursiveRequests = (value < 1 || value > 100) ? 5 : value;
        }

        /// <summary>
        /// Creates a new instance of the SearchHandler.
        /// </summary>
        /// <param name="authenticationToken">The 4me authentication object.</param>
        /// <param name="accountID">The 4me account identifier.</param>
        /// <param name="environmentType">The 4me environment.</param>
        public SearchHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50)
        {
            this.authenticationTokens = new AuthenticationTokenCollection(authenticationToken);
            this.accountID = accountID;
            this.url = $"{Common.GetBaseUrl(environmentType)}/v1/search";
            this.itemsPerRequest = itemsPerRequest;
            this.maximumRecursiveRequests = maximumRecursiveRequests;
        }

        /// <summary>
        /// Creates a new instance of the SearchHandler.
        /// </summary>
        /// <param name="authenticationTokens">A collection of 4me authorization objects.</param>
        /// <param name="accountID">The 4me account identifier.</param>
        /// <param name="environmentType">The 4me environment.</param>
        public SearchHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50)
        {
            this.authenticationTokens = authenticationTokens;
            this.accountID = accountID;
            this.url = $"{Common.GetBaseUrl(environmentType)}/v1/search";
            this.itemsPerRequest = itemsPerRequest;
            this.maximumRecursiveRequests = maximumRecursiveRequests;
        }

        /// <summary>
        /// Search for through the most relevant 4me records.
        /// </summary>
        /// <param name="text">The search query.</param>
        /// <param name="searchTypes">The types to search for; or all types if none are specified.</param>
        /// <returns>A list of search results.</returns>
        public List<SearchResult> Get(string text, params SearchType[] searchTypes)
        {
            if (authenticationTokens.Count() != 1)
                throw new Sdk4meException("Search functionality with multiple tokens is not supported");

            DefaultHandler<SearchResult> handler = new DefaultHandler<SearchResult>(url, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests);
            return handler.Search(text, null, searchTypes);
        }

        /// <summary>
        /// Search for through the most relevant 4me records.
        /// </summary>
        /// <param name="text">The search query.</param>
        /// <param name="onBehalf">Search on behalf of the person by using the person ID or primary email address.</param>
        /// <param name="searchTypes">The types to search for; or all types if none are specified.</param>
        /// <returns>A list of search results.</returns>
        public List<SearchResult> Get(string text, string onBehalf, params SearchType[] searchTypes)
        {
            if (authenticationTokens.Count() != 1)
                throw new Sdk4meException("Search functionality with multiple tokens is not supported");

            DefaultHandler<SearchResult> handler = new DefaultHandler<SearchResult>(url, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests);
            return handler.Search(text, onBehalf, searchTypes);
        }
    }
}
