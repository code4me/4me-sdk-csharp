namespace Sdk4me
{
    public class ArchiveHandler : DefaultHandler<Archive>
    {
        public ArchiveHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/archive",  authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            this.SortOrder = SortOrder.CreatedAt;
        }

        public ArchiveHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/archive",  authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
            this.SortOrder = SortOrder.CreatedAt;
        }
    }
}
