using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/sites/">site</see> API endpoint.
    /// </summary>
    public class SiteHandler : BaseHandler<Site, PredefinedSiteFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me site handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public SiteHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/sites", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me site handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public SiteHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/sites", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region People

        /// <summary>
        /// Get all people.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<Person> GetPeople(Site site, params string[] fieldNames)
        {
            return GetChildHandler<Person>(site, "people").Get(fieldNames);
        }

        /// <summary>
        /// Get all people.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="site">The site.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of people.</returns>
        public List<Person> GetPeople(PredefinedEnabledDisabledFilter filter, Site site, params string[] fieldNames)
        {
            return GetChildHandler<Person>(site, $"people/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Service level agreement

        /// <summary>
        /// Get all service level agreements.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreements.</returns>
        public List<ServiceLevelAgreement> GetServiceLevelAgreements(Site site, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(site, "slas").Get(fieldNames);
        }

        /// <summary>
        /// Get all service level agreements.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="site">The site.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreements.</returns>
        public List<ServiceLevelAgreement> GetServiceLevelAgreements(PredefinedActiveInactiveFilter filter, Site site, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(site, $"slas/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
