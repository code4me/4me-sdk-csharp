using System.Collections.Generic;

namespace Sdk4me
{
    public class UIExtensionHandler : DefaultBaseHandler<UIExtension>
    {
        public UIExtensionHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/ui_extensions", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public UIExtensionHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/ui_extensions", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Versions

        public List<UIExtensionVersion> GetVersions(UIExtension uiExtension, params string[] fieldNames)
        {
            return GetChildHandler<UIExtensionVersion>(uiExtension, "versions").Get(fieldNames);
        }

        #endregion
    }
}
