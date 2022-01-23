namespace Sdk4me
{
    public class ProductCategoryHandler : DefaultHandler<ProductCategory>
    {
        public ProductCategoryHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/product_categories", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProductCategoryHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/product_categories", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }
    }
}
