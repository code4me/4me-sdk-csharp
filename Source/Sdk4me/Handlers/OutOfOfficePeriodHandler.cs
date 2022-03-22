namespace Sdk4me
{
    public class OutOfOfficePeriodHandler : BaseHandler<OutOfOfficePeriod, PredefinedOpenCompletedFilter>
    {
        public OutOfOfficePeriodHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/out_of_office_periods", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public OutOfOfficePeriodHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/out_of_office_periods", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
