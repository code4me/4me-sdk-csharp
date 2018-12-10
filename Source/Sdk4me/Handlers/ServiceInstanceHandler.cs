using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdk4me
{
    public class ServiceInstanceHandler : BaseHandler<ServiceInstance>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/service_instances";
        private static readonly string productionUrl = "https://api.4me.com/v1/service_instances";

        public ServiceInstanceHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceInstanceHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }


        #region child and parent service instances

        public List<ServiceInstance> GetChildServiceInstances(ServiceInstance serviceInstance, params string[] attributeNames)
        {
            BaseHandler<ServiceInstance> handler = new BaseHandler<ServiceInstance>($"{URL}/{serviceInstance.ID}/child_service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public List<ServiceInstance> GetParentServiceInstances(ServiceInstance serviceInstance, params string[] attributeNames)
        {
            BaseHandler<ServiceInstance> handler = new BaseHandler<ServiceInstance>($"{URL}/{serviceInstance.ID}/parent_service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region configuration items

        public List<ConfigurationItem> GetConfigurationItems(ServiceInstance serviceInstance, params string[] attributeNames)
        {
            BaseHandler<ConfigurationItem> handler = new BaseHandler<ConfigurationItem>($"{URL}/{serviceInstance.ID}/cis", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            BaseHandler<ServiceLevelAgreement> handler = new BaseHandler<ServiceLevelAgreement>($"{URL}/{serviceInstance.ID}/slas", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
