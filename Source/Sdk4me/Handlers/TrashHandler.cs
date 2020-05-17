namespace Sdk4me
{
    public class TrashHandler : DefaultHandler<Trash>
    {
        public TrashHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/trash",  authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            this.SortOrder = SortOrder.CreatedAt;
        }

        public TrashHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/trash",  authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            this.SortOrder = SortOrder.CreatedAt;
        }
    }
}
