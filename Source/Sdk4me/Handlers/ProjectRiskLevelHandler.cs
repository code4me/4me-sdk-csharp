using System.Collections.Generic;

namespace Sdk4me
{
    public class ProjectRiskLevelHandler : BaseHandler<ProjectRiskLevel>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/project_risk_levels";
        private static readonly string productionUrl = "https://api.4me.com/v1/project_risk_levels";

        public ProjectRiskLevelHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProjectRiskLevelHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
