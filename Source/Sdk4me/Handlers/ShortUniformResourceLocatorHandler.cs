namespace Sdk4me
{
    public class ShortUniformResourceLocatorHandler : DefaultHandler<ShortUniformResourceLocator>
    {
        public ShortUniformResourceLocatorHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/short_urls", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ShortUniformResourceLocatorHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/short_urls", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
