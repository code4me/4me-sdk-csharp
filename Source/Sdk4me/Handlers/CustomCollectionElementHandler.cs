namespace Sdk4me
{
    public class CustomCollectionElementHandler : BaseHandler<CustomCollectionElement, PredefinedEnabledDisabledFilter>
    {
        public CustomCollectionElementHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/custom_collection_elements", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public CustomCollectionElementHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/custom_collection_elements", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
