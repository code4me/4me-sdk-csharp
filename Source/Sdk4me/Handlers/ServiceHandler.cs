using Sdk4me.Extensions;
using System.Collections.Generic;

namespace Sdk4me
{
    /// <summary>
    /// The 4me <see href="https://developer.4me.com/v1/services/">service</see> API endpoint.
    /// </summary>
    public class ServiceHandler : BaseHandler<Service, PredefinedEnabledDisabledFilter>
    {
        /// <summary>
        /// Create a new instance of the 4me service handler.
        /// </summary>
        /// <param name="authenticationToken">The API authentication token.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ServiceHandler(AuthenticationToken authenticationToken, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/services", authenticationToken, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        /// <summary>
        /// Create a new instance of the 4me service handler.
        /// </summary>
        /// <param name="authenticationTokens">The API authentication token collection.</param>
        /// <param name="accountID">The 4me account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        /// <param name="itemsPerRequest">The number of items per paged request.</param>
        /// <param name="maximumRecursiveRequests">The number of recursive requests.</param>
        public ServiceHandler(AuthenticationTokenCollection authenticationTokens, string accountID, EnvironmentType environment = EnvironmentType.Production, EnvironmentRegion environmentRegion = EnvironmentRegion.Global, int itemsPerRequest = 25, int maximumRecursiveRequests = 10)
            : base($"{EnvironmentURL.Get(environment, environmentRegion)}/services", authenticationTokens, accountID, itemsPerRequest, maximumRecursiveRequests)
        {
        }

        #region Workflow templates

        /// <summary>
        /// Get all related workflow templates.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of workflow templates.</returns>
        public List<WorkflowTemplate> GetWorkflowTemplates(Service service, params string[] fieldNames)
        {
            return GetChildHandler<WorkflowTemplate>(service, "workflow_templates").Get(fieldNames);
        }

        /// <summary>
        /// Get all related workflow templates.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="service">The service.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of workflow templates.</returns>
        public List<WorkflowTemplate> GetWorkflowTemplates(PredefinedEnabledDisabledFilter filter, Service service, params string[] fieldNames)
        {
            return GetChildHandler<WorkflowTemplate>(service, $"workflow_templates/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Request templates

        /// <summary>
        /// Get all related request templates.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of request templates.</returns>
        public List<RequestTemplate> GetRequestTemplates(Service service, params string[] fieldNames)
        {
            return GetChildHandler<RequestTemplate>(service, "request_templates").Get(fieldNames);
        }

        /// <summary>
        /// Get all related request templates.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="service">The service.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of request templates.</returns>
        public List<RequestTemplate> GetRequestTemplates(PredefinedEnabledDisabledFilter filter, Service service, params string[] fieldNames)
        {
            return GetChildHandler<RequestTemplate>(service, $"request_templates/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Risks

        /// <summary>
        /// Get all related risks.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of risks.</returns>
        public List<Risk> GetRisks(Service service, params string[] fieldNames)
        {
            return GetChildHandler<Risk>(service, "risks").Get(fieldNames);
        }

        /// <summary>
        /// Get all related risks.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="service">The service.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of risks.</returns>
        public List<Risk> GetRisks(PredefinedOpenClosedFilter filter, Service service, params string[] fieldNames)
        {
            return GetChildHandler<Risk>(service, $"risks/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Service instances

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(Service service, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(service, "service_instances").Get(fieldNames);
        }

        /// <summary>
        /// Get all related service instances.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="service">The service.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service instances.</returns>
        public List<ServiceInstance> GetServiceInstances(PredefinedActiveInactiveFilter filter, Service service, params string[] fieldNames)
        {
            return GetChildHandler<ServiceInstance>(service, $"service_instances/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Service level agreement

        /// <summary>
        /// Get all related service level agreements.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreements.</returns>
        public List<ServiceLevelAgreement> GetServiceLevelAgreements(Service service, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(service, "slas").Get(fieldNames);
        }

        /// <summary>
        /// Get all related service level agreements.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="service">The service.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service level agreements.</returns>
        public List<ServiceLevelAgreement> GetServiceLevelAgreements(PredefinedActiveInactiveFilter filter, Service service, params string[] fieldNames)
        {
            return GetChildHandler<ServiceLevelAgreement>(service, $"slas/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion

        #region Service offering

        /// <summary>
        /// Get all related service offerings.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service offerings.</returns>
        public List<ServiceOffering> GetServiceOfferings(Service service, params string[] fieldNames)
        {
            return GetChildHandler<ServiceOffering>(service, "service_offerings").Get(fieldNames);
        }

        /// <summary>
        /// Get all related service offerings.
        /// </summary>
        /// <param name="filter">The predefined filter.</param>
        /// <param name="service">The service.</param>
        /// <param name="fieldNames">The field names to return.</param>
        /// <returns>A collection of service offerings.</returns>
        public List<ServiceOffering> GetServiceOfferings(PredefinedServiceOfferingFilter filter, Service service, params string[] fieldNames)
        {
            return GetChildHandler<ServiceOffering>(service, $"service_offerings/{filter.To4meString()}").Get(fieldNames);
        }

        #endregion
    }
}
