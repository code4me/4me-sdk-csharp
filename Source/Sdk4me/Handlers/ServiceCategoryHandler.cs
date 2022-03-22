using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceCategoryHandler : DefaultBaseHandler<ServiceCategory>
    {
        public ServiceCategoryHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/service_categories", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceCategoryHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/service_categories", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Services

        public List<Service> GetServices(ServiceCategory serviceCategory, params string[] fieldNames)
        {
            return GetChildHandler<Service>(serviceCategory, "services").Get(fieldNames);
        }

        public List<Service> GetServices(PredefinedEnabledDisabledFilter filter, ServiceCategory serviceCategory, params string[] fieldNames)
        {
            return GetChildHandler<Service>(serviceCategory, $"services/{filter.To4meString()}").Get(fieldNames);
        }

        public bool AddService(ServiceCategory serviceCategory, Service service)
        {
            return CreateRelation(serviceCategory, "services", service);
        }

        public bool RemoveService(ServiceCategory serviceCategory, Service service)
        {
            return DeleteRelation(serviceCategory, "services", service);
        }

        public bool RemoveAllServices(ServiceCategory serviceCategory)
        {
            return DeleteAllRelations(serviceCategory, "services");
        }

        #endregion   
    }
}
