using System.Collections.Generic;

namespace Sdk4me
{
    public class AffectedServiceLevelAgreementHandler : BaseHandler<AffectedServiceLevelAgreement>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/affected_slas";
        private static readonly string productionUrl = "https://api.4me.com/v1/affected_slas";

        public AffectedServiceLevelAgreementHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public AffectedServiceLevelAgreementHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
