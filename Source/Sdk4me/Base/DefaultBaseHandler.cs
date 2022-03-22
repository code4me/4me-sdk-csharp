namespace Sdk4me
{
    public class DefaultBaseHandler<T> : BaseHandler<T, PredefinedDefaultFilter> where T : BaseItem, new()
    {
        public DefaultBaseHandler(string endPointUrl, AuthenticationToken authenticationToken, string accountID, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base(endPointUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public DefaultBaseHandler(string endPointUrl, AuthenticationTokenCollection authenticationTokens, string accountID, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base(endPointUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public DefaultBaseHandler(string endPointUrl, AuthenticationTokenCollection authenticationTokens, string accountID, int itemsPerRequest = 25, int maximumRecursiveRequests = 10, SortOrder sortOrder = SortOrder.None)
            : base(endPointUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            SortOrder = sortOrder;
        }
    }
}
