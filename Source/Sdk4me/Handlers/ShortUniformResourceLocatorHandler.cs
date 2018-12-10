using System.Collections.Generic;

namespace Sdk4me
{
    public class ShortUniformResourceLocatorHandler : BaseHandler<ShortUniformResourceLocator>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/short_urls";
        private static readonly string productionUrl = "https://api.4me.com/v1/short_urls";

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
