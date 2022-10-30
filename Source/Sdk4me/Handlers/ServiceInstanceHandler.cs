using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/service_instances/">service instance</see> API endpoint.
    /// </summary>
    public class ServiceInstanceHandler : BaseHandler<ServiceInstance, PredefinedActiveInactiveFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me service instance handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ServiceInstanceHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/service_instances", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me service instance handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ServiceInstanceHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.EU, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/service_instances", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Child service instances

        /// <summary>
        /// Get all child service instances.
        /// </summary>
        /// <param name="serviceInstance">The service instance.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instances.</returns>
        public List<ServiceInstance> GetChildServiceInstances(ServiceInstance serviceInstance, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(serviceInstance, "child_service_instances").Get(fieldNames);
        }

        #endregion

        #region Configuration items

        /// <summary>
        /// Get all related configuration items.
        /// </summary>
        /// <param name="serviceInstance">The service instance.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(ServiceInstance serviceInstance, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(serviceInstance, "cis").Get(fieldNames);
        }

        /// <summary>
        /// Get all related configuration items.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="serviceInstance">The service instance.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of configuration items.</returns>
        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, ServiceInstance serviceInstance, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(serviceInstance, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        /// <summary>
        /// Add a configuration item.
        /// </summary>
        /// <param name="serviceInstance">The service instance.</param>
        /// <param name="configurationItem">The configuration item to add.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool AddConfigurationItem(ServiceInstance serviceInstance, ConfigurationItem configurationItem)
        {
            return CreateRelation(serviceInstance, "cis", configurationItem);
        }

        /// <summary>
        /// Remove a configuration item.
        /// </summary>
        /// <param name="serviceInstance">The service instance.</param>
        /// <param name="configurationItem">The configuration item to remove.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveConfigurationItem(ServiceInstance serviceInstance, ConfigurationItem configurationItem)
        {
            return DeleteRelation(serviceInstance, "cis", configurationItem);
        }

        /// <summary>
        /// Remove all configuration items.
        /// </summary>
        /// <param name="serviceInstance">The service instance.</param>
        /// <returns>True in case of success; otherwise false.</returns>
        public bool RemoveAllConfigurationItems(ServiceInstance serviceInstance)
        {
            return DeleteAllRelations(serviceInstance, "cis");
        }

        #endregion

        #region Parent services instances

        /// <summary>
        /// Get all parent service instances.
        /// </summary>
        /// <param name="serviceInstance">The service instance.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instance.</returns>
        public List<ServiceInstance> GetParentServiceInstances(ServiceInstance serviceInstance, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(serviceInstance, "parent_service_instances").Get(fieldNames);
        }

        #endregion

        #region Service level agreements

        /// <summary>
        /// Get all related service level agreements.
        /// </summary>
        /// <param name="serviceInstance">The service instance.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreements.</returns>
        public List<ServiceLevelAgreement> GetServiceLevelAgreements(ServiceInstance serviceInstance, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(serviceInstance, "slas").Get(fieldNames);
        }

        /// <summary>
        /// Get all related service level agreements.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="serviceInstance">The service instance.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreements.</returns>
        public List<ServiceLevelAgreement> GetServiceLevelAgreements(PredefinedActiveInactiveFilter filter, ServiceInstance serviceInstance, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(serviceInstance, $"slas/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
