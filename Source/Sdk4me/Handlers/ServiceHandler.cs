using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    public class ServiceHandler : BaseHandler<Service, PredefinedEnabledDisabledFilter>
    {
        public ServiceHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/services", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        public ServiceHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environmentType = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environmentType, environmentRegion)}/services", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Workflow templates

        public List<WorkflowTemplate> GetWorkflowTemplates(Service service, params string[] fieldNames)
        {
            return GetChildHandler<WorkflowTemplate>(service, "workflow_templates").Get(fieldNames);
        }

        public List<WorkflowTemplate> GetWorkflowTemplates(PredefinedEnabledDisabledFilter filter, Service service, params string[] fieldNames)
        {
            return GetChildHandler<WorkflowTemplate>(service, $"workflow_templates/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Request templates

        public List<RequestTemplate> GetRequestTemplates(Service service, params string[] fieldNames)
        {
            return GetChildHandler<RequestTemplate>(service, "request_templates").Get(fieldNames);
        }

        public List<RequestTemplate> GetRequestTemplates(PredefinedEnabledDisabledFilter filter, Service service, params string[] fieldNames)
        {
            return GetChildHandler<RequestTemplate>(service, $"request_templates/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Risks

        public List<Risk> GetRisks(Service service, params string[] fieldNames)
        {
            return GetChildHandler<Risk>(service, "risks").Get(fieldNames);
        }

        public List<Risk> GetRisks(PredefinedOpenClosedFilter filter, Service service, params string[] fieldNames)
        {
            return GetChildHandler<Risk>(service, $"risks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Service instances

        public List<ServiceInstance> GetServiceInstances(Service service, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(service, "service_instances").Get(fieldNames);
        }

        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, Service service, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(service, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Service level agreement

        public List<ServiceLevelAgreement> GetServiceLevelAgreements(Service service, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(service, "slas").Get(fieldNames);
        }

        public List<ServiceLevelAgreement> GetServiceLevelAgreements(PredefinedActiveInactiveFilter filter, Service service, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(service, $"slas/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Service offering

        public List<ServiceOffering> GetServiceOfferings(Service service, params string[] fieldNames)
        {
            return GetChildHandler<ServiceOffering>(service, "service_offerings").Get(fieldNames);
        }

        public List<ServiceOffering> GetServiceOfferings(PredefinedServiceOfferingFilter filter, Service service, params string[] fieldNames)
        {
            return GetChildHandler<ServiceOffering>(service, $"service_offerings/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
