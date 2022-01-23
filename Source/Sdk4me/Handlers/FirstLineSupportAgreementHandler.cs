namespace Sdk4me
{
    public class FirstLineSupportAgreementHandler : BaseHandler<FirstLineSupportAgreement, PredefinedFirstLineSupportArgreementFilter>
    {
        public FirstLineSupportAgreementHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/flsas", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public FirstLineSupportAgreementHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/flsas", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

    }
}
