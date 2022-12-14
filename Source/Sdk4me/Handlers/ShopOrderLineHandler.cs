namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/shop_order_lines/">shop order line</see> API endpoint.
    /// </summary>
    public class ShopOrderLineHandler : BaseHandler<ShopOrderLine, PredefinedShopOrderLineFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me shop article handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ShopOrderLineHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/shop_order_lines", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me shop article handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ShopOrderLineHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/shop_order_lines", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
