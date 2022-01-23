using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceCategoryHandler : DefaultHandler<ServiceCategory>
    {
        public ServiceCategoryHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/service_categories", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceCategoryHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/service_categories", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region service instances

        public List<Service> GetServices(ServiceCategory serviceCategory, params string[] attributeNames)
        {
            DefaultHandler<Service> handler = new DefaultHandler<Service>($"{this.URL}/{serviceCategory.ID}/services", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
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
