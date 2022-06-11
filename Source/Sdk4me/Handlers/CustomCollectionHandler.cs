using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/custom_collections/">custom collection</see> API endpoint.
    /// </summary>
    public class CustomCollectionHandler : BaseHandler<CustomCollection, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me custom collection handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public CustomCollectionHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/custom_collections", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me custom collection handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public CustomCollectionHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/custom_collections", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Collection Elements

        /// <summary>
        /// Get all related custom collection elements.
        /// </summary>
        /// <param name="customCollection">The custom collection.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of custom collection elements.</returns>
        public List<CustomCollectionElement> GetCollectionElements(CustomCollection customCollection, params string[] fieldNames)
        {
            return GetChildHandler<CustomCollectionElement>(customCollection, "collection_elements").Get(fieldNames);
        }

        /// <summary>
        /// Get all related custom collection elements.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="customCollection">The custom collection.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of custom collection elements.</returns>
        public List<CustomCollectionElement> GetCollectionElements(PredefinedEnabledDisabledFilter filter, CustomCollection customCollection, params string[] fieldNames)
        {
            return GetChildHandler<CustomCollectionElement>(customCollection, $"collection_elements/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
