namespace Sdk4me
{
    public class ChangeTypeHandler : DefaultHandler<ChangeType>
    {
        public ChangeTypeHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/change_types", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ChangeTypeHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/change_types", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
