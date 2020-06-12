using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            set => maximumRecursiveRequests = (value < 1 || value > 1000) ? 50 : value;
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
        /// Search for something.
        /// </summary>
        /// <param name="text">The search filter.</param>
        /// <param name="searchTypes">The search types.</param>
        /// <returns>A search result collection.</returns>
        public List<SearchResult> Get(string text, params SearchType[] searchTypes)
        {
            return Search(text, null, searchTypes);
        }

        /// <summary>
        /// Search for something.
        /// </summary>
        /// <param name="text">The search filter.</param>
        /// <param name="onBehalfOf">Search on behalf of.</param>
        /// <param name="searchTypes">The search types.</param>
        /// <returns>A search result collection.</returns>
        public List<SearchResult> Get(string text, Person onBehalfOf, params SearchType[] searchTypes)
        {
            if (onBehalfOf == null)
                throw new ArgumentNullException(nameof(onBehalfOf));
            return Search(text, onBehalfOf.ID.ToString(), searchTypes);
        }

        /// <summary>
        /// Search for something.
        /// </summary>
        /// <param name="text">The search filter.</param>
        /// <param name="onBehalfOf">Search on behalf of.</param>
        /// <param name="searchTypes">The search types.</param>
        /// <returns>A search result collection.</returns>
        public List<SearchResult> Get(string text, string identifierOrPrimaryEmailAddress, params SearchType[] searchTypes)
        {
            if (string.IsNullOrWhiteSpace(identifierOrPrimaryEmailAddress))
                throw new ArgumentException("Value cannot be null or blank", nameof(identifierOrPrimaryEmailAddress));
            return Search(text, identifierOrPrimaryEmailAddress, searchTypes);
        }

        //TODO: Custom Serialization for search results - response header is different

        private List<SearchResult> Search(string text, string onBehalfOf, params SearchType[] searchTypes)
        {
            string url = $"{this.url}?q={Uri.EscapeDataString(text)}";
            List<string> filters = new List<string>();

            if (searchTypes.GetUpperBound(0) == -1)
            {
                foreach (SearchType searchFilter in Enum.GetValues(typeof(SearchType)))
                    filters.Add(Common.GetStringEnumValue(searchFilter));
            }
            else
            {
                foreach (SearchType searchFilter in searchTypes)
                    filters.Add(Common.GetStringEnumValue(searchFilter));
            }
            url += "&types=" + string.Join(",", filters);

            //if (!string.IsNullOrWhiteSpace(onBehalfOf))
            //    url += "&on_behalf_of=" + Uri.EscapeDataString(onBehalfOf);

            DefaultHandler <SearchResult> handler = new DefaultHandler<SearchResult>(url, authenticationTokens, accountID, 100, 1000);
            handler.AlwaysAsList = true;

            return handler.Get();
        }
    }
}
