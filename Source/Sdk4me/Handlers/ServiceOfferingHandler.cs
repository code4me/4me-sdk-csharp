using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceOfferingHandler : BaseHandler<ServiceOffering, PredefinedServiceOfferingFilter>
    {
        public ServiceOfferingHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/service_offerings", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceOfferingHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, int itemsPerRequest = 100, int maximumRecursiveRequests = 50) :
            base($"{Common.GetBaseUrl(environmentType)}/v1/service_offerings", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region standard service requests

        public List<StandardServiceRequest> GetStandardServiceRequests(ServiceOffering serviceOffering, params string[] attributeNames)
        {
            DefaultHandler<StandardServiceRequest> handler = new DefaultHandler<StandardServiceRequest>($"{this.URL}/{serviceOffering.ID}/standard_service_requests", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
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
            DefaultHandler<ServiceLevelAgreement> handler = new DefaultHandler<ServiceLevelAgreement>($"{this.URL}/{serviceOffering.ID}/slas", this.AuthenticationTokens, this.AccountID, this.ItemsPerRequest, this.MaximumRecursiveRequests);
            return handler.Get(attributeNames);
        }

        #endregion

    }
}
