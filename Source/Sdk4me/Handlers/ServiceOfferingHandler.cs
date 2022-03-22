using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceOfferingHandler : BaseHandler<ServiceOffering, PredefinedServiceOfferingFilter>
    {
        public ServiceOfferingHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/service_offerings", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceOfferingHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/service_offerings", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Service level agreements

        public List<ServiceLevelAgreement> GetConfigurationItems(ServiceOffering serviceOffering, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(serviceOffering, "slas").Get(fieldNames);
        }

        public List<ServiceLevelAgreement> GetConfigurationItems(PredefinedActiveInactiveFilter filter, ServiceOffering serviceOffering, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(serviceOffering, $"slas/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Standard service request

        public List<StandardServiceRequest> GetStandardServiceRequests(ServiceOffering serviceOffering, params string[] fieldNames)
        {
            return GetChildHandler<StandardServiceRequest>(serviceOffering, "standard_service_requests").Get(fieldNames);
        }

        public StandardServiceRequest AddStandardServiceRequest(ServiceOffering serviceOffering, StandardServiceRequest standardServiceRequest)
        {
            return GetChildHandler<StandardServiceRequest>(serviceOffering, "standard_service_requests").Insert(standardServiceRequest);
        }

        public StandardServiceRequest UpdateStandardServiceRequest(ServiceOffering serviceOffering, StandardServiceRequest standardServiceRequest)
        {
            return GetChildHandler<StandardServiceRequest>(serviceOffering, "standard_service_requests").Update(standardServiceRequest);
        }

        public bool DeleteStandardServiceRequest(ServiceOffering serviceOffering, StandardServiceRequest standardServiceRequest)
        {
            return GetChildHandler<StandardServiceRequest>(serviceOffering, "standard_service_requests").Delete(standardServiceRequest);
        }

        public bool DeleteStandardServiceRequests(ServiceOffering serviceOffering)
        {
            return GetChildHandler<StandardServiceRequest>(serviceOffering, "standard_service_requests").DeleteAll();
        }

        #endregion
    }
}
