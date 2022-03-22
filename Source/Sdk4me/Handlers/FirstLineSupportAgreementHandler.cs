namespace Sdk4me
{
    public class FirstLineSupportAgreementHandler : BaseHandler<FirstLineSupportAgreement, PredefinedActiveInactiveFilter>
    {
        public FirstLineSupportAgreementHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/flsas", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public FirstLineSupportAgreementHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/flsas", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
