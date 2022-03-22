using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceInstanceHandler : BaseHandler<ServiceInstance, PredefinedActiveInactiveFilter>
    {
        public ServiceInstanceHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/service_instances", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceInstanceHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/service_instances", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Child service instances

        public List<ServiceInstance> GetChildServiceInstances(ServiceInstance serviceInstance, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(serviceInstance, "child_service_instances").Get(fieldNames);
        }

        #endregion

        #region Configuration items

        public List<ConfigurationItem> GetConfigurationItems(ServiceInstance serviceInstance, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(serviceInstance, "cis").Get(fieldNames);
        }

        public List<ConfigurationItem> GetConfigurationItems(PredefinedActiveInactiveFilter filter, ServiceInstance serviceInstance, params string[] fieldNames)
        {
            return GetChildHandler<ConfigurationItem>(serviceInstance, $"cis/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddConfigurationItem(ServiceInstance serviceInstance, ConfigurationItem configurationItem)
        {
            return CreateRelation(serviceInstance, "cis", configurationItem);
        }

        public bool RemoveConfigurationItem(ServiceInstance serviceInstance, ConfigurationItem configurationItem)
        {
            return DeleteRelation(serviceInstance, "cis", configurationItem);
        }

        public bool RemoveAllConfigurationItems(ServiceInstance serviceInstance)
        {
            return DeleteAllRelations(serviceInstance, "cis");
        }
        #endregion

        #region Parent services instances

        public List<ServiceInstance> GetParentServiceInstances(ServiceInstance serviceInstance, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(serviceInstance, "parent_service_instances").Get(fieldNames);
        }

        #endregion

        #region Service level agreements

        public List<ServiceLevelAgreement> GetServiceLevelAgreements(ServiceInstance serviceInstance, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(serviceInstance, "slas").Get(fieldNames);
        }

        public List<ServiceLevelAgreement> GetServiceLevelAgreements(PredefinedActiveInactiveFilter filter, ServiceInstance serviceInstance, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(serviceInstance, $"slas/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
