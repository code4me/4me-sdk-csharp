using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdk4me
{
    public class ServiceHandler : BaseHandler<Service>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/services";
        private static readonly string productionUrl = "https://api.4me.com/v1/services";

        public ServiceHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region change templates

        public List<ChangeTemplate> GetChangeTemplates(Service service, params string[] attributeNames)
        {
            BaseHandler<ChangeTemplate> handler = new BaseHandler<ChangeTemplate>($"{URL}/{service.ID}/change_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region request templates

        public List<RequestTemplate> GetRequestTemplates(Service service, params string[] attributeNames)
        {
            BaseHandler<RequestTemplate> handler = new BaseHandler<RequestTemplate>($"{URL}/{service.ID}/request_templates", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region service instances

        public List<ServiceInstance> GetServiceInstances(Service service, params string[] attributeNames)
        {
            BaseHandler<ServiceInstance> handler = new BaseHandler<ServiceInstance>($"{URL}/{service.ID}/service_instances", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region service level agreements

        public List<ServiceLevelAgreement> GetServiceLevelAgreements(Service service, params string[] attributeNames)
        {
            BaseHandler<ServiceLevelAgreement> handler = new BaseHandler<ServiceLevelAgreement>($"{URL}/{service.ID}/slas", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

        #region service offering

        public List<ServiceOffering> GetServiceOfferings(Service service, params string[] attributeNames)
        {
            BaseHandler<ServiceOffering> handler = new BaseHandler<ServiceOffering>($"{URL}/{service.ID}/service_offerings", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion
    }
}
