using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdk4me
{
    public class ServiceHandler : BaseHandler<Service, PredefinedServiceFilter>
    {
        public ServiceHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/services",  authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/services",  authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region change templates

        public List<ChangeTemplate> GetChangeTemplates(Service service, params string[] attributeNames)
        {
            DefaultHandler<ChangeTemplate> handler = new DefaultHandler<ChangeTemplate>($"{URL}/{service.ID}/change_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region request templates

        public List<RequestTemplate> GetRequestTemplates(Service service, params string[] attributeNames)
        {
            DefaultHandler<RequestTemplate> handler = new DefaultHandler<RequestTemplate>($"{URL}/{service.ID}/request_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region service instances

        public List<ServiceInstance> GetServiceInstances(Service service, params string[] attributeNames)
        {
            DefaultHandler<ServiceInstance> handler = new DefaultHandler<ServiceInstance>($"{URL}/{service.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region service level agreements

        public List<ServiceLevelAgreement> GetServiceLevelAgreements(Service service, params string[] attributeNames)
        {
            DefaultHandler<ServiceLevelAgreement> handler = new DefaultHandler<ServiceLevelAgreement>($"{URL}/{service.ID}/slas", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region service offering

        public List<ServiceOffering> GetServiceOfferings(Service service, params string[] attributeNames)
        {
            DefaultHandler<ServiceOffering> handler = new DefaultHandler<ServiceOffering>($"{URL}/{service.ID}/service_offerings", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
