using Sdk4me.Extensions;
using System.Collections.Generic;
using System.Security.Claims;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/service_offerings/">service offering</see> API endpoint.
    /// </summary>
    public class ServiceOfferingHandler : BaseHandler<ServiceOffering, PredefinedServiceOfferingFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me service offering handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ServiceOfferingHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/service_offerings", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me service offering handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ServiceOfferingHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/service_offerings", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Service level agreements

        /// <summary>
        /// Get all service level agreements.
        /// </summary>
        /// <param name="serviceOffering">The service offering.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreements.</returns>
        public List<ServiceLevelAgreement> GetConfigurationItems(ServiceOffering serviceOffering, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(serviceOffering, "slas").Get(fieldNames);
        }

        /// <summary>
        /// Get all service level agreements.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="serviceOffering">The service offering.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreements.</returns>
        public List<ServiceLevelAgreement> GetConfigurationItems(PredefinedActiveInactiveFilter filter, ServiceOffering serviceOffering, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(serviceOffering, $"slas/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Standard service request

        /// <summary>
        /// Get all standard service requests.
        /// </summary>
        /// <param name="serviceOffering">The service offering.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of standard service requests.</returns>
        public List<StandardServiceRequest> GetStandardServiceRequests(ServiceOffering serviceOffering, params string[] fieldNames)
        {
            return GetChildHandler<StandardServiceRequest>(serviceOffering, "standard_service_requests").Get(fieldNames);
        }

        /// <summary>
        /// Add a standard service request.
        /// </summary>
        /// <param name="serviceOffering">The service offering.</param>
        /// <param name="standardServiceRequest">The standard service request to add.</param>
        /// <returns>An updated standard service request.</returns>
        public StandardServiceRequest AddStandardServiceRequest(ServiceOffering serviceOffering, StandardServiceRequest standardServiceRequest)
        {
            return GetChildHandler<StandardServiceRequest>(serviceOffering, "standard_service_requests").Insert(standardServiceRequest);
        }

        /// <summary>
        /// Update a standard service request.
        /// </summary>
        /// <param name="serviceOffering">The service offering.</param>
        /// <param name="standardServiceRequest">The standard service request to update.</param>
        /// <returns>An updated standard service request.</returns>
        public StandardServiceRequest UpdateStandardServiceRequest(ServiceOffering serviceOffering, StandardServiceRequest standardServiceRequest)
        {
            return GetChildHandler<StandardServiceRequest>(serviceOffering, "standard_service_requests").Update(standardServiceRequest);
        }

        /// <summary>
        /// Delete a standard service request.
        /// </summary>
        /// <param name="serviceOffering">The service offering.</param>
        /// <param name="standardServiceRequest">The standard service request to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteStandardServiceRequest(ServiceOffering serviceOffering, StandardServiceRequest standardServiceRequest)
        {
            return GetChildHandler<StandardServiceRequest>(serviceOffering, "standard_service_requests").Delete(standardServiceRequest);
        }

        /// <summary>
        /// Delete all standard service requests.
        /// </summary>
        /// <param name="serviceOffering">The service offering.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteStandardServiceRequests(ServiceOffering serviceOffering)
        {
            return GetChildHandler<StandardServiceRequest>(serviceOffering, "standard_service_requests").DeleteAll();
        }

        #endregion

        #region Effort class rates

        /// <summary>
        /// Get all effort class rates.
        /// </summary>
        /// <param name="serviceOffering">The service offering.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of effort class rates.</returns>
        public List<EffortClassRate> GetEffortClassRates(ServiceOffering serviceOffering, params string[] fieldNames)
        {
            return GetChildHandler<EffortClassRate>(serviceOffering, "effort_class_rates", SortOrder.None).Get(fieldNames);
        }

        /// <summary>
        /// Add a effort class rate.
        /// </summary>
        /// <param name="serviceOffering">The service offering.</param>
        /// <param name="effortClassRate">The effort class rate to add.</param>
        /// <returns>An updated effort class rate.</returns>
        public EffortClassRate AddEffortClassRate(ServiceOffering serviceOffering, EffortClassRate effortClassRate)
        {
            return GetChildHandler<EffortClassRate>(serviceOffering, "effort_class_rates").Insert(effortClassRate);
        }

        /// <summary>
        /// Update a effort class rate.
        /// </summary>
        /// <param name="serviceOffering">The service offering.</param>
        /// <param name="effortClassRate">The effort class rate to update.</param>
        /// <returns>An updated effort class rate.</returns>
        public EffortClassRate UpdateEffortClassRate(ServiceOffering serviceOffering, EffortClassRate effortClassRate)
        {
            return GetChildHandler<EffortClassRate>(serviceOffering, "effort_class_rates").Update(effortClassRate);
        }

        /// <summary>
        /// Delete an effort class rate.
        /// </summary>
        /// <param name="serviceOffering">The service offering.</param>
        /// <param name="effortClassRate">The effort class rate to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool DeleteStandardServiceRequest(ServiceOffering serviceOffering, EffortClassRate effortClassRate)
        {
            return GetChildHandler<EffortClassRate>(serviceOffering, "effort_class_rates").Delete(effortClassRate);
        }

        #endregion
    }
}
