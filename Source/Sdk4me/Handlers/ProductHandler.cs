using System.Collections.Generic;

namespace Sdk4me
{
    public class ProductHandler : BaseHandler<Product, PredefinedProductFilter>
    {
        public ProductHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/products", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ProductHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/products", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region configuration items

        public List<ConfigurationItem> GetConfigurationItems(Product product, params string[] attributeNames)
        {
            DefaultHandler<ConfigurationItem> handler = new DefaultHandler<ConfigurationItem>($"{this.URL}/{product.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
