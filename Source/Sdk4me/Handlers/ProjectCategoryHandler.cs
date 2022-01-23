namespace Sdk4me
{
    public class ProjectCategoryHandler : DefaultHandler<ProjectCategory>
    {
        public ProjectCategoryHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/project_categories", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProjectCategoryHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/project_categories", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
