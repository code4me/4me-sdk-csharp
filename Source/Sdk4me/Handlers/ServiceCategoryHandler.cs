using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/service_categories/">service category</see> API endpoint.
    /// </summary>
    public class ServiceCategoryHandler : DefaultBaseHandler<ServiceCategory>
    {
        /// <summary>
        /// Create a new instance of the 4me service category handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ServiceCategoryHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/service_categories", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me service category handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ServiceCategoryHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/service_categories", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Services

        /// <summary>
        /// Get all related services.
        /// </summary>
        /// <param name="serviceCategory">The service category.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of services.</returns>
        public List<Service> GetServices(ServiceCategory serviceCategory, params string[] fieldNames)
        {
            return GetChildHandler<Service>(serviceCategory, "services").Get(fieldNames);
        }

        /// <summary>
        /// Get all related services.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="serviceCategory">The service category.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of services.</returns>
        public List<Service> GetServices(PredefinedEnabledDisabledFilter filter, ServiceCategory serviceCategory, params string[] fieldNames)
        {
            return GetChildHandler<Service>(serviceCategory, $"services/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a service.
        /// </summary>
        /// <param name="serviceCategory">The service category.</param>
        /// <param name="service">The service to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddService(ServiceCategory serviceCategory, Service service)
        {
            return CreateRelation(serviceCategory, "services", service);
        }

        /// <summary>
        /// Remove a service.
        /// </summary>
        /// <param name="serviceCategory">The service category.</param>
        /// <param name="service">The service to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveService(ServiceCategory serviceCategory, Service service)
        {
            return DeleteRelation(serviceCategory, "services", service);
        }

        /// <summary>
        /// Remove all services.
        /// </summary>
        /// <param name="serviceCategory">The service category.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllServices(ServiceCategory serviceCategory)
        {
            return DeleteAllRelations(serviceCategory, "services");
        }

        #endregion   
    }
}
