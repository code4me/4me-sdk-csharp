using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceOfferingHandler : BaseHandler<ServiceOffering>
    {
        private static readonly string qualityUrl = "https://api.4me.qa/v1/service_offerings";
        private static readonly string productionUrl = "https://api.4me.com/v1/service_offerings";

        public ServiceOfferingHandler(AuthenticationToken authenticationToken, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceOfferingHandler(AuthenticationTokenCollection authenticationTokens, string accountID = null, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base(environmentType == EnvironmentType.Production ? productionUrl : qualityUrl, authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region standard service requests

        public List<StandardServiceRequest> GetStandardServiceRequests(ServiceOffering serviceOffering, params string[] attributeNames)
        {
            BaseHandler<StandardServiceRequest> handler = new BaseHandler<StandardServiceRequest>($"{URL}/{serviceOffering.ID}/standard_service_requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        public bool AddStandardServiceRequest(ServiceOffering serviceOffering, StandardServiceRequest standardServiceRequest)
        {
            return CreateRelation(serviceOffering, "standard_service_requests", standardServiceRequest);
        }

        public bool RemoveStandardServiceRequest(ServiceOffering serviceOffering, StandardServiceRequest standardServiceRequest)
        {
            return DeleteRelation(serviceOffering, "standard_service_requests", standardServiceRequest);
        }

        public bool RemoveAllStandardServiceRequests(ServiceOffering serviceOffering)
        {
            return DeleteAllRelations(serviceOffering, "standard_service_requests");
        }

        #endregion

        #region service level agreements
    
        public List<ServiceLevelAgreement> GetServiceLevelAgreements(ServiceOffering serviceOffering, params string[] attributeNames)
        {
            BaseHandler<ServiceLevelAgreement> handler = new BaseHandler<ServiceLevelAgreement>($"{URL}/{serviceOffering.ID}/slas", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

    }
}
