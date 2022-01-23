using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceInstanceHandler : BaseHandler<ServiceInstance, PredefinedServiceInstanceFilter>
    {
        public ServiceInstanceHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/service_instances", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceInstanceHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/service_instances", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }


        #region child and parent service instances

        public List<ServiceInstance> GetChildServiceInstances(ServiceInstance serviceInstance, params string[] attributeNames)
        {
            DefaultHandler<ServiceInstance> handler = new DefaultHandler<ServiceInstance>($"{this.URL}/{serviceInstance.ID}/child_service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public List<ServiceInstance> GetParentServiceInstances(ServiceInstance serviceInstance, params string[] attributeNames)
        {
            DefaultHandler<ServiceInstance> handler = new DefaultHandler<ServiceInstance>($"{this.URL}/{serviceInstance.ID}/parent_service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region configuration items

        public List<ConfigurationItem> GetConfigurationItems(ServiceInstance serviceInstance, params string[] attributeNames)
        {
            DefaultHandler<ConfigurationItem> handler = new DefaultHandler<ConfigurationItem>($"{this.URL}/{serviceInstance.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddConfigurationItem(ServiceInstance serviceInstance, ConfigurationItem configuration)
        {
            return CreateRelation(serviceInstance, "cis", configuration);
        }

        public bool RemoveConfigurationItem(ServiceInstance serviceInstance, ConfigurationItem configuration)
        {
            return DeleteRelation(serviceInstance, "cis", configuration);
        }

        public bool RemoveAllConfigurationItems(ServiceInstance serviceInstance)
        {
            return DeleteAllRelations(serviceInstance, "cis");
        }

        #endregion

        #region service level agreements

        public List<ServiceLevelAgreement> GetSLAs(ServiceInstance serviceInstance, params string[] attributeNames)
        {
            DefaultHandler<ServiceLevelAgreement> handler = new DefaultHandler<ServiceLevelAgreement>($"{this.URL}/{serviceInstance.ID}/slas", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
