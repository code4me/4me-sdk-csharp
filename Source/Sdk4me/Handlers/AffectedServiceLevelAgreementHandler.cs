namespace Sdk4me
{
    public class AffectedServiceLevelAgreementHandler : DefaultHandler<AffectedServiceLevelAgreement>
    {
        public AffectedServiceLevelAgreementHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/affected_slas", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public AffectedServiceLevelAgreementHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/affected_slas", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
