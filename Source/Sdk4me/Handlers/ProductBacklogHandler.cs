using System.Collections.Generic;

namespace Sdk4me
{
    public class ProductBacklogHandler : BaseHandler<ProductBacklog, PredefinedEnabledDisabledFilter>
    {
        public ProductBacklogHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/product_backlogs", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProductBacklogHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/product_backlogs", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Product backlog items

        public List<ProductBacklogItem> GetProductBacklogItems(ProductBacklog productBacklog)
        {
            return GetChildHandler<ProductBacklogItem>(productBacklog, "product_backlog_items").Get();
        }

        #endregion
    }
}
