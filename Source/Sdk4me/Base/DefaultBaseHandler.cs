namespace Sdk4me
{
    /// <summary>
    /// The default API handler.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DefaultBaseHandler<T> : BaseHandler<T, PredefinedDefaultFilter> where T : BaseItem, new()
    {
        /// <summary>
        /// Create a new instance of the <see cref="DefaultBaseHandler{T}"/>.
        /// </summary>
        /// <param name="endPointUrl">The API end point URL.</param>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me Account ID.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public DefaultBaseHandler(string endPointUrl, AuthenticationToken authenticationToken, string accountID, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base(endPointUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the <see cref="DefaultBaseHandler{T}"/>.
        /// </summary>
        /// <param name="endPointUrl">The API end point URL.</param>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me Account ID.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        /// <param name="sortOrder">The response sort order.</param>
        public DefaultBaseHandler(string endPointUrl, AuthenticationToken authenticationToken, string accountID, int itemsPerRequest = 25, int maximumRecursiveRequests = 10, SortOrder sortOrder = SortOrder.None)
            : base(endPointUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            SortOrder = sortOrder;
        }

        /// <summary>
        /// Create a new instance of the <see cref="DefaultBaseHandler{T}"/>.
        /// </summary>
        /// <param name="endPointUrl">The API end point URL.</param>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me Account ID.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public DefaultBaseHandler(string endPointUrl, AuthenticationTokenCollection authenticationTokens, string accountID, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base(endPointUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the <see cref="DefaultBaseHandler{T}"/>.
        /// </summary>
        /// <param name="endPointUrl">The API end point URL.</param>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me Account ID.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        /// <param name="sortOrder">The response sort order.</param>
        public DefaultBaseHandler(string endPointUrl, AuthenticationTokenCollection authenticationTokens, string accountID, int itemsPerRequest = 25, int maximumRecursiveRequests = 10, SortOrder sortOrder = SortOrder.None)
            : base(endPointUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            SortOrder = sortOrder;
        }
    }
}
