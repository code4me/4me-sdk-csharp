using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/reservation_offerings/">reservation offerings</see> API endpoint.
    /// </summary>
    public class ReservationOfferingHandler : BaseHandler<ReservationOffering, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me reservation offerings handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ReservationOfferingHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/reservation_offerings", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me reservation offerings handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ReservationOfferingHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/reservation_offerings", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Configuration items

        /// <summary>
        /// Get all related configuration items.
        /// </summary>
        /// <param name="reservationOffering">The reservation offering.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(ReservationOffering reservationOffering, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(reservationOffering, "cis").Get(fieldNames);
        }

        /// <summary>
        /// Get all related configuration items.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="reservationOffering">The reservation offering.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, ReservationOffering reservationOffering, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(reservationOffering, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Request templates

        /// <summary>
        /// Get all related request templates.
        /// </summary>
        /// <param name="reservationOffering">The reservation offering.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of request templates.</returns>
        public List<RequestTemplate> GetRequestTemplates(ReservationOffering reservationOffering, params string[] fieldNames)
        {
            return GetChildHandler<RequestTemplate>(reservationOffering, "request_templates").Get(fieldNames);
        }

        /// <summary>
        /// Get all related request templates.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="reservationOffering">The reservation offering.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of request templates.</returns>
        public List<RequestTemplate> GetRequestTemplates(PredefinedEnabledDisabledFilter filter, ReservationOffering reservationOffering, params string[] fieldNames)
        {
            return GetChildHandler<RequestTemplate>(reservationOffering, $"request_templates/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
