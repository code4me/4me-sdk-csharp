using System.Collections.Generic;

namespace Sdk4me
{
    public class UIExtensionHandler : DefaultHandler<UIExtension>
    {
        private const string qualityUrl = "https://api.4me.qa/v1/ui_extensions";
        private const string productionUrl = "https://api.4me.com/v1/ui_extensions";

        public UIExtensionHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public UIExtensionHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region versions

        public List<UIExtensionVersion> GetVersions(UIExtension uIExtension, params string[] attributeNames)
        {
            DefaultHandler<UIExtensionVersion> handler = new DefaultHandler<UIExtensionVersion>($"{URL}/{uIExtension.ID}/versions", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
