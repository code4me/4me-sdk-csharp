using System.Collections.Generic;

namespace Sdk4me
{
    public class ShortUniformResourceLocatorHandler : DefaultHandler<ShortUniformResourceLocator>
    {
        private const string qualityUrl = "https://api.4me.qa/v1/short_urls";
        private const string productionUrl = "https://api.4me.com/v1/short_urls";

        public ShortUniformResourceLocatorHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ShortUniformResourceLocatorHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
