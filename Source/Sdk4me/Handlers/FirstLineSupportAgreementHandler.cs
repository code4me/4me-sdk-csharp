using System.Collections.Generic;

namespace Sdk4me
{
    public class FirstLineSupportAgreementHandler : BaseHandler<FirstLineSupportAgreement>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/flsas";
        private static readonly string productionUrl = "https://api.4me.com/v1/flsas";

        public FirstLineSupportAgreementHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public FirstLineSupportAgreementHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

    }
}
