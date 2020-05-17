namespace Sdk4me
{
    public class ProjectRiskLevelHandler : DefaultHandler<ProjectRiskLevel>
    {
        public ProjectRiskLevelHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/project_risk_levels", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProjectRiskLevelHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/project_risk_levels", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
