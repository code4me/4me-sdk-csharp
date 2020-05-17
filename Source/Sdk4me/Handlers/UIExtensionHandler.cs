using System.Collections.Generic;

namespace Sdk4me
{
    public class UIExtensionHandler : DefaultHandler<UIExtension>
    {
        public UIExtensionHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/ui_extensions",  authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public UIExtensionHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/ui_extensions",  authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
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
