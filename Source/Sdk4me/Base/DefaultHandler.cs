namespace Sdk4me
{
    public class DefaultHandler<T> : BaseHandler<T, PredefinedDefaultFilter> where T : BaseItem, new()
    {
        public DefaultHandler(string apiURL, AuthenticationToken authenticationToken, string accountID = null, int itemsPerRequest = 100, int maximumRecursiveRequests = 50)
            : this(apiURL, new AuthenticationTokenCollection(authenticationToken), accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public DefaultHandler(string apiURL, AuthenticationTokenCollection authenticationTokens, string accountID = null, int itemsPerRequest = 100, int maximumRecursiveRequests = 50)
            : base(apiURL, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
