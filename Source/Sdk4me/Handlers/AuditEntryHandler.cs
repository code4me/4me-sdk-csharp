namespace Sdk4me
{
    public class AuditEntryHandler : DefaultBaseHandler<AuditTrail>
    {
        public AuditEntryHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/audit_lines", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests, SortOrder.CreatedAt)
        {
        }

        public AuditEntryHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/audit_lines", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests, SortOrder.CreatedAt)
        {
        }
    }
}
