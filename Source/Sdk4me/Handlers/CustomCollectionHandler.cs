using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class CustomCollectionHandler : BaseHandler<CustomCollection, PredefinedEnabledDisabledFilter>
    {
        public CustomCollectionHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/custom_collections", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public CustomCollectionHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/custom_collections", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Collection Elements

        public List<CustomCollectionElement> GetCollectionElements(CustomCollection customCollection, params string[] fieldNames)
        {
            return GetChildHandler<CustomCollectionElement>(customCollection, "collection_elements").Get(fieldNames);
        }

        public List<CustomCollectionElement> GetCollectionElements(PredefinedEnabledDisabledFilter filter, CustomCollection customCollection, params string[] fieldNames)
        {
            return GetChildHandler<CustomCollectionElement>(customCollection, $"collection_elements/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
